<div dir="rtl" style="font-family: tahoma;">
<h1 style="color: #5e9ca0;"><span style="color: #000000;">ابزار Persian Tools</span></h1>
<p>ابزار Persian Tool یک Library است که در پروژه هایی که روی Dot Net Framework و Dot Net Standard و Dot Net Core نوشته شده اند قابل استفاده است</p>
 <h2 style="color: #000000;"><span style="color: #000000;">ویژگی های موجود در ابزار Persian Tools:</span></h2>
 <ul>
 <li><span style="color: #800000;"><strong>تبدیل اعداد به حروف</strong></span></li>
 <li><span style="color: #800000;"><strong>نوع داده ای تاریخ شمسی و تبدیل تاریخ</strong></span></li>
 <li><span style="color: #800000;"><strong>لیست شهرها و استان های ایران</strong></span></li>
 <li><span style="color: #800000;"><strong>Custom Validations</strong></span></li>
<li><span style="color: #800000;"><strong>Model Binders</strong></span>&nbsp; &nbsp; &nbsp;</li>
</ul>
	
<h2 style="font-family: tahoma;">برخی از امکانات پروژه:</h2>

<p>1- لیست مناسبت های یک روز</p>

<p><img alt="لیست مناسبتهای یک روز" src="http://s8.picofile.com/file/8346033392/cal1.PNG" style="width: 1092px; height: 530px;" /></p>

<p style="font-family: tahoma;">2- لیست تعطیلات پشت سر هم یک سال شمسی</p>

