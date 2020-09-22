using PersianTools.Core;
using System;
using System.Globalization;
using System.Linq;
using Xunit;

namespace PersianTools.Test
{
    public class DateTimeTest
    {
        PersianCalendar pc;
        public DateTimeTest()
        {
            pc = new PersianCalendar();
        }

        [Fact]
        public void CheckGeneratedDateTimeIsCorrect()
        {
            DateTime dateTime = DateTime.Now;
            PersianDateTime persianDateTime = new PersianDateTime(dateTime);
            Assert.Equal(pc.GetYear(dateTime), persianDateTime.Year);
            Assert.Equal(pc.GetMonth(dateTime), persianDateTime.Month);
            Assert.Equal(pc.GetDayOfMonth(dateTime), persianDateTime.Day);
            Assert.Equal(pc.GetHour(dateTime), persianDateTime.Hour);
            Assert.Equal(pc.GetMinute(dateTime), persianDateTime.Minute);
            Assert.Equal(pc.GetSecond(dateTime), persianDateTime.Second);
        }
        [Fact]
        public void CheckDayOfWeek()
        {
            PersianDateTime today = new PersianDateTime(1397, 7, 27);
            Assert.Equal("جمعه", today.DayOfWeek);
        }
        [Fact]
        public void CheckTwoConstructor()
        {
            PersianDateTime dt1 = new PersianDateTime(1399, 10, 13);
            PersianDateTime dt2 = new PersianDateTime("1399/10/13");
            Assert.True(dt1 == dt2);
        }
        [Fact]
        public void CheckTwoConstructor2()
        {
            var dt1 = new PersianDateTime("1399/12/29 23:30");
            var dt2 = new PersianDateTime("1399/12/29 23:30:00");
            Assert.Equal(dt1, dt2);
        }
        [Fact]
        public void CheckTwoConstructor3()
        {
            var dt1 = new PersianDateTime(1399, 12, 29, 23, 30, 10);
            var dt2 = new PersianDateTime("1399/12/29 23:30:10");
            Assert.Equal(dt1, dt2);
        }
        [Fact]
        public void CheckStartOfDay()
        {
            var dt1 = new PersianDateTime("1399/12/29 23:30:20").ShamsiStartDateTimeOfDay();
            PersianDateTime dt2 = new PersianDateTime("1399/12/29 00:00:00");
            Assert.Equal(dt1, dt2);
        }
        [Fact]
        public void CheckEndOfDay()
        {
            var dt1 = new PersianDateTime("1399/12/29 23:30:20").ShamsiEndDateTimeOfDay();
            PersianDateTime dt2 = new PersianDateTime(1399, 12, 29, 23, 59, 59, 999);
            Assert.Equal(dt1, dt2);
        }
        [Fact]
        public void CheckDateToInt()
        {
            int dt1 = Convert.ToInt32(new PersianDateTime("1399/12/29 23:30:20"));
            int dt2 = 13991229;
            Assert.Equal(dt1, dt2);
        }
        [Fact]
        public void CheckDateDiff()
        {
            var dt1 = new PersianDateTime("1399/12/29");
            var dt2 = new PersianDateTime("1399/11/29");
            Assert.Equal(30, Convert.ToInt32(PersianDateExtensions.DateDifference(dt1, dt2)));
        }
        [Fact]
        public void CheckEndOfYear()
        {
            var d1 = PersianDateExtensions.ShamsiEndDateTimeOfPersianYear(1397);
            Assert.Equal(new PersianDateTime(1397, 12, 29, 23, 59, 59, 999), d1);
        }
        [Fact]
        public void CheckEndOfLeapYear()
        {
            var d1 = PersianDateExtensions.ShamsiEndDateTimeOfPersianYear(1399);
            Assert.Equal(new PersianDateTime(1399, 12, 30, 23, 59, 59, 999), d1);
        }
        [Fact]
        public void CheckEndOfMonth()
        {
            var d1 = PersianDateExtensions.ShamsiEndDateTimeOfMonth(1397, 12);
            Assert.Equal(new PersianDateTime(1397, 12, 29, 23, 59, 59, 999), d1);
        }
        [Fact]
        public void CheckEndOfMonth1()
        {
            var d1 = PersianDateExtensions.ShamsiEndDateTimeOfMonth(1399, 12);
            Assert.Equal(new PersianDateTime(1399, 12, 30, 23, 59, 59, 999), d1);
        }
        [Fact]
        public void CheckToLongStringHMS()
        {
            var d1 = PersianDateExtensions.ShamsiEndDateTimeOfMonth(1399, 12).ToLongStringHMS().Replace(" ", "");
            string time = "ساعت بیست و سه و پنجاه و نه دقیقه و پنجاه و نه ثانیه".Replace(" ", "");
            Assert.Equal(time, d1);
        }
        [Fact]
        public void CheckToLongStringHM()
        {
            var d1 = new PersianDateTime(1399, 12, 30, 23, 59).ToLongStringHM().Replace(" ", "");
            string time = "ساعت بیست و سه و پنجاه و نه دقیقه".Replace(" ", "");
            Assert.Equal(time, d1);
        }
        [Fact]
        public void CheckToLongStringYMD()
        {
            var d1 = new PersianDateTime(1397, 7, 27).ToLongStringYMD().Replace(" ", "");
            string time = "جمعه بیست و هفت مهر سال یکهزار و سیصد و نود و هفت".Replace(" ", "");
            Assert.Equal(time, d1);
        }
        [Fact]
        public void CheckHoliDays()
        {
            var d1 = new PersianDateTime(1397, 3, 14);
            var str = d1.GetDateInformation();
            Assert.True(d1.IsHoliDay);
            //var x2 = PersianDateTime.GetLongHoliDays(1398); 
        }
        [Fact]
        public void CheckWorkingDays()
        {
            var d1 = new PersianDateTime(1397, 8, 1);
            var d2 = new PersianDateTime(1397, 8, 30);
            Assert.Equal(20, PersianDateExtensions.GetWorkingDays(d1, d2));
        }
        [Fact]
        public void MyTestMethod()
        {
            var x3 = DateTime.UtcNow.AddDays(-1365).GetDiffrenceToNow();
            var d1 = new PersianDateTime(1397, 5, 31);
            var d2 = new PersianDateTime(1397, 6, 8);
            var d3 = new PersianDateTime(1399, 6, 7);
            var d4 = new PersianDateTime(1410, 10, 24);
            var str = d1.ToString("YYYY/mm/dd");
            d1 = new PersianDateTime(1397, 6, 31);
            str = d1.ToString("yyyy/MM/dd h:mm tt");
            str = d1.ToString("dddd, dd MMMM yyyy");
            str = d1.ToString("dddd, dd MMMM yyyy HH:mm");
            str = d1.ToString("yyyy/MM/dd HH:mm");
            str = d1.ToString("yyyy/MM/dd HH:mm:ss");

            var dn = PersianDateExtensions.GenerateYearlyCalender(1375);
            var item = d1.DateMetaDatas;
            DateTime date = DateTime.Now;
            var dt2 = new PersianDateTime("1399/11/29");
            var y1 = dt2.GetHijriDate();
            var y = DateTime.UtcNow.GetHijriDate();
            var x = DateTime.UtcNow.GetDiffrenceToNow();
            var x1 = DateTime.UtcNow.AddDays(-10).GetDiffrenceToNow();
            var x2 = DateTime.UtcNow.AddDays(-100).GetDiffrenceToNow();
            //var x3 = PersianDateTime.GetDiffrenceToNow(DateTime.UtcNow.AddDays(-1365));
            var x4 = DateTime.UtcNow.AddDays(365).GetDiffrenceToNow();
            var x5 = DateTime.UtcNow.AddDays(10).GetDiffrenceToNow();
            var x6 = DateTime.UtcNow.AddDays(100).GetDiffrenceToNow();
            var x7 = DateTime.Now.GetDiffrenceToNow();
            var x9 = new PersianDateTime(1397, 1, 1);
            //var y7 = y6.AddWeeks(5);
            //var y8 = y7.AddYears(-5);
            //var y9 = y8.AddMonths(18);
            //var n = y8.ToLongStringHMS();
            //var n1 = y7.ToLongStringYMD();
            //var n2 = x4.ToLongStringYMDHM();
            //var n3 = x3.ToLongStringYMDHMS(); 

        }

