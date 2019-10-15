using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PersianTools.Core
{
	public static class PersianHelper
	{
		private const string PersianDatePattern = @"^$|^([1][0-9]{3}[/\/]([0][1-6])[/\/]([0][1-9]|[12][0-9]|[3][01])|[1][0-9]{3}[/\/]([0][7-9]|[1][012])[/\/]([0][1-9]|[12][0-9]|(30)))$";
		const string MobPattern = @"^((\+9|\+989|\+\+989|9|09|989|0989|00989)(01|02|03|10|11|12|13|14|15|16|17|18|19|20|21|22|30|31|32|33|34|35|36|37|38|39|90))(\d{7})$";
		private const string TimePattern = @"^((([0-1]?[0-9])|(2[0-3]):[0-5]?[0-9])|(([0-1]?[0-9])|(2[0-3]):[0-5]?[0-9]:[0-5]?[0-9]))$";
		/// <summary>
		/// https://www.dotnettips.info/post/1097/
		/// </summary>
		/// <param name="nationalCode"></param>
		/// <returns></returns>
		public static Boolean IsValidNationalCode(this String nationalCode)
		{
			//در صورتی که کد ملی وارد شده تهی باشد

			if (String.IsNullOrEmpty(nationalCode))
				throw new ArgumentException("لطفا کد ملی را صحیح وارد نمایید");


			//در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
			if (nationalCode.Length != 10)
				throw new Exception("طول کد ملی باید ده کاراکتر باشد");

			//در صورتی که کد ملی ده رقم عددی نباشد
			var regex = new Regex(@"\d{10}");
			if (!regex.IsMatch(nationalCode))
				throw new Exception("کد ملی تشکیل شده از ده رقم عددی می‌باشد؛ لطفا کد ملی را صحیح وارد نمایید");

			//در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
			var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
			if (allDigitEqual.Contains(nationalCode)) return false;


			//عملیات شرح داده شده در بالا
			var chArray = nationalCode.ToCharArray();
			var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
			var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
			var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
			var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
			var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
			var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
			var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
			var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
			var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
			var a = Convert.ToInt32(chArray[9].ToString());

			var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
			var c = b % 11;

			return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
		}
		public static Boolean IsMobileNoValid(this string mobileNo)
		{
			return Regex.IsMatch(mobileNo, MobPattern);

		}
		public static Boolean IsPersianDateValid(this string persianDate)
		{
			return Regex.IsMatch(persianDate, PersianDatePattern);
		}
		public static Boolean IsPersianDateValid(this PersianDateTime persianDate)
		{
			return Regex.IsMatch(persianDate.ToString(), PersianDatePattern);
		}
		public static Boolean IsTimeValid(this string time)
		{
			return Regex.IsMatch(time, TimePattern);
		}
	}
}