<p style="font-family: tahoma;"><img alt="لیست تعطیلات پشت سر هم یک سال شمسی" src="http://s8.picofile.com/file/8346033426/cal2.PNG" style="width: 1090px; height: 620px;" /></p>
<h2 style="color: #2e6c80;">نحوه استفاده:</h2>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<table class="editorDemoTable" style="height: 821px; width: 658px;">
<thead>
<tr style="height: 21px;">
 <td style="width: 79.2px; height: 21px; text-align: center;">نام ویژگی</td>
 <td style="width: 451.2px; height: 21px; text-align: center;">نحوه استفاده</td>
 <td style="width: 101.6px; height: 21px;">خروجی</td>
 </tr>
 </thead>
 <tbody>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">تبدیل اعداد به حروف</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">&nbsp;PersianTools.Core.CharacterUtil.Convert(11200000)</td>
 <td style="width: 101.6px; height: 40.8px;">یازده میلیون و دویست هزار&nbsp;</td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">انواع روشهای تعریف تاریخ شمسی</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">
 <p>var dt1 = new PersianDateTime(1399, 10, 13);</p>
 </td>
 <td style="width: 101.6px; height: 40.8px;"><br /><br /></td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">انواع روشهای تعریف تاریخ شمسی</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">var dt2 = new PersianDateTime("1399/10/13");</td>
 <td style="width: 101.6px; height: 40.8px;"><br /><br /></td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">انواع روشهای تعریف تاریخ شمسی</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: center;">
 <p style="text-align: left;">var dt1 = new PersianDateTime("1399/12/29 23:30");</p>
 <p style="text-align: left;"><br /> var dt2 = new PersianDateTime("1399/12/29 23:30:00");</p>
 </td>
 <td style="width: 101.6px; height: 40.8px;"><br /><br /></td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">انواع روشهای تعریف تاریخ شمسی</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: center;">
 <p style="text-align: left;">var dt1 = new PersianDateTime("1399/12/29 23:30");</p>
 <p style="text-align: left;"><br /> var dt2 = new PersianDateTime("1399/12/29 23:30:00");</p>
 </td>
 <td style="width: 101.6px; height: 40.8px;"><br /><br /></td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">انواع روشهای تعریف تاریخ شمسی</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: center;">
 <p style="text-align: left;">var dt1 = new PersianDateTime(1399,12,29,23,30,10);<br /> var dt2 = new PersianDateTime("1399/12/29 23:30:10");</p>
 </td>
 <td style="width: 101.6px; height: 40.8px;">&nbsp;</td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">تعریف بر اساس تاریخ میلادی</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: center;">
 <p style="text-align: left;">DateTime dateTime = DateTime.Now;<br /> var persianDateTime = new PersianDateTime(dateTime);</p>
 </td>
 <td style="width: 101.6px; height: 40.8px;">&nbsp;</td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">ابتدای روز</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: center;">
 <p style="text-align: left;">var dt1 = PersianDateTime.StartOfDay( new PersianDateTime("1399/12/29 23:30:20"));</p>
 </td>
 <td style="width: 101.6px; height: 40.8px;">1399/12/29 00:00:00</td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">انتهای روز</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">&nbsp;var dt1 = PersianDateTime.EndOfDay(new PersianDateTime("1399/12/29 23:30:20"));</td>
 <td style="width: 101.6px; height: 40.8px; text-align: left;">1399/12/29 23:59:59</td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">فاصله دو تاریخ</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">var dt1 = new PersianDateTime("1399/12/29");<br /> var dt2 = new PersianDateTime("1399/11/29");<br />Convert.ToInt32(PersianDateTime.DateDifference(dt1,dt2));</td>
 <td style="width: 101.6px; height: 40.8px; text-align: left;">30</td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">آخرین روز سال</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">
 <p>var d1 = PersianDateExtensions.ShamsiEndDateTimeOfPersianYear(1397);</p>
 <p>var d2 = PersianDateExtensions.ShamsiEndDateTimeOfPersianYear(1399);</p>
 </td>
 <td style="width: 101.6px; height: 40.8px; text-align: left;">
 <p>1397/12/29</p>
 <p>&nbsp;1399/12/30</p>
 </td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">آخرین روز ماه</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">
 <p>var d1 = PersianDateExtensions.ShamsiEndDateTimeOfMonth(1397,12);</p>
 <p>var d1 = PersianDateExtensions.ShamsiEndDateTimeOfMonth(1399,12);</p>
 </td>
 <td style="width: 101.6px; height: 40.8px; text-align: left;">
 <p>1397/12/29&nbsp;</p>
 <p>1399/12/30&nbsp;</p>
 </td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">تولید ساعت</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">var d1 = PersianDateTime.Now.ToLongStringHMS();</td>
 <td style="width: 101.6px; height: 40.8px; text-align: left;">ساعت بیست و سه و پنجاه و نه دقیقه و پنجاه و نه ثانیه&nbsp;</td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">تولید ساعت</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">var d1 = PersianDateTime.Now.ToLongStringHM();</td>
 <td style="width: 101.6px; height: 40.8px; text-align: left;">ساعت بیست و سه و پنجاه و نه دقیقه</td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">تولید تاریخ</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">&nbsp;var d1 = PersianDateTime.Now.ToLongStringYMD();</td>
 <td style="width: 101.6px; height: 40.8px; text-align: left;">جمعه بیست و هفت مهر سال یکهزار و سیصد و نود و هفت&nbsp;</td>
 </tr>
 <tr style="height: 40.8px;">
 <td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">اعتبارسنجی شماره موبایل</span></td>
 <td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">
 <p>[MobileNo]</p>
 <p>public string MobNo;</p>
 </td>
