

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
<h2 style="color: #2e6c80;">نحوه استفاده:</h2>
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
<p>var d1 = PersianDateTime.EndOfYearPersianDateTime(1397);</p>
<p>var d2 = PersianDateTime.EndOfYearPersianDateTime(1399);</p>
</td>
<td style="width: 101.6px; height: 40.8px; text-align: left;">
<p>1397/12/29</p>
<p>&nbsp;1399/12/30</p>
</td>
</tr>
<tr style="height: 40.8px;">
<td style="width: 79.2px; height: 40.8px; text-align: center;"><span style="background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;">آخرین روز ماه</span></td>
<td dir="ltr" style="width: 451.2px; height: 40.8px; text-align: left;">
<p>var d1 = PersianDateTime.EndDateOfMonth(1397,12);</p>
<p>var d1 = PersianDateTime.EndDateOfMonth(1399,12);</p>
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
</tr>
</tbody>
</table>
</div>
