using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PersianTools.Core
{
    public static class PersianDateExtensions
    {
        private readonly static PersianCalendar PersianCalendar = new PersianCalendar();
        private readonly static HijriCalendar hijri = new HijriCalendar { HijriAdjustment = -1 };

        public static PersianDateTime AddDays(this PersianDateTime persianDateTime, int days)
        {
            var dateTime = PersianCalendar.AddDays(persianDateTime.DateTime, days);
            persianDateTime.DateTime = dateTime;
            return new PersianDateTime(dateTime);
        }

        public static PersianDateTime AddMonths(this PersianDateTime persianDateTime, int months)
        {
            var dateTime = PersianCalendar.AddMonths(persianDateTime.DateTime, months);
            persianDateTime.DateTime = dateTime;
            return new PersianDateTime(dateTime);
        }

        public static PersianDateTime AddYears(this PersianDateTime persianDateTime, int years)
        {
            var dateTime = PersianCalendar.AddYears(persianDateTime.DateTime, years);
            persianDateTime.DateTime = dateTime;
            return new PersianDateTime(dateTime);
        }

        public static PersianDateTime AddHours(this PersianDateTime persianDateTime, int hours)
        {
            var dateTime = PersianCalendar.AddHours(persianDateTime.DateTime, hours);
            persianDateTime.DateTime = dateTime;
            return new PersianDateTime(dateTime);
        }

        public static PersianDateTime AddMinutes(this PersianDateTime persianDateTime, int minutes)
        {
            var dateTime = PersianCalendar.AddMinutes(persianDateTime.DateTime, minutes);
            persianDateTime.DateTime = dateTime;
            return new PersianDateTime(dateTime);
        }

        public static PersianDateTime AddSeconds(this PersianDateTime persianDateTime, int seconds)
        {
            var dateTime = PersianCalendar.AddSeconds(persianDateTime.DateTime, seconds);
            persianDateTime.DateTime = dateTime;
            return new PersianDateTime(dateTime);
        }

        public static PersianDateTime AddMilliseconds(this PersianDateTime persianDateTime, int milliseconds)
        {
            var dateTime = PersianCalendar.AddMilliseconds(persianDateTime.DateTime, milliseconds);
            persianDateTime.DateTime = dateTime;
            return new PersianDateTime(dateTime);
        }

        public static PersianDateTime AddWeeks(this PersianDateTime persianDateTime, int weeks)
        {
            var dateTime = PersianCalendar.AddWeeks(persianDateTime.DateTime, weeks);
            persianDateTime.DateTime = dateTime;
            return new PersianDateTime(dateTime);
        }

        public static double DateDifference(this PersianDateTime d1, PersianDateTime d2)
            => (d1.DateTime - d2.DateTime).TotalDays;



        public static PersianDateTime ShamsiEndDateTimeOfDay(this PersianDateTime persianDateTime)
            => ShamsiEndDateTimeOfDay(persianDateTime.DateTime);

        public static PersianDateTime ShamsiEndDateTimeOfDay(this DateTime dateTime)
            => new PersianDateTime(new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999));

        public static PersianDateTime ShamsiStartDateTimeOfDay(this PersianDateTime persianDateTime)
            => ShamsiStartDateTimeOfDay(persianDateTime.DateTime);

        public static PersianDateTime ShamsiStartDateTimeOfDay(this DateTime dateTime)
            => new PersianDateTime(new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0));

        public static PersianDateTime ShamsiStartDateTimeOfPersianYear(int year)
            => new PersianDateTime(year, 1, 1);

        public static DateTime MiladiStartDateOfPersianYear(int year)
            => ShamsiStartDateTimeOfPersianYear(year).DateTime;

        public static PersianDateTime ShamsiEndDateTimeOfPersianYear(int year)
            => new PersianDateTime(year + 1, 1, 1).AddMilliseconds(-1);

        public static DateTime MiladiEndDateTimeOfPersianYear(int year)
            => ShamsiEndDateTimeOfPersianYear(year).DateTime;

        public static PersianDateTime ShamsiEndDateTimeOfMonth(int year, int month)
            => new PersianDateTime(year, month, PersianCalendar.GetDaysInMonth(year, month), 23, 59, 59, 999);

        public static PersianDateTime ShamsiEndDateTimeOfMonth(this DateTime dateTime)
            => ShamsiEndDateTimeOfMonth(PersianCalendar.GetYear(dateTime), PersianCalendar.GetMonth(dateTime));


        public static PersianDateTime ShamsiStartDateTimeOfPersianMonth(int year, int month)
            => new PersianDateTime(year, month, 1);


        public static PersianDateTime ShamsiStartDateTimeOfPersianMonth(this DateTime dateTime)
            => ShamsiStartDateTimeOfPersianMonth(PersianCalendar.GetYear(dateTime), PersianCalendar.GetMonth(dateTime));


        public static IEnumerable<DateMetaData> GetDateInformation(this DateTime dateTime)
            => GetDateInformation(new PersianDateTime(dateTime));


        public static IEnumerable<DateMetaData> GetDateInformation(this PersianDateTime persianDateTime)
            => persianDateTime.DateMetaDatas;


        public static List<PersianDateTime> GenerateYearlyCalender(int year)
        {
            List<PersianDateTime> persianDateTimes = new List<PersianDateTime>(366);
            var StartDate = ShamsiStartDateTimeOfPersianYear(year);
            var EndDate = ShamsiEndDateTimeOfPersianYear(year);
            PersianDateTime cursor = StartDate;
            while (cursor < EndDate)
            {
                persianDateTimes.Add(cursor.Copy());
                cursor = cursor.AddDays(1);
            }

            return persianDateTimes;
        }

        public static PersianDateTime Copy(this PersianDateTime persianDateTime)
        {
            return new PersianDateTime(persianDateTime.DateTime);
        }

        public static List<PersianDateTime> GenerateMonthlyCalender(int year, int month)
        {
            List<PersianDateTime> persianDateTimes = new List<PersianDateTime>();
            var StartDate = ShamsiStartDateTimeOfPersianMonth(year, month);
            var EndDate = ShamsiEndDateTimeOfMonth(year, month);
            while (StartDate < EndDate)
            {
                persianDateTimes.Add(StartDate++);
            }
            return persianDateTimes;
        }
        public static List<List<PersianDateTime>> GetContinuousHolidays(int year, int continuousDays)
        {
            List<PersianDateTime> yearData = GenerateYearlyCalender(year).FindAll(a => a.IsHoliDay || a.DateTime.DayOfWeek == System.DayOfWeek.Thursday);
            List<List<PersianDateTime>> persianDateTimes = new List<List<PersianDateTime>>();
            List<PersianDateTime> HoliDayList = new List<PersianDateTime>();
            int cnt = 0;
            for (int i = 0; i < yearData.Count; i++)
            {
                if (i != yearData.Count - 1 && DateDifference(yearData[i + 1], yearData[i]) == 1)
                {
                    HoliDayList.Add(yearData[i]);
                    cnt++;
                }

                else if (cnt >= continuousDays)
                {
                    HoliDayList.Add(yearData[i]);
                    persianDateTimes.Add(HoliDayList);
                    cnt = 0;
                    HoliDayList = new List<PersianDateTime>();
                }

                else
                {
                    cnt = 0;
                    HoliDayList = new List<PersianDateTime>();
                }
            }
            return persianDateTimes;
        }
        public static int GetWorkingDays(DateTime d1, DateTime d2)
        {
            return GetWorkingDays(new PersianDateTime(d1), new PersianDateTime(d2));
        }
        public static int GetWorkingDays(PersianDateTime startDate, PersianDateTime endDate)
        {

            if (startDate > endDate)
            {
                var tmp = startDate;
                startDate = endDate;
                endDate = tmp;
            }
            int Result = 0;
            while (startDate <= endDate)
            {
                if (!startDate.IsHoliDay && startDate.DateTime.DayOfWeek != System.DayOfWeek.Thursday)
                    Result++;
                startDate++;
            }
            return Result;
        }

        public static string GetHijriDate(this PersianDateTime persianDate)
        {
            return GetHijriDate(persianDate.DateTime);
        }
        public static string GetHijriDate(this DateTime theDate)
        {
            return $"{hijri.GetYear(theDate).ToString("00")}/{hijri.GetMonth(theDate).ToString("00")}/{hijri.GetDayOfMonth(theDate).ToString("00")}";
        }


        public static string GetDiffrenceToNow(this DateTime dt)
        {
            var Current = DateTime.Now;
            var ts = (Current - dt);
            string opr = "پیش";
            if (dt > DateTime.Now)
            {
                opr = "بعد";
                ts = dt - Current;
            }
            if (ts.TotalMinutes < 1)
                return "اکنون";
            if (ts.TotalMinutes < 60)
                return $"{ts.Minutes} دقیقه {opr}";
            if (ts.TotalDays < 1)
            {
                return $"{ts.Hours} ساعت و {ts.Minutes} دقیقه {opr}";
            }
            if (ts.TotalDays < 30)
            {
                return $"{ts.Days} روز و {ts.Hours} ساعت و {ts.Minutes} دقیقه {opr}";
            }
            if (ts.TotalDays > 30 && ts.TotalDays < 365)
            {
                var months = Math.Floor(ts.TotalDays / 30);
                var days = Math.Floor(ts.TotalDays % 30);
                return (months > 0 ? $"{months} ماه و " : String.Empty) +
                    (days > 0 ? $"{days} روز و " : String.Empty) +
                    (ts.Hours > 0 ? $"{ts.Hours} ساعت و " : String.Empty) +
                    (ts.Minutes > 0 ? $"{ts.Minutes} دقیقه " : String.Empty) + opr;
            }
            if (ts.TotalDays >= 365)
            {
                var year = Math.Floor(ts.TotalDays / 365);
                var months = Math.Floor(ts.TotalDays % 365 / 30);
                var days = Math.Floor(ts.TotalDays % 365 / 30);
                return (year > 0 ? $"{year} سال و " : String.Empty) +
                    (months > 0 ? $"{months} ماه و " : String.Empty) +
                    (days > 0 ? $"{days} روز و " : String.Empty) +
                    (ts.Hours > 0 ? $"{ts.Hours} ساعت و " : String.Empty) +
                    (ts.Minutes > 0 ? $"{ts.Minutes} دقیقه " : String.Empty) + opr;
            }
            return "نامشخص";
        }
        public static string GetDiffrenceToNow(this PersianDateTime dt) =>
            GetDiffrenceToNow(dt.DateTime);

        public static DateTime ToGregorianDateTime(this PersianDateTime dt) =>
              dt.DateTime;

        public static PersianDateTime ToShamsiDateTime(this DateTime dt) =>
              new PersianDateTime(dt);

    }
}
