using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersianTools.Core;

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
	}
}