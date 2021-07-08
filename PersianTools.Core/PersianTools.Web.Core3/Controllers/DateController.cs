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
            var MonthData = PersianDateExtensions.GenerateMonthlyCalender(CurrentDate.Year, CurrentDate.Month);
            return MonthData;
        }

        [HttpGet("get-day-info")]
        public IEnumerable<DateMetaData> GetDayInformation(string persianDate)
        {
            return new PersianDateTime(persianDate).GetDateInformation();
        }

        [HttpGet("get-year-holiday-info")]
        public List<List<PersianDateTime>> GetYearHoliDayInformation(int year)
        {
            var result = PersianDateExtensions.GetContinuousHolidays(year, 3);
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
            List<PersianDateTime> mainResult = new List<PersianDateTime>();
            foreach (List<PersianDateTime> item in result)
            {
                mainResult.AddRange(item);
            }
            return result;
        }
    }
}