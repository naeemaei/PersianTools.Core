using System;
using System.Globalization;

namespace PersianTools.Core
{
	public static class PersianDateTimeUtil
	{
		private readonly static PersianCalendar _persianCalendar = new PersianCalendar();
		public static DateTime EndOfDay(this DateTime dateTime) =>
			 new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, DateTimeKind.Local);
		public static DateTime StartOfDay(this DateTime dateTime) =>
			new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, DateTimeKind.Local);
	}
}
