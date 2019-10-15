using Microsoft.AspNetCore.Mvc;
using PersianTools.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersianTools.Web.Core3.Controllers
{
	[Route("api/[controller]")]
	public class DateController : Controller
	{
		[HttpGet("get-provinces")]
		public List<Province> GetProvinces()
		{
			return CityUtil.Instance.Provinces;
		}

		[HttpGet("get-cities/{provinceId}")]
		public List<City> GetCityList(int provinceId)
		{
			return CityUtil.Instance.Provinces.Find(a => a.ProvinceId == provinceId).Cities;
		}

		[HttpGet("calendar")]
		public List<PersianDateTime> Calendar()
		{
			var CurrentDate = PersianDateTime.Now;
			var MonthData = PersianDateTime.GenerateMonthlyCalender(CurrentDate.Year, CurrentDate.Month);
			return MonthData;
		}

		[HttpGet("holiday-data")]
		public List<List<PersianDateTime>> HoliDayDataView(string theDate)
		{
			string thedate = CharacterUtil.ConvertToEnglishDigit(theDate);
			//PersianDateTime.GetLongHoliDays(Convert.ToInt32(thedate.Substring(0, 4)));
			var result = PersianDateTime.GetLongHoliDays(Convert.ToInt32(thedate.Substring(0, 4)));
			foreach (var itemX in result)
			{
				foreach (var itemY in itemX)
				{
					if (itemY.DateMetaDatas.Count(a => a.IsHoliDay) == 0)
					{
						itemY.DateMetaDatas = new List<DateMetaData> { (new DateMetaData { Id = itemY.ToString("yyyy-MM-dd"), IsHoliDay = true, CalenderType = CalenderType.Jalali, DateType = DateType.HoliDay, Description = "تعطیلی آخر هفته" }) };
					}
				}
			}
			List<PersianDateTime> MainResult = new List<PersianDateTime>();
			foreach (List<PersianDateTime> item in result)
			{
				MainResult.AddRange(item);
			}
			return result;
		}
	}
}