using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace PersianTools.Core
{
    public struct PersianDateTime : IComparable, IComparable<PersianDateTime>, IConvertible, IEquatable<PersianDateTime>, IFormattable
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
        private readonly static string[] months = new string[] { "","فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        private const string PersianDatePattern = @"^$|^([1][0-9]{3}[/\/]([0][1-6])[/\/]([0][1-9]|[12][0-9]|[3][01])|[1][0-9]{3}[/\/]([0][7-9]|[1][012])[/\/]([0][1-9]|[12][0-9]|(30)))$";
        public static string AM = "ق.ظ";
        public static string PM = "ب.ظ";
        // Number of days in a non-leap year
        private const int DaysPerYear = 365;
        #endregion
        private readonly static PersianCalendar persianCalendar = new PersianCalendar();
        private readonly static HijriCalendar hijri = new HijriCalendar();
        private DateTime dateTime;
        public DateTime DateTime
        {
            get { return this.dateTime; }
            private set { this.dateTime = value;}
        }
        //public PersianDateTime PersianDate { get; }
        public int Millisecond { get; }
        public int Second { get; }
        public int Minute { get; }
        public int Hour { get; }
        public int Day { get; }
        public int Month { get; }
        public int Year { get; }
        public string DayOfWeek
        {
            get
            {
                return dayOfWeek[this.dateTime.DayOfWeek.GetHashCode()];
            }
        }
        public TimeSpan TimeOfDay
        {
            get
            {
                return this.dateTime.TimeOfDay;
            }
        }
        #region Constructor
        public PersianDateTime(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int millisecond = 0)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
            this.Millisecond = millisecond;
            this.dateTime = persianCalendar.ToDateTime(this.Year, this.Month, this.Day, this.Hour, this.Minute, this.Second, this.Millisecond);
        }

        public PersianDateTime(string shamsiDate = "1380/01/01")
        {
            this.Year = this.Month = this.Day = this.Hour = this.Minute = this.Second = this.Millisecond = 0;
            shamsiDate = shamsiDate.Replace(" ", "");
            if (!Regex.IsMatch(shamsiDate, PersianDatePattern))
            {
                throw new ArgumentException("فرمت تاریخ وارد شده صحیح نمی باشد");
            }
            this.Year = Convert.ToInt32(shamsiDate.Substring(0, 4));
            this.Month = Convert.ToInt32(shamsiDate.Substring(5, 2));
            this.Day = Convert.ToInt32(shamsiDate.Substring(8, 2));
            this.dateTime = persianCalendar.ToDateTime(this.Year, this.Month, this.Day, this.Hour, this.Minute, this.Second, this.Millisecond);
        }
        public PersianDateTime(DateTime dateTime)
        {
            this.dateTime = dateTime;
            this.Year = persianCalendar.GetYear(dateTime);
            this.Month = persianCalendar.GetMonth(dateTime);
            this.Day = persianCalendar.GetDayOfMonth(dateTime); 
            this.Hour = persianCalendar.GetHour(dateTime); 
            this.Minute = persianCalendar.GetMinute(dateTime); 
            this.Second = persianCalendar.GetSecond(dateTime); 
            this.Millisecond = Convert.ToInt32(persianCalendar.GetMilliseconds(dateTime));

        }
        #endregion
        public static PersianDateTime Now { get { return new PersianDateTime(DateTime.Now); } }
        public static PersianDateTime Today { get { return new PersianDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)); } }
        public static PersianDateTime UtcNow { get { return new PersianDateTime(DateTime.UtcNow); } }
        public static PersianDateTime EndOfDay(PersianDateTime persianDateTime)
        {
            return new PersianDateTime(persianDateTime.Year, persianDateTime.Month, persianDateTime.Day, 23, 59, 59, 999);
        }
        public static PersianDateTime EndOfDay(DateTime dateTime)
        {
            return new PersianDateTime(new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59,999));
        }
        public static PersianDateTime StartOfDay(PersianDateTime persianDateTime)
        {
            return new PersianDateTime(persianDateTime.Year, persianDateTime.Month, persianDateTime.Day, 0, 0, 0);
        }
        public static PersianDateTime StartOfDay(DateTime dateTime)
        {
            return new PersianDateTime(new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0));
        }
        public static PersianDateTime StartOfYearPersianDateTime(int year)
            => new PersianDateTime(year, 1, 1);
        public static DateTime StartOfYearDateTime(int year)
            => new PersianDateTime(year, 1, 1).dateTime;
        public static PersianDateTime EndOfYearPersianDateTime(int year)
        {
            return new PersianDateTime(year+1, 1, 1).AddMilliseconds(-1);
        }
        public static PersianDateTime EndDateOfMonth(int year,int month)
        {
            return new PersianDateTime(year,month, persianCalendar.GetDaysInMonth(year,month),23,59,59,999);
        }
        public static PersianDateTime EndDateOfMonth(DateTime dateTime)
        {
            return new PersianDateTime(persianCalendar.GetYear(dateTime),persianCalendar.GetMonth(dateTime),persianCalendar.GetDaysInMonth(persianCalendar.GetYear(dateTime), persianCalendar.GetMonth(dateTime)),23,59,59,999);
        }
        public static PersianDateTime SrartDateOfMonth(int year, int month)
        {
            return new PersianDateTime(year, month, 1);
        }
        public static PersianDateTime SrartDateOfMonth(DateTime dateTime)
        {
            return new PersianDateTime(persianCalendar.GetYear(dateTime), persianCalendar.GetMonth(dateTime),1);
        }
        public override string ToString()
        {
            return $"{this.Year}/{this.Month.ToString("00")}/{this.Day.ToString("00")} {this.Hour.ToString("00")}:{this.Minute.ToString("00")}:{this.Second.ToString("00")}";
        }
        /// <summary>
        /// شنبه بیست آذر سال یکهزار سیصد و نود وهفت ساعت هفت و سی دقیقه و بیست ثانیه
        /// </summary>
        /// <returns></returns>
        public string ToLongStringYMDHMS()
        {
            return $"{DayOfWeek} {CharacterUtil.Convert(this.Day)} {months[this.Month]} سال  {CharacterUtil.Convert(this.Year)} ساعت {CharacterUtil.Convert(this.Hour)} و {CharacterUtil.Convert(this.Minute)} دقیقه و {CharacterUtil.Convert(this.Second)} ثانیه";
        }
        /// <summary>
        /// شنبه بیست آذر سال یکهزار سیصد و نود وهفت ساعت هفت و سی دقیقه
        /// </summary>
        /// <returns></returns>
        public string ToLongStringYMDHM()
        {
            return $"{DayOfWeek} {CharacterUtil.Convert(this.Day)} {months[this.Month]} سال  {CharacterUtil.Convert(this.Year)} ساعت {CharacterUtil.Convert(this.Hour)} و {CharacterUtil.Convert(this.Minute)} دقیقه";
        }
        /// <summary>
        /// شنبه بیست آذر سال یکهزار سیصد و نود وهفت
        /// </summary>
        /// <returns></returns>
        public string ToLongStringYMD()
        {
            return $"{DayOfWeek} {CharacterUtil.Convert(this.Day)} {months[this.Month]} سال  {CharacterUtil.Convert(this.Year)}";
        }/// <summary>
        /// ساعت پانزده و سی دقیقه
        /// </summary>
        /// <returns></returns>
        public string ToLongStringHMS()
        {
            return $"ساعت {CharacterUtil.Convert(this.Hour)} و {CharacterUtil.Convert(this.Minute)} دقیقه";
        }
        public bool Equals(PersianDateTime other)
        {
            throw new NotImplementedException();
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        

        public int CompareTo(PersianDateTime other)
        {
            throw new InvalidCastException("Invalid Cast From DateTime To Decimal");
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #region Change Date By Parameter From Persian Calender
        public PersianDateTime AddDays(int days)
        {
            return new PersianDateTime(persianCalendar.AddDays(this.dateTime, days));
        }
        public PersianDateTime AddMonths(int months)
        {
            return new PersianDateTime(persianCalendar.AddMonths(this.dateTime, months));
        }
        public PersianDateTime AddYears(int year)
        {
            return new PersianDateTime(persianCalendar.AddYears(this.dateTime, year));
        }
        public PersianDateTime AddHours(int hours)
        {
            return new PersianDateTime(persianCalendar.AddHours(this.dateTime, hours));
        }
        public PersianDateTime AddMinutes(int minutes)
        {
            return new PersianDateTime(persianCalendar.AddMinutes(this.dateTime, minutes));
        }
        public PersianDateTime AddSeconds(int seconds)
        {
            return new PersianDateTime(persianCalendar.AddSeconds(this.dateTime, seconds));
        }
        public PersianDateTime AddMilliseconds(int milliseconds)
        {
            return new PersianDateTime(persianCalendar.AddMilliseconds(this.dateTime, milliseconds));
        }
        public PersianDateTime AddWeeks(int week)
        {
            return new PersianDateTime(persianCalendar.AddWeeks(this.dateTime, week));
        }
        #endregion

        #region PersianDateTime Conversion
        public bool ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException("Invalid Cast From DateTime To Boolean");
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new InvalidCastException("Invalid Cast From DateTime To Byte");
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException("Invalid Cast From DateTime To Char");
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return this.dateTime;
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal($"{this.Year}{this.Month.ToString("00")}{this.Day.ToString("00")}{this.Hour.ToString("00")}{this.Minute.ToString("00")}{this.Second.ToString("00")}");
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble($"{this.Year.ToString("00")}{this.Month.ToString("00")}{this.Day.ToString("00")}{this.Hour.ToString("00")}{this.Minute.ToString("00")}{this.Second.ToString("00")}");
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new InvalidCastException("Invalid Cast From DateTime To Int16");
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32($"{this.Year.ToString("00")}{this.Month.ToString("00")}{this.Day.ToString("00")}");
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt32($"{this.Year.ToString("00")}{this.Month.ToString("00")}{this.Day.ToString("00")}");
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new InvalidCastException("Invalid Cast From DateTime To SByte");
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new InvalidCastException("Invalid Cast From DateTime To Single");
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new InvalidCastException("Invalid Cast From DateTime To Decimal");
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new InvalidCastException("Invalid Cast From DateTime To Decimal");
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new InvalidCastException("Invalid Cast From DateTime To Decimal");
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new InvalidCastException("Invalid Cast From DateTime To Decimal");
        }
        #endregion

        #region PersianDateTime Operator Override
        public static PersianDateTime operator +(PersianDateTime d, TimeSpan t)
        {
            long ticks = d.dateTime.Ticks;
            long valueTicks = t.Ticks;
            if (valueTicks > MaxTicks - ticks || valueTicks < MinTicks - ticks)
            {
                throw new ArgumentOutOfRangeException("ArgumentOutOfRange_DateArithmetic");
            }
            return new PersianDateTime(d.dateTime + t);
        }

        public static PersianDateTime operator -(PersianDateTime d, TimeSpan t)
        {
            return new PersianDateTime(d.dateTime - t);
        }

        public static TimeSpan operator -(PersianDateTime d1, PersianDateTime d2)
        {
            return new TimeSpan(d1.dateTime.Ticks - d2.dateTime.Ticks);
        }

        public static bool operator ==(PersianDateTime d1, PersianDateTime d2)
        {
            return d1.dateTime == d2.dateTime;
        }

        public static bool operator !=(PersianDateTime d1, PersianDateTime d2)
        {
            return d1.dateTime != d2.dateTime;
        }

        public static bool operator <(PersianDateTime t1, PersianDateTime t2)
        {
            return t1.dateTime < t2.dateTime;
        }

        public static bool operator <=(PersianDateTime t1, PersianDateTime t2)
        {
            return t1.dateTime <= t2.dateTime;
        }

        public static bool operator >(PersianDateTime t1, PersianDateTime t2)
        {
            return t1.dateTime > t2.dateTime;
        }

        public static bool operator >=(PersianDateTime t1, PersianDateTime t2)
        {
            return t1.dateTime >= t2.dateTime;
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
        #endregion

        public static double DateDifference(PersianDateTime d1, PersianDateTime d2)
        => (d1.dateTime - d2.dateTime).TotalDays;
    }
}
