using PersianTools.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PersianTools.Test
{
    public class DateTimeTest
    {
        [Fact]
        public void Test1()
        {
            DateTime dateTime = DateTime.Now;
            PersianDateTime persianDateTime = new PersianDateTime(dateTime);
            string s=persianDateTime.DayOfWeek;
            PersianDateTime persianDateTime1 = new PersianDateTime(1399,10,13);
            PersianDateTime persianDateTime2 = new PersianDateTime("1399/12/29");
            string ss= persianDateTime2.ToString();
            var x=PersianDateTime.UtcNow;
            var x1 = PersianDateTime.StartOfDay(DateTime.Now);
            var x2 = PersianDateTime.EndOfDay(DateTime.Now);
            var x3 = PersianDateTime.StartOfDay(persianDateTime2);
            var x4 = PersianDateTime.EndOfDay(persianDateTime1);
            var y = Convert.ToInt32(x);
            var y1 = x == x1;
            var y2 =PersianDateTime.DateDifference( x1 , x);
            var y3 = x.AddDays(1);
            var y4 = PersianDateTime.EndOfYearPersianDateTime(1397);
            var y6 = PersianDateTime.EndOfYearPersianDateTime(1399);
            var y7 = y6.AddWeeks(5);
            var y8 = y7.AddYears(-5);
            var y9 = y8.AddMonths (18);
            var n = y8.ToLongStringHMS();
            var n1 = y7.ToLongStringYMD();
            var n2 = x4.ToLongStringYMDHM();
            var n3 = x3.ToLongStringYMDHMS();
            var n4 = PersianDateTime.EndDateOfMonth(1396, 12);
            var n5 = PersianDateTime.EndDateOfMonth(1399, 12);
 
        }
    }
}