        [Fact]
        public void hijri_1395_1396()
        {
            var theDate = new PersianDateTime(1395, 7, 20);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1395, 7, 21);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1395, 8, 30);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1395, 9, 8);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1395, 9, 27);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1395, 12, 12);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 1, 22);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 2, 5);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 2, 22);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 3, 26);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 4, 5);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 4, 6);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 4, 29);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 6, 10);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 6, 18);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

        }

        [Fact]
        public void hijri_1396_1397()
        {
            var theDate = new PersianDateTime(1396, 7, 8);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 7, 9);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 8, 18);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 8, 26);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 9, 15);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1396, 12, 1);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 1, 11);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 1, 25);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 2, 12);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 3, 16);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 3, 25);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 3, 26);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 4, 18);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 5, 21);
            Assert.True(CheckHijriDay(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 5, 31);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 6, 8);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

        }

        [Fact]
        public void hijri_1397_1398()
        {
            var theDate = new PersianDateTime(1397, 6, 28);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 6, 29);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 8, 8);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 8, 16);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 9, 4);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 10, 22);
            Assert.True(CheckHijriDay(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 11, 20);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1397, 12, 29);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 1, 14);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 2, 1);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 3, 6);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 3, 15);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 3, 16);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 4, 8);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 5, 21);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 5, 29);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

        }

        [Fact]
        public void hijri_1398_1399()
        {
            var theDate = new PersianDateTime(1398, 6, 18);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 6, 19);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 7, 27);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 8, 5);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 8, 24);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 11, 9);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1398, 12, 18);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 1, 3);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 1, 21);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 2, 26);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 3, 4);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 3, 5);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 3, 28);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 5, 10);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 5, 18);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));
        }

        [Fact]
        public void hijri_1399_1400()
        {
            var theDate = new PersianDateTime(1399, 6, 8);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 6, 9);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 7, 17);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 7, 25);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 8, 13);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 10, 28);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 12, 7);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1399, 12, 21);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1400, 1, 9);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1400, 2, 14);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1400, 2, 24);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1400, 2, 25);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1400, 3, 17);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1400, 4, 30);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1400, 5, 7);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1400, 5, 27);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

            theDate = new PersianDateTime(1400, 5, 28);
            Assert.True(CheckHijriHolyday(theDate), CombineDates(theDate));

        }

        private string CombineDates(PersianDateTime persianDate) =>
            $"{persianDate.ToString("yyyy/MM/dd")} - {persianDate.HijriDate.Year}/{persianDate.HijriDate.Month}/{persianDate.HijriDate.Day}";

        private bool CheckHolyday(PersianDateTime persianDate) =>
            persianDate.IsHoliDay;

        private bool CheckHijriHolyday(PersianDateTime persianDate) =>
            persianDate.IsHoliDay && persianDate.DateMetaDatas.Any(d => d.DateType == DateType.HoliDay && d.CalenderType == CalenderType.Hijri);

        private bool CheckHijriDay(PersianDateTime persianDate) =>
            persianDate.DateMetaDatas.Any(d => d.CalenderType == CalenderType.Hijri);

    }
}