<td style="width: 101.6px; height: 40.8px; text-align: left;"><br /><br /></td>
</tr>
<tr style="height: 40.8px;">
<td style="width: 79.2px; height: 40.8px; text-align: center;">&nbsp;</td>
<td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: center;">در حال تکمیل</td>
<td style="width: 101.6px; height: 40.8px;">&nbsp;</td>
<td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">فاصله دو تاریخ</span></td>
<td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">ar dt1 = new PersianDateTime("1399/12/29");<br /> var dt2 = new PersianDateTime("1399/11/29");<br />Convert.ToInt32(PersianDateTime.DateDifference(dt1,dt2));</td>
<td style="width: 101.6px; height: 40.8px;">30&nbsp;</td>
</tr>
<tr style="height: 40.8px;">
<td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">فاصله یک تاریخ تا امروز</span></td>
<td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">PersianDateTime.GetDiffrenceToNow(DateTime.UtcNow.AddDays(-1365));</td>
<td style="width: 101.6px; height: 40.8px;">3 سال و 9 ماه و 9 روز و 3 ساعت و 30 دقیقه پیش</td>
</tr>
<tr style="height: 40.8px;">
<td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">دریافت تاریخ قمری&nbsp;</span></td>
<td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">
<p>var dt2 = new PersianDateTime("1399/11/29");</p>
<p>PersianDateTime.GetHijriDate(dt2 );</p>
</td>
<td style="width: 101.6px; height: 40.8px;">1442/07/06</td>
</tr>
<tr style="height: 40.8px;">
<td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">تولید تقویم یکساله شمسی</span></td>
<td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">
<p>var Cal= PersianDateTime.GenerateYearlyCalender(1375);</p>
</td>
<td style="width: 101.6px; height: 40.8px;">لیستی از روزهای سال و مناسبتها هر روز</td>
</tr>
<tr style="height: 40.8px;">
<td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">دریافت لیست تعطیلیهای بیش از دو روز در تقویم</span></td>
<td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">
<p>var x2 = PersianDateTime.GetLongHoliDays(1398);</p>
</td>
<td style="width: 101.6px; height: 40.8px;">لیستی از تعطیلات مناسب سال</td>
</tr>
<tr style="height: 40.8px;">
<td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">تعداد روزهای کاری در یک بازه تاریخی</span></td>
<td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">
<p>var d1 = new PersianDateTime(1397, 8, 1);<br /> var d2 = new PersianDateTime(1397, 8, 30);<br />PersianDateTime.GetWorkingDays(d1,d2);</p>
</td>
<td style="width: 101.6px; height: 40.8px;">20</td>
</tr>
</tbody>
</table>
<h2>&nbsp;اضافه شده تعطیلات و مناسب های شمسی، قمری و میلادی به پروژه</h2>
<p>در جهت پوشش همه مناسبتهای موجود در تقویم هجری شمسی ( شامل مناسبت های شمسی، قمری و میلادی) این مناسبتها به این کتابخانه اضافه گردید که نحوه استفاده از آن بدین شکل می باشد:</p>
<p><strong>تعریف یک نمونه متغیر از جنس تاریخ شمسی :</strong></p>
<p dir="ltr">var persianDateTime= new PersianDateTime(1397,3,1);</p>
<p dir="rtl" style="text-align: right;"><strong>نحوه دریافت مناسبتهای یک تاریخ:</strong></p>
<p dir="ltr" style="text-align: left;">persianDateTime.GetDateData();</p>
<p dir="rtl" style="text-align: right;"><strong>خروجی:</strong></p>
<p dir="rtl" style="text-align: right;">روز بهره وری و بهینه سازی مصرف - روز بزرگداشت ملاصدرا -</p>
<p dir="rtl" style="text-align: right;">برای هر تاریخ یک ویژگی به نام IsHoliDay وجود دارد که مشخص می کند روز انتخاب شده تعطیل می باشد یا خیر.</p>
<p dir="rtl" style="text-align: right;">ممکن است برای تاریخ خاصی بیش از یک رویداد وجود داشته باشد که می توان از&nbsp;DateMetaDatas استفاده کرد، که در آن لیستی از مناسبتهای تاریخ وجود دارد علاوه بر این مشخص شده است:</p>
<ol>
<li dir="rtl" style="text-align: right;">این مناسبت تعطیل است یا خیر؟</li>
<li dir="rtl" style="text-align: right;">مناسبت شمسی، قمری یا میلادی است</li>
<li dir="rtl" style="text-align: right;">نوع مناسبت ملی، بین المللی یا مذهبی است</li>
</ol>
<p>&nbsp;سایر قابلیت ها:</p>
<ol>
<li>محاسبه تعداد روزهای کاری در یک بازه تاریخی</li>
<li>نمایش لیستی از روزهای تعطیل و دارای مناسبت در سال و امکان انجام فیلتر بر روی لیست روزها</li>
<li>تابع ایجاد لیست روزهای متوالی بیش از 3 روز تعطیل در یک سال</li>
</ol>
</div>
