using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace PersianTools.Core
{
    public partial class PersianDateTime : IConvertible
    {
        #region Fields
        public static readonly PersianDateTime MaxValue;
        public static readonly PersianDateTime MinValue;
        private const long TicksPerMillisecond = 10000;
        private const long TicksPerSecond = TicksPerMillisecond * 1000;
        private const long TicksPerMinute = TicksPerSecond * 60;
        private const long TicksPerHour = TicksPerMinute * 60;
        private const long TicksPerDay = TicksPerHour * 24;

        // Number of milliseconds per time unit
        private const int MillisPerSecond = 1000;
        private const int MillisPerMinute = MillisPerSecond * 60;
        private const int MillisPerHour = MillisPerMinute * 60;
        private const int MillisPerDay = MillisPerHour * 24;
        // Number of days in 4 years
        private const int DaysPer4Years = DaysPerYear * 4 + 1;       // 1461
                                                                     // Number of days in 100 years
        private const int DaysPer100Years = DaysPer4Years * 25 - 1;  // 36524
                                                                     // Number of days in 400 years
        private const int DaysPer400Years = DaysPer100Years * 4 + 1; // 146097

        // Number of days from 1/1/0001 to 12/31/1600
        private const int DaysTo1601 = DaysPer400Years * 4;          // 584388
                                                                     // Number of days from 1/1/0001 to 12/30/1899
        private const int DaysTo1899 = DaysPer400Years * 4 + DaysPer100Years * 3 - 367;
        // Number of days from 1/1/0001 to 12/31/1969
        internal const int DaysTo1970 = DaysPer400Years * 4 + DaysPer100Years * 3 + DaysPer4Years * 17 + DaysPerYear; // 719,162
                                                                                                                      // Number of days from 1/1/0001 to 12/31/9999
        private const int DaysTo10000 = DaysPer400Years * 25 - 366;  // 3652059 

        internal const long MinTicks = 0;
        internal const long MaxTicks = DaysTo10000 * TicksPerDay - 1;
        private readonly static string[] dayOfWeek = new string[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه", "شنبه" };
        private readonly static string[] months = new string[] { "", "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        public static string AM = "ق.ظ";
        public static string PM = "ب.ظ";
        // Number of days in a non-leap year
        private const int DaysPerYear = 365;
        #endregion

        private readonly static PersianCalendar persianCalendar = new PersianCalendar();

        private DateTime dateTime;

        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                Initial(value);
            }
        }

        //public PersianDateTime PersianDate { get; }
        public int Millisecond { get; private set; }
        public int Second { get; private set; }
        public int Minute { get; private set; }
        public int Hour { get; private set; }
        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
        public string DayOfWeek
        {
            get
            {
                return dayOfWeek[DateTime.DayOfWeek.GetHashCode()];
            }
        }

        public string MonthOfYear
        {
            get
            {
                return months[Month];
            }
        }
        public string ShamsiDate
        {
            get
            {
                return ToString();
            }
        }

        public TimeSpan TimeOfDay
        {
            get
            {
                return DateTime.TimeOfDay;
            }
        }

        public IEnumerable<DateMetaData> DateMetaDatas { get; set; }
        public HijriDate HijriDate { get; private set; }
        public bool IsHoliDay { get; private set; } = false;

        #region Constructor
        public PersianDateTime(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int millisecond = 0)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
            DateTime = persianCalendar.ToDateTime(Year, Month, Day, Hour, Minute, Second, Millisecond);
            //CommonConstructor(DateTime);
        }

        public PersianDateTime(string shamsiDate = "1380/01/01 23:32:56")
        {

            if (!PersianHelper.IsPersianDateValid(shamsiDate.Replace(" ", "").Substring(0, 10)))
            {
                throw new ArgumentOutOfRangeException("فرمت تاریخ وارد شده صحیح نمی باشد");
            }

            if (shamsiDate.Length > 10)
                if (PersianHelper.IsTimeValid(shamsiDate.Substring(11, shamsiDate.Length - 11)))
                {
                    int h = 0, m = 0, s = 0;
                    if (shamsiDate.Length > 11)
                        int.TryParse(shamsiDate.Substring(11, 2), out h);
                    if (shamsiDate.Length > 14)
                        int.TryParse(shamsiDate.Substring(14, 2), out m);
                    if (shamsiDate.Length > 17)
                        int.TryParse(shamsiDate.Substring(17, 2), out s);
                    Hour = h;
                    Minute = m;
                    Second = s;
                }
            Year = Convert.ToInt32(shamsiDate.Substring(0, 4));
            Month = Convert.ToInt32(shamsiDate.Substring(5, 2));
            Day = Convert.ToInt32(shamsiDate.Substring(8, 2));
            DateTime = persianCalendar.ToDateTime(Year, Month, Day, Hour, Minute, Second, Millisecond);
        }

        public PersianDateTime(DateTime dateTime)
        {
            Initial(dateTime);
        }

        private void Initial(DateTime datetime)
        {
            dateTime = datetime;
            Year = persianCalendar.GetYear(datetime);
            Month = persianCalendar.GetMonth(datetime);
            Day = persianCalendar.GetDayOfMonth(datetime);
            Hour = persianCalendar.GetHour(datetime);
            Minute = persianCalendar.GetMinute(datetime);
            Second = persianCalendar.GetSecond(datetime);
            Millisecond = Convert.ToInt32(persianCalendar.GetMilliseconds(datetime));
            HijriDate = new HijriDate();
            HijriCalendarManager.SetHijriCalendar(datetime);
            HijriDate.Year = HijriCalendarManager.GetHijriCalendar().GetYear(datetime);
            HijriDate.Month = HijriCalendarManager.GetHijriCalendar().GetMonth(datetime);
            HijriDate.Day = HijriCalendarManager.GetHijriCalendar().GetDayOfMonth(datetime);
            DateMetaDatas = HoliDaysData.GetInstance().GetMetaDataByDateTime(datetime);

            IsHoliDay = datetime.DayOfWeek == System.DayOfWeek.Friday;
            foreach (var item in DateMetaDatas)
            {
                IsHoliDay = IsHoliDay || item.IsHoliDay || DateTime.DayOfWeek == System.DayOfWeek.Friday;
            }
        }



        #endregion

        public static PersianDateTime Now { get { return new PersianDateTime(DateTime.Now); } }
        public static PersianDateTime Today { get { return new PersianDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)); } }
        public static PersianDateTime UtcNow { get { return new PersianDateTime(DateTime.UtcNow); } }


        public bool Equals(PersianDateTime other)
        {
            return this == other;
        }


        public DateTime ToDateTime(IFormatProvider provider)
        {
            return DateTime;
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal($"{Year}{Month.ToString("00")}{Day.ToString("00")}{Hour.ToString("00")}{Minute.ToString("00")}{Second.ToString("00")}");
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble($"{Year.ToString("00")}{Month.ToString("00")}{Day.ToString("00")}{Hour.ToString("00")}{Minute.ToString("00")}{Second.ToString("00")}");
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32($"{Year.ToString("00")}{Month.ToString("00")}{Day.ToString("00")}");
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt32($"{Year.ToString("00")}{Month.ToString("00")}{Day.ToString("00")}");
        }

        public string ToString(IFormatProvider provider)
        {
            return $"{Year}/{Month.ToString("00")}/{Day.ToString("00")} {Hour.ToString("00")}:{Minute.ToString("00")}:{Second.ToString("00")}";
        }
        public string ToString(string format)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fa-IR");
            DateTime dateTime = new DateTime(Year, Month, Day, Hour, Minute, Second, Millisecond, persianCalendar);
            return dateTime.ToString(format, new System.Globalization.CultureInfo("fa-IR"));
        }

        #region PersianDateTime Operator Override
        public static PersianDateTime operator ++(PersianDateTime d)
        {
            return d.AddDays(1);
        }

        public static PersianDateTime operator --(PersianDateTime d)
        {
            return d.AddDays(-1);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as PersianDateTime);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public static PersianDateTime operator +(PersianDateTime d, TimeSpan t)
        {
            long ticks = d.DateTime.Ticks;
            long valueTicks = t.Ticks;
            if (valueTicks > MaxTicks - ticks || valueTicks < MinTicks - ticks)
            {
                throw new ArgumentOutOfRangeException("ArgumentOutOfRange_DateArithmetic");
            }
            d.DateTime += t;
            return d;
        }

        public static PersianDateTime operator -(PersianDateTime d, TimeSpan t)
        {
            d.DateTime -= t;
            return d;
        }

        public static TimeSpan operator -(PersianDateTime d1, PersianDateTime d2)
        {
            return new TimeSpan(d1.DateTime.Ticks - d2.DateTime.Ticks);
        }

        public static bool operator ==(PersianDateTime d1, PersianDateTime d2)
        {
            return d1.DateTime == d2.DateTime;
        }

        public static bool operator !=(PersianDateTime d1, PersianDateTime d2)
        {
            return d1.DateTime != d2.DateTime;
        }

        public static bool operator <(PersianDateTime t1, PersianDateTime t2)
        {
            return t1.DateTime < t2.DateTime;
        }

        public static bool operator <=(PersianDateTime t1, PersianDateTime t2)
        {
            return t1.DateTime <= t2.DateTime;
        }

        public static bool operator >(PersianDateTime t1, PersianDateTime t2)
        {
            return t1.DateTime > t2.DateTime;
        }

        public static bool operator >=(PersianDateTime t1, PersianDateTime t2)
        {
            return t1.DateTime >= t2.DateTime;
        }

        #endregion

    }
}
