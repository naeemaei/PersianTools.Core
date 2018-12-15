using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PersianTools.Core;
namespace PersianTools.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ViewResult Calendar()
        {
            var CurrentDate = PersianDateTime.Now;
            ViewBag.CurrentDate = CurrentDate;
            var MonthData = PersianDateTime.GenerateMonthlyCalender(CurrentDate.Year, CurrentDate.Month);
            return View();
        }
        public ViewResult PersianDateUtil()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult DateDataView(string theDate)
        {
            string thedate = CharacterUtil.ConvertToEnglishDigit(theDate);
            PersianDateTime persianDateTime = new PersianDateTime(thedate);
            return PartialView("_DateDataView", persianDateTime);
        }
        //private List<PersianDateTime> GetMonthData(int year, int month)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    StringBuilder sb2 = new StringBuilder();
        //    var monthData= PersianDateTime.GenerateMonthlyCalender(year, month);
        //    var MonthFirstDate = PersianDateTime.SrartDateOfMonth(year, month);
        //    var MonthLastDate = PersianDateTime.EndDateOfMonth(year, month);
        //    for (int i = 0; i < MonthFirstDate.DateTime.DayOfWeek.GetHashCode()- DayOfWeek.Saturday.GetHashCode(); i++)
        //    {
        //        sb2.Append("<td class='calendar__day__cell'></td>");
        //    }
        //    foreach (var item in monthData)
        //    {
        //        if(item.DateTime.DayOfWeek==DayOfWeek.Saturday)
        //        {
        //            sb.Append("<tr>");
        //        }
        //        if (item.DateTime.DayOfWeek == DayOfWeek.Friday)
        //        {
        //            sb.Append("</tr>");
        //        }
        //    }
        //}
    }
}