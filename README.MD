<div dir="rtl" style="font-family: tahoma;" align="center">
    <h1 style="color: #5e9ca0;"><span style="color: #000000;">ابزار Persian Tools</span></h1>
    <h3>ابزاری برای برنامه نویسان
    دات نت که که فیچرهای زیادی را برای شما فراهم می کند که در ادامه آنها را شرح خواهیم داد. </h3>
</div>
<hr>

[![license](https://img.shields.io/github/license/naeemaei/PersianTools.Core)](https://github.com/naeemaei/PersianTools.Core/blob/master/LICENSE) [![forks](https://img.shields.io/github/forks/naeemaei/PersianTools.Core)]() [![stars](https://img.shields.io/github/stars/naeemaei/PersianTools.Core)](https://github.com/naeemaei/PersianTools.Core)  
![example workflow](https://github.com/naeemaei/PersianTools.COre/actions/workflows/dotnet.yml/badge.svg)
![example workflow](https://github.com/naeemaei/PersianTools.COre/actions/workflows/release.yml/badge.svg)
![example workflow](https://github.com/naeemaei/PersianTools.COre/actions/workflows/releasepreview.yml/badge.svg)

<div dir="rtl" style="font-family: tahoma;">

# چگونه آنرا نصب کنیم؟

</div>

## Nuget Package Manager

```
Install-Package PersianTools.Core
```

## .NET CLI

```
dotnet add package PersianTools.Core
```

<div dir="rtl" style="font-family: tahoma;">

# امکانات و ویژگی ها

##

- [نوع جدید تاریخ شمسی](#نوع-جدید-تاریخ-شمسی)
- [تبدیل اعداد به حروف](#تبدیل-اعداد-به-حروف)
- [لیست شهرها و استان های ایران](#)
- [اعتبار سنجی کد ملی](#اعتبار-سنجی-کد-ملی)
- [اعتبار سنجش شماره کارت بانکی](#)
- [اعتبار سنجش شماره شبا](#)
- [موقعیت مکانی شماره تلفن، موبایل و کدپستی](#)

</div>

<div dir="rtl" style="font-family: tahoma;">

# نوع جدید تاریخ شمسی

پس از نصب این پکیج نوع جدیدی به نام `PersianDateTime` برای شما قابل استفاده خواهد بود که ویژگی های آن را در ادامه برای شما توضیح خواهیم داد.
که با استفاده از آن میتوانید انواع تبدیل تاریخ را انجام داده و کلیه تعطیلات شمسی و قمری به همراه مناسبتهای یک تاریخ مشاهده کنید
<br><br>
<b>
فقط نکته ای که اهمیت داره اینه که این نوع `Reference Type` هستش و باید در استفاده ازش به این نکته نوجه کنید
</b>
<br>

## تعریف تاریخ شمسی

به یکی از روش های زیر می توانید یک تاریخ شمسی را تعریف نمایید

</div>

```
var persianDate1 = new PersianDateTime(1399, 10, 13); // 1
var persianDate2 = new PersianDateTime("1399/10/13"); // 2
var persianDate3 = new PersianDateTime("1399/12/29 23:30"); // 3
var persianDate4 = new PersianDateTime("1399/12/29 23:30:00"); // 4
var persianDate5 = new PersianDateTime(1399, 12, 29, 23, 30, 10); // 5
var persianDate6 = new PersianDateTime(DateTime.Now); // 6
```

<div dir="rtl" style="font-family: tahoma;">

## مناسبت های یک تاریخ خاص

</div>

### Example 1:

```
var dt1 = new PersianDateTime("1401/02/13").GetDateInformation)();

Output:
[
  {
    "id": "61-10-02",
    "description": "تعطیل به مناسبت عید سعید فطر",
    "calenderType": 2,
    "dateType": 3,
    "isHoliDay": true,
    "calenderTypeDesc": "قمری",
    "dateTypeDesc": "تعطیل رسمی"
  }
]
```

### Example2

```
var dt1 = new PersianDateTime("1401/02/15").GetDateInformation)();

Output:
[
  {
    "id": "1-02-15",
    "description": "روز بزرگداشت شیخ صدوق",
    "calenderType": 1,
    "dateType": 4,
    "isHoliDay": false,
    "calenderTypeDesc": "شمسی",
    "dateTypeDesc": "مناسبت ملی"
  },
  {
    "id": "1-02-15",
    "description": "جشن میانه بهار ، جشن بهاربد",
    "calenderType": 1,
    "dateType": 4,
    "isHoliDay": false,
    "calenderTypeDesc": "شمسی",
    "dateTypeDesc": "مناسبت ملی"
  },
  {
    "id": "1-02-15",
    "description": "روز شیراز",
    "calenderType": 1,
    "dateType": 4,
    "isHoliDay": false,
    "calenderTypeDesc": "شمسی",
    "dateTypeDesc": "مناسبت ملی"
  },
  {
    "id": "1-05-05",
    "description": "روز جهانی ماما",
    "calenderType": 3,
    "dateType": 5,
    "isHoliDay": false,
    "calenderTypeDesc": "میلادی",
    "dateTypeDesc": "مناسبت بین المللی"
  }
]
```

<div dir="rtl" style="font-family: tahoma;">

## فاصله دو تاریخ شمسی

</div>

```
var dt1 = new PersianDateTime("1399/12/29");
var dt2 = new PersianDateTime("1399/11/29");
Convert.ToInt32(dt1.DateDifference(dt2));

Output: 30
```

<div dir="rtl" style="font-family: tahoma;">

## ابتدا روز و انتهای روز

</div>

```
var dt1 = new PersianDateTime("1399/12/29 23:30:20");
var start = dt1.StartOfDay();

Output:
1399/12/29 00:00:00

var dt1 = new PersianDateTime("1399/12/29 23:30:20");
var end = dt1.EndOfDay();

Output:
1399/12/29 23:59:59

```

<div dir="rtl" style="font-family: tahoma;">

## آخرین روز سال

</div>

```
var d1 = PersianDateTime.EndOfYearPersianDateTime(1397);

Output:
1397/12/29

var d2 = PersianDateTime.EndOfYearPersianDateTime(1399);

Output:
1399/12/30
```

<div dir="rtl" style="font-family: tahoma;">

## آخرین روز ماه

</div>

```
var d1 = PersianDateTime.EndDateOfMonth(1397);

Output:
1397/12/29

var d2 = PersianDateTime.EndDateOfMonth(1399);

Output:
1399/12/30
```

<div dir="rtl" style="font-family: tahoma;">

## تعداد روزهای کاری در یک بازه تاریخی

</div>

```
var d1 = new PersianDateTime(1397, 8, 1);
var d2 = new PersianDateTime(1397, 8, 30);
PersianDateTime.GetWorkingDays(d1,d2);

Output:
20

PersianDateTime.GetWorkingDays(d1,d2, true); // با احتساب روزهای پنجشنبه غیر تعطیل

Output:
23

```

<div dir="rtl" style="font-family: tahoma;">

## تعداد روزهای تعطیل پشت سرهم در یک سال

ورودی اول این تابع سال شمسی و ورودی دوم تعداد روز می باشد و خروجی آن یک لیست از تاریخ های پشت سر هم که تعطیل می باشد

</div>

```
var result = PersianDateExtensions.GetContinuousHolidays(year, 3);

Output:
[Item1: 1400/03/13 - 1400/03/16, Item2: ...]

```

<div dir="rtl" style="font-family: tahoma;">

# تبدیل اعداد به حروف

</div>

```
int price = 11200000;
string faPrice = PersianTools.Core.CharacterUtil.Convert(price).Replace(" ", "");

Output:
یازده میلیون و دویست هزار

```

<div dir="rtl" style="font-family: tahoma;">

# اعتبار سنجی کد ملی

</div>

```
var nationalCode = "0032546580";
var validate = nationalCode.IsValidNationalCode();

Output:
True
```

<div dir="rtl" style="font-family: tahoma;">

در حال تکمیل...

</div>
