using PersianTools.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
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
            PersianDateTime today = new PersianDateTime(1397,7,27);
            Assert.Equal("جمعه", today.DayOfWeek);
        }
        [Fact]
        public void CheckTwoConstructor()
        {
            PersianDateTime dt1 = new PersianDateTime(1399, 10, 13);
            PersianDateTime dt2 = new PersianDateTime("1399/10/13");
            Assert.Equal(dt1, dt2);
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
            var dt1 = new PersianDateTime(1399,12,29,23,30,10);
            var dt2 = new PersianDateTime("1399/12/29 23:30:10");
            Assert.Equal(dt1, dt2);
        }
        [Fact]
        public void CheckStartOfDay()
        {
            var dt1 = PersianDateTime.StartOfDay( new PersianDateTime("1399/12/29 23:30:20"));
            PersianDateTime dt2 = new PersianDateTime("1399/12/29 00:00:00");
            Assert.Equal(dt1, dt2);
        }
        [Fact]
        public void CheckEndOfDay()
        {
            var dt1 = PersianDateTime.EndOfDay(new PersianDateTime("1399/12/29 23:30:20"));
            PersianDateTime dt2 = new PersianDateTime(1399,12,29,23,59,59,999);
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
            var dt1 =  new PersianDateTime("1399/12/29");
            var dt2 = new PersianDateTime("1399/11/29");
            Assert.Equal(30,Convert.ToInt32(PersianDateTime.DateDifference(dt1,dt2)));
        }
        [Fact]
        public void CheckEndOfYear()
        {
            var d1 = PersianDateTime.EndOfYearPersianDateTime(1397);
            Assert.Equal(new PersianDateTime(1397,12,29,23,59,59,999), d1);
        }
        [Fact]
        public void CheckEndOfLeapYear()
        {
            var d1 = PersianDateTime.EndOfYearPersianDateTime(1399);
            Assert.Equal(new PersianDateTime(1399, 12, 30, 23, 59, 59, 999), d1);
        }
        [Fact]
        public void CheckEndOfMonth()
        {
            var d1 = PersianDateTime.EndDateOfMonth(1397,12);
            Assert.Equal(new PersianDateTime(1397, 12, 29, 23, 59, 59, 999), d1);
        }
        [Fact]
        public void CheckEndOfMonth1()
        {
            var d1 = PersianDateTime.EndDateOfMonth(1399,12);
            Assert.Equal(new PersianDateTime(1399, 12, 30, 23, 59, 59, 999), d1);
        }
        [Fact]
        public void CheckToLongStringHMS()
        {
            var d1 = PersianDateTime.EndDateOfMonth(1399, 12).ToLongStringHMS().Replace(" ", "");
            string time = "ساعت بیست و سه و پنجاه و نه دقیقه و پنجاه و نه ثانیه".Replace(" ","");
            Assert.Equal(time, d1);
        }
        [Fact]
        public void CheckToLongStringHM()
        {
            var d1 = new PersianDateTime(1399, 12, 30, 23,59).ToLongStringHM().Replace(" ", "");
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
            var str=d1.GetDateData();
            Assert.True(d1.IsHoliDay);
            //var x2 = PersianDateTime.GetLongHoliDays(1398); 
        }
        [Fact]
        public void CheckWorkingDays()
        {
            var d1 = new PersianDateTime(1397, 8, 1);
            var d2 = new PersianDateTime(1397, 8, 30);
            Assert.Equal(20,PersianDateTime.GetWorkingDays(d1,d2));
        }
        [Fact]
        public void MyTestMethod()
        {
            var x3 = PersianDateTime.GetDiffrenceToNow(DateTime.UtcNow.AddDays(-1365));
            var d1 = new PersianDateTime(1397, 2, 30);
            var str=d1.ToString("YYYY/mm/dd");
            d1 = new PersianDateTime(1397, 6, 31);
            str= d1.ToString("yyyy/MM/dd h:mm tt");
            str = d1.ToString("dddd, dd MMMM yyyy");
            str = d1.ToString("dddd, dd MMMM yyyy HH:mm");
            str = d1.ToString("yyyy/MM/dd HH:mm");
            str = d1.ToString("yyyy/MM/dd HH:mm:ss");
            string s=""; 
            var dn = PersianDateTime.GenerateYearlyCalender(1375);
            var item = d1.DateMetaDatas;
            DateTime date = DateTime.Now;
            var dt2 = new PersianDateTime("1399/11/29");
            var y1 = PersianDateTime.GetHijriDate(dt2);
            var y = PersianDateTime.GetHijriDate(DateTime.UtcNow);
            var x=PersianDateTime.GetDiffrenceToNow(DateTime.UtcNow);
            var x1 = PersianDateTime.GetDiffrenceToNow(DateTime.UtcNow.AddDays(-10));
            var x2 = PersianDateTime.GetDiffrenceToNow(DateTime.UtcNow.AddDays(-100));
            //var x3 = PersianDateTime.GetDiffrenceToNow(DateTime.UtcNow.AddDays(-1365));
            var x4 = PersianDateTime.GetDiffrenceToNow(DateTime.UtcNow.AddDays(365));
            var x5 = PersianDateTime.GetDiffrenceToNow(DateTime.UtcNow.AddDays(10));
            var x6 = PersianDateTime.GetDiffrenceToNow(DateTime.UtcNow.AddDays(100));
            var x7 = PersianDateTime.GetDiffrenceToNow(DateTime.Now);
            var x9 = new PersianDateTime(1397, 1, 1);
            //var y7 = y6.AddWeeks(5);
            //var y8 = y7.AddYears(-5);
            //var y9 = y8.AddMonths(18);
            //var n = y8.ToLongStringHMS();
            //var n1 = y7.ToLongStringYMD();
            //var n2 = x4.ToLongStringYMDHM();
            //var n3 = x3.ToLongStringYMDHMS(); 

        }
    }
}
