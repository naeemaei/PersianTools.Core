using System;
using System.Globalization;

namespace PersianTools.Core
{
    internal static class HijriCalendarManager
    {
        private static readonly HijriCalendar hijri = new() { HijriAdjustment = -1 };

        internal static HijriCalendar GetHijriCalendar()
        {
            return hijri;
        }
        internal static HijriCalendar SetHijriCalendar(DateTime datetime)
        {
            var day = hijri.GetDayOfMonth(datetime);
            var month = hijri.GetMonth(datetime);
            var year = hijri.GetYear(datetime);

            switch (year)
            {
                case 1438: /* 1395 */
                    hijri.HijriAdjustment = -1;

                    if (month == 2 || month == 12)
                        hijri.HijriAdjustment = 0;

                    else if (month == 7)
                        hijri.HijriAdjustment = -2;

                    break;

                case 1439: /* 1396 */
                    hijri.HijriAdjustment = -1;

                    if (month == 2)
                        hijri.HijriAdjustment = 0;

                    else if ((month == 9 && day == 30))
                        hijri.HijriAdjustment = -1;

                    else if ((month >= 6 && month <= 9) || month == 11)
                        hijri.HijriAdjustment = -2;

                    break;

                case 1440: /* 1397 */
                    hijri.HijriAdjustment = 0;

                    if (month == 9)
                        hijri.HijriAdjustment = -2;

                    else if (month >= 5)
                        hijri.HijriAdjustment = -1;

                    break;

                case 1441: /* 1398 */
                    hijri.HijriAdjustment = -1;

                    if (month == 2)
                        hijri.HijriAdjustment = 0;

                    else if (month == 9 && day < 30)
                        hijri.HijriAdjustment = -2;

                    break;

                case 1442: /* 1399 */
                    hijri.HijriAdjustment = -2;

                    if (month == 9 && day < 29)
                        hijri.HijriAdjustment = -2;

                    else if (month >= 2 && month < 12)
                        hijri.HijriAdjustment = -1;
                    break;

                case 1443: /* 1400 */
                    hijri.HijriAdjustment = -1;
                    if (month == 2 && day > 15 && day <= 28)
                        hijri.HijriAdjustment = 0;

                    else if (month == 2 && day > 28)
                        hijri.HijriAdjustment = -1;

                    else if (month == 3 && day > 28)
                        hijri.HijriAdjustment = 0;

                    else if (month >= 6 && month != 7)
                        hijri.HijriAdjustment = 0;
                    break;

                default:
                    hijri.HijriAdjustment = -1;
                    break;

            }

            return hijri;
        }
    }
}
