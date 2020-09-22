using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace PersianTools.Core
{
    public class HoliDaysData
    {
        private static HoliDaysData instance { get; set; }
        public List<DaysData> DaysData { get; set; }
        private readonly static PersianCalendar PersianCalendar = new PersianCalendar();
        private HijriCalendar HijriCalendar { get; set; }
        private HoliDaysData(HijriCalendar hijriCalendar)
        {
            HijriCalendar = hijriCalendar;
            LoadData();
        }
        public static HoliDaysData GetInstance(HijriCalendar hijriCalendar)
        {
            if (instance == null)
            {
                instance = new HoliDaysData(hijriCalendar);
            }
            return instance;
        }


        private void LoadData()
        {
            DaysData = new List<DaysData>();
            FillJalaliHoliDays();
            FillHijriHoliDays();
            FillJalaliNormalDays();
            FillHijriNormalDays();
            FillMiladiNormalDays();
        }
        private void FillHijriHoliDays()
        {
            DaysData.Add(new DaysData(61, 1, 9, CalenderType.Hijri, DateType.HoliDay, "تاسوعای حسینی"));
            DaysData.Add(new DaysData(61, 1, 10, CalenderType.Hijri, DateType.HoliDay, "عاشورای حسینی"));
            DaysData.Add(new DaysData(61, 2, 20, CalenderType.Hijri, DateType.HoliDay, "اربعین حسینی"));
            DaysData.Add(new DaysData(61, 2, 28, CalenderType.Hijri, DateType.HoliDay, "رحلت رسول اکرم؛شهادت امام حسن مجتبی علیه السلام"));
            DaysData.Add(new DaysData(61, 2, 29, CalenderType.Hijri, DateType.HoliDay, "شهادت امام رضا علیه السلام"));
            DaysData.Add(new DaysData(61, 3, 8, CalenderType.Hijri, DateType.HoliDay, "شهادت امام حسن عسکری علیه السلام"));
            DaysData.Add(new DaysData(61, 3, 17, CalenderType.Hijri, DateType.HoliDay, "میلاد رسول اکرم و امام جعفر صادق علیه السلام"));
            DaysData.Add(new DaysData(61, 6, 3, CalenderType.Hijri, DateType.HoliDay, "شهادت حضرت فاطمه زهرا سلام الله علیها"));
            DaysData.Add(new DaysData(61, 7, 13, CalenderType.Hijri, DateType.HoliDay, "ولادت امام علی علیه السلام و روز پدر"));
            DaysData.Add(new DaysData(61, 7, 27, CalenderType.Hijri, DateType.HoliDay, "مبعث رسول اکرم"));
            DaysData.Add(new DaysData(61, 8, 15, CalenderType.Hijri, DateType.HoliDay, "ولادت حضرت قائم عجل الله تعالی فرجه و جشن  نیمه شعبان"));
            DaysData.Add(new DaysData(61, 9, 21, CalenderType.Hijri, DateType.HoliDay, "شهادت حضرت علی علیه السلام"));
            DaysData.Add(new DaysData(61, 10, 1, CalenderType.Hijri, DateType.HoliDay, "عید سعید فطر"));
            DaysData.Add(new DaysData(61, 10, 2, CalenderType.Hijri, DateType.HoliDay, "تعطیل به مناسبت عید سعید فطر"));
            DaysData.Add(new DaysData(61, 10, 25, CalenderType.Hijri, DateType.HoliDay, "شهادت امام جعفر صادق علیه السلام"));
            DaysData.Add(new DaysData(61, 12, 10, CalenderType.Hijri, DateType.HoliDay, "عید سعید قربان"));
            DaysData.Add(new DaysData(61, 12, 18, CalenderType.Hijri, DateType.HoliDay, "عید سعید غدیر خم"));

        }
        private void FillJalaliHoliDays()
        {
            DaysData.Add(new DaysData(1, 1, 1, CalenderType.Jalali, DateType.HoliDay, "جشن نوروز"));
            DaysData.Add(new DaysData(1, 1, 2, CalenderType.Jalali, DateType.HoliDay, "عیدنوروز"));
            DaysData.Add(new DaysData(1, 1, 3, CalenderType.Jalali, DateType.HoliDay, "عیدنوروز"));
            DaysData.Add(new DaysData(1, 1, 4, CalenderType.Jalali, DateType.HoliDay, "عیدنوروز"));
            DaysData.Add(new DaysData(1, 1, 12, CalenderType.Jalali, DateType.HoliDay, "روز جمهوری اسلامی ایران"));
            DaysData.Add(new DaysData(1, 1, 13, CalenderType.Jalali, DateType.HoliDay, "جشن سیزده به در"));
            DaysData.Add(new DaysData(1, 3, 14, CalenderType.Jalali, DateType.HoliDay, "رحلت حضرت امام خمینی"));
            DaysData.Add(new DaysData(1, 3, 15, CalenderType.Jalali, DateType.HoliDay, "قیام 15 خرداد"));
            DaysData.Add(new DaysData(1, 11, 22, CalenderType.Jalali, DateType.HoliDay, "پیروزی انقلاب اسلامی"));
            DaysData.Add(new DaysData(1, 12, 29, CalenderType.Jalali, DateType.HoliDay, "روز ملی شدن صنعت نفت ایران"));
        }
        private void FillJalaliNormalDays()
        {
            DaysData.Add(new DaysData(1, 1, 6, CalenderType.Jalali, DateType.NationalEvent, "روز امید، روز شادباش نویسی"));
            DaysData.Add(new DaysData(1, 1, 6, CalenderType.Jalali, DateType.NationalEvent, "زادروز آشو زرتشت، اَبَراِنسان بزرگ تاریخ"));
            DaysData.Add(new DaysData(1, 1, 10, CalenderType.Jalali, DateType.NationalEvent, "جشن آبانگاه"));
            DaysData.Add(new DaysData(1, 1, 17, CalenderType.Jalali, DateType.NationalEvent, "سروش روز،جشن سروشگان"));
            DaysData.Add(new DaysData(1359, 1, 19, CalenderType.Jalali, DateType.NationalEvent, "شهادت آیت الله سید محمد باقر صدر و خواهر ایشان بنت الهدی توسط حکومت بعث عراق"));
            DaysData.Add(new DaysData(1, 1, 19, CalenderType.Jalali, DateType.NationalEvent, "فروردین روز ، جشن فروردینگان"));
            DaysData.Add(new DaysData(1, 1, 20, CalenderType.Jalali, DateType.NationalEvent, "روز ملّی فن آوری هسته ای"));
            DaysData.Add(new DaysData(1, 1, 21, CalenderType.Jalali, DateType.NationalEvent, "روز هنر انقلاب اسلامی"));
            DaysData.Add(new DaysData(1378, 1, 21, CalenderType.Jalali, DateType.NationalEvent, "شهادت امیر سپهبد علی سیاد شیرازی"));
            DaysData.Add(new DaysData(1, 1, 25, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت عطار نیشابوری"));
            DaysData.Add(new DaysData(1, 1, 29, CalenderType.Jalali, DateType.NationalEvent, "روز ارتش جمهوری اسلامی ایران"));
            DaysData.Add(new DaysData(1, 2, 1, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت سعدی"));
            DaysData.Add(new DaysData(1358, 2, 2, CalenderType.Jalali, DateType.NationalEvent, "تاسیس سپاه پاسداران انقلاب اسلامی)"));
            DaysData.Add(new DaysData(1359, 2, 2, CalenderType.Jalali, DateType.NationalEvent, "سالروز اعلام انقلاب فرهنگی"));
            DaysData.Add(new DaysData(1, 2, 3, CalenderType.Jalali, DateType.NationalEvent, "روزبزرگداشت شیخ بهایی"));
            DaysData.Add(new DaysData(1, 2, 3, CalenderType.Jalali, DateType.NationalEvent, "روزملی کارآفرینی"));
            DaysData.Add(new DaysData(1359, 2, 5, CalenderType.Jalali, DateType.NationalEvent, "شکست حمله ی نظامی آمریکا با ایران در طبس"));
            DaysData.Add(new DaysData(1, 2, 9, CalenderType.Jalali, DateType.NationalEvent, "روزشوراها"));
            DaysData.Add(new DaysData(1, 2, 10, CalenderType.Jalali, DateType.NationalEvent, "جشن چهلم نوروز"));
            DaysData.Add(new DaysData(1, 2, 10, CalenderType.Jalali, DateType.NationalEvent, "روزملی خلیج فارس"));
            DaysData.Add(new DaysData(1361, 2, 10, CalenderType.Jalali, DateType.NationalEvent, "آغاز عملیات بیت المقدس"));
            DaysData.Add(new DaysData(1, 2, 12, CalenderType.Jalali, DateType.NationalEvent, "شهادت استاد مرتضی مطهری، روزمعلم"));
            DaysData.Add(new DaysData(1, 2, 15, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت شیخ صدوق"));
            DaysData.Add(new DaysData(1, 2, 15, CalenderType.Jalali, DateType.NationalEvent, "جشن میانه بهار ، جشن بهاربد"));
            DaysData.Add(new DaysData(1, 2, 15, CalenderType.Jalali, DateType.NationalEvent, "روز شیراز"));
            DaysData.Add(new DaysData(1, 2, 17, CalenderType.Jalali, DateType.NationalEvent, "روز اسنادملی و میراث مکتوب"));
            DaysData.Add(new DaysData(1270, 2, 24, CalenderType.Jalali, DateType.NationalEvent, "لغو امتیاز تنباکو به فتوای آیت الله میرزا حسن شیرازی"));
            DaysData.Add(new DaysData(1, 2, 25, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت فردوسی"));
            DaysData.Add(new DaysData(1, 2, 27, CalenderType.Jalali, DateType.NationalEvent, "روز ارتباطات و روابط عمومی"));
            DaysData.Add(new DaysData(1, 2, 28, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت حکیم عمر خیام"));
            DaysData.Add(new DaysData(1, 3, 1, CalenderType.Jalali, DateType.NationalEvent, "روز بهره وری و بهینه سازی مصرف"));
            DaysData.Add(new DaysData(1, 3, 1, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت ملاصدرا"));
            DaysData.Add(new DaysData(1361, 3, 3, CalenderType.Jalali, DateType.NationalEvent, "فتح خرمشهر در عملیات بیت المقدس"));
            DaysData.Add(new DaysData(1, 3, 3, CalenderType.Jalali, DateType.NationalEvent, "روز مقاومت ایثار و پیروزی"));
            DaysData.Add(new DaysData(1, 3, 4, CalenderType.Jalali, DateType.NationalEvent, "روز دزفول"));
            DaysData.Add(new DaysData(1, 3, 4, CalenderType.Jalali, DateType.NationalEvent, "روز مقاومت و پایداری"));
            DaysData.Add(new DaysData(1, 3, 6, CalenderType.Jalali, DateType.NationalEvent, "خرداد روز ، جشن خردادگان"));
            DaysData.Add(new DaysData(1349, 3, 20, CalenderType.Jalali, DateType.NationalEvent, "شهادت آیت الله سعیدی"));
            DaysData.Add(new DaysData(1, 3, 25, CalenderType.Jalali, DateType.NationalEvent, "روز ملی گل وگیاه"));
            DaysData.Add(new DaysData(1, 3, 27, CalenderType.Jalali, DateType.NationalEvent, "روز جهاد کشاورزی"));
            DaysData.Add(new DaysData(1356, 3, 29, CalenderType.Jalali, DateType.NationalEvent, "درگذشت دکتر علی شریعتی"));
            DaysData.Add(new DaysData(1373, 3, 30, CalenderType.Jalali, DateType.NationalEvent, "انفجار در حرم حضرت امام رضا (ع)"));
            DaysData.Add(new DaysData(1360, 3, 31, CalenderType.Jalali, DateType.NationalEvent, "شهادت دکتر مصطفی چمران"));
            DaysData.Add(new DaysData(1, 3, 31, CalenderType.Jalali, DateType.NationalEvent, "روز بسیج اساتید"));
            DaysData.Add(new DaysData(1, 4, 1, CalenderType.Jalali, DateType.NationalEvent, "جشن آب پاشونک، جشن آغاز تابستان"));
            DaysData.Add(new DaysData(1, 4, 1, CalenderType.Jalali, DateType.NationalEvent, "روز اصناف"));
            DaysData.Add(new DaysData(1360, 4, 1, CalenderType.Jalali, DateType.NationalEvent, "روز تبلیغ و اطلاع رسانی دینی ، سالروز صدور فرمان امام خمینی (ره) مبنی بر تاسیس سازمان تبلیغات اسلامی"));
            DaysData.Add(new DaysData(1360, 4, 7, CalenderType.Jalali, DateType.NationalEvent, "شهادت آیت الله دکتر بهشتی ؛ روز قوه قضاییه"));
            DaysData.Add(new DaysData(1, 4, 8, CalenderType.Jalali, DateType.NationalEvent, "روز مبارزه با سلاح های شیمیایی و میکروبی"));
            DaysData.Add(new DaysData(1, 4, 10, CalenderType.Jalali, DateType.NationalEvent, "روز صنعت و معدن"));
            DaysData.Add(new DaysData(1361, 4, 11, CalenderType.Jalali, DateType.NationalEvent, "شهادت آیت الله صدوقی چهارمین شهید محراب"));
            DaysData.Add(new DaysData(1368, 4, 12, CalenderType.Jalali, DateType.NationalEvent, "حمله به هواپیمای مسافربری جمهوری اسلامی ایران توسط ناوگان آمریکایی"));
            DaysData.Add(new DaysData(1, 4, 13, CalenderType.Jalali, DateType.NationalEvent, "سالروز درگذشت دکتر معین"));
            DaysData.Add(new DaysData(1, 4, 13, CalenderType.Jalali, DateType.NationalEvent, "تیر روز،جشن تیرگان"));
            DaysData.Add(new DaysData(1, 4, 14, CalenderType.Jalali, DateType.NationalEvent, "روز قلم"));
            DaysData.Add(new DaysData(1, 4, 15, CalenderType.Jalali, DateType.NationalEvent, "جشن خام خواری"));
            DaysData.Add(new DaysData(1, 4, 16, CalenderType.Jalali, DateType.NationalEvent, "روز مالیات"));
            DaysData.Add(new DaysData(1, 4, 21, CalenderType.Jalali, DateType.NationalEvent, "روز عفاف و حجاب"));
            DaysData.Add(new DaysData(1, 4, 25, CalenderType.Jalali, DateType.NationalEvent, "روز بهزیستی و تامین اجتماعی"));
            DaysData.Add(new DaysData(1368, 4, 27, CalenderType.Jalali, DateType.NationalEvent, "اعلام پذیرش قطعنامه 598 شورای امنیت از سوی ایران"));
            DaysData.Add(new DaysData(1367, 5, 5, CalenderType.Jalali, DateType.NationalEvent, "سالروز عملیات افتخار آفرین مرصاد"));
            DaysData.Add(new DaysData(1, 5, 6, CalenderType.Jalali, DateType.NationalEvent, "روز ترویج آموزش های فنی و حرفه ای"));
            DaysData.Add(new DaysData(1, 5, 7, CalenderType.Jalali, DateType.NationalEvent, "مرداد روز ، جشن مردادگان"));
            DaysData.Add(new DaysData(1, 5, 8, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت شیخ شهاب الدین سهروردی"));
            DaysData.Add(new DaysData(1, 5, 9, CalenderType.Jalali, DateType.NationalEvent, "روز اهدای خون"));
            DaysData.Add(new DaysData(1, 5, 10, CalenderType.Jalali, DateType.NationalEvent, "جشن چله تابستان"));
            DaysData.Add(new DaysData(1, 5, 14, CalenderType.Jalali, DateType.NationalEvent, "صدور فرمان مشروطیت"));
            DaysData.Add(new DaysData(1359, 5, 16, CalenderType.Jalali, DateType.NationalEvent, "تشکیل جهاد دانشگاهی"));
            DaysData.Add(new DaysData(1, 5, 17, CalenderType.Jalali, DateType.NationalEvent, "روز خبرنگار"));
            DaysData.Add(new DaysData(1, 5, 26, CalenderType.Jalali, DateType.NationalEvent, "سالروز ورود آزادگانِ سرافراز به وطن"));
            DaysData.Add(new DaysData(1332, 5, 28, CalenderType.Jalali, DateType.NationalEvent, "سالروز کودتای 28 مرداد علیه دولت دکتر محمد مصدق"));
            DaysData.Add(new DaysData(1, 5, 28, CalenderType.Jalali, DateType.NationalEvent, "سالروز فاجعه آتش زدن سینما رکس آبادان"));
            DaysData.Add(new DaysData(1, 5, 30, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت علامه مجلسی"));

            DaysData.Add(new DaysData(1, 6, 1, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت ابوعلی سینا و روز پزشک"));
            DaysData.Add(new DaysData(1, 6, 2, CalenderType.Jalali, DateType.NationalEvent, "آغاز هفته دولت"));
            DaysData.Add(new DaysData(1, 6, 4, CalenderType.Jalali, DateType.NationalEvent, "زادروز داراب (کوروش)"));
            DaysData.Add(new DaysData(1, 6, 4, CalenderType.Jalali, DateType.NationalEvent, "روز کارمند"));
            DaysData.Add(new DaysData(1, 6, 4, CalenderType.Jalali, DateType.NationalEvent, "شهریور روز ، جشن شهریورگان"));
            DaysData.Add(new DaysData(1, 6, 5, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت محمدبن زکریای رازی و روز داروساز"));
            DaysData.Add(new DaysData(1, 6, 8, CalenderType.Jalali, DateType.NationalEvent, "روز مبارزه با تروریسم"));
            DaysData.Add(new DaysData(1362, 6, 10, CalenderType.Jalali, DateType.NationalEvent, "روز بانکداری اسلامی ، سالروز تصویب قانون عملیات بانکی بدون ربا"));
            DaysData.Add(new DaysData(1, 6, 11, CalenderType.Jalali, DateType.NationalEvent, "روز صنعت چاپ"));
            DaysData.Add(new DaysData(1, 6, 12, CalenderType.Jalali, DateType.NationalEvent, "روز مبارزه با استعمار انگلیس"));
            DaysData.Add(new DaysData(1, 6, 13, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت ابوریحان بیرونی"));
            DaysData.Add(new DaysData(1, 6, 13, CalenderType.Jalali, DateType.NationalEvent, "روزتعاون"));
            DaysData.Add(new DaysData(1360, 6, 14, CalenderType.Jalali, DateType.NationalEvent, "شهادت آیت الله قدوسی و سرتیب وحید دستجردی"));
            DaysData.Add(new DaysData(1, 6, 14, CalenderType.Jalali, DateType.NationalEvent, "روز اکرام"));
            DaysData.Add(new DaysData(1357, 6, 17, CalenderType.Jalali, DateType.NationalEvent, "قیام 17 شهریور"));
            DaysData.Add(new DaysData(1358, 6, 19, CalenderType.Jalali, DateType.NationalEvent, "وفات آیت الله سید محمود طالقانی اولین امام جمعه تهران"));
            DaysData.Add(new DaysData(1360, 6, 20, CalenderType.Jalali, DateType.NationalEvent, "شهادت دومین شهید محراب آیت الله مدنی"));
            DaysData.Add(new DaysData(1, 6, 21, CalenderType.Jalali, DateType.NationalEvent, "روز سینما"));
            DaysData.Add(new DaysData(1, 6, 27, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت شهریار و شعر و ادب فارسی"));
            DaysData.Add(new DaysData(1359, 6, 31, CalenderType.Jalali, DateType.NationalEvent, "سالروز آغاز جنگ تحمیلی و آغاز هفته دفاع مقدس"));
            DaysData.Add(new DaysData(1360, 7, 5, CalenderType.Jalali, DateType.NationalEvent, "شکست حصر آبادان"));
            DaysData.Add(new DaysData(1, 7, 7, CalenderType.Jalali, DateType.NationalEvent, "روز آتش نشانی و ایمنی"));
            DaysData.Add(new DaysData(1360, 7, 7, CalenderType.Jalali, DateType.NationalEvent, "سقوط هواپیمای حامل جمعی از فرماندهان جنگ (کلاهدوز، نامجو، فلاحی، فکوری، جهان آرا)"));
            DaysData.Add(new DaysData(1, 7, 8, CalenderType.Jalali, DateType.NationalEvent, "روزبزرگداشت مولوی"));
            DaysData.Add(new DaysData(1, 7, 9, CalenderType.Jalali, DateType.NationalEvent, "روز همبستگی با کودکان و نوجوانان فلسطینی"));

            DaysData.Add(new DaysData(1, 7, 13, CalenderType.Jalali, DateType.NationalEvent, "روز نیروی انتظامی"));
            DaysData.Add(new DaysData(1, 7, 14, CalenderType.Jalali, DateType.NationalEvent, "روز دامپزشکی"));
            DaysData.Add(new DaysData(1, 7, 16, CalenderType.Jalali, DateType.NationalEvent, "مهر روز ، جشن مهرگان"));
            DaysData.Add(new DaysData(1, 7, 20, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت حافظ"));
            DaysData.Add(new DaysData(1, 7, 20, CalenderType.Jalali, DateType.NationalEvent, "روز ملی کاهش اثرات بلایای طبیعی"));
            DaysData.Add(new DaysData(1, 7, 21, CalenderType.Jalali, DateType.NationalEvent, "جشن پیروزی کاوه و فریدون"));
            DaysData.Add(new DaysData(1, 7, 24, CalenderType.Jalali, DateType.NationalEvent, "روز پیوند اولیاء و مربیان"));
            DaysData.Add(new DaysData(1, 7, 26, CalenderType.Jalali, DateType.NationalEvent, "روز تربیت بدنی و ورزش"));
            DaysData.Add(new DaysData(1, 7, 29, CalenderType.Jalali, DateType.NationalEvent, "روز صادرات"));
            DaysData.Add(new DaysData(1, 8, 1, CalenderType.Jalali, DateType.NationalEvent, "روز آمار و برنامه ریزی"));
            DaysData.Add(new DaysData(1, 8, 7, CalenderType.Jalali, DateType.NationalEvent, "سالروز ورود کوروش بزرگ به بابل در سال 539 پیش از میلاد"));
            DaysData.Add(new DaysData(1, 8, 8, CalenderType.Jalali, DateType.NationalEvent, "روز نوجوان"));
            DaysData.Add(new DaysData(1, 8, 10, CalenderType.Jalali, DateType.NationalEvent, "آبان روز، جشن آبانگان"));
            DaysData.Add(new DaysData(1, 8, 13, CalenderType.Jalali, DateType.NationalEvent, "روز دانش آموز"));
            DaysData.Add(new DaysData(1, 8, 14, CalenderType.Jalali, DateType.NationalEvent, "روز فرهنگ عمومی"));
            DaysData.Add(new DaysData(1, 8, 15, CalenderType.Jalali, DateType.NationalEvent, "جشن میانه پاییز"));
            DaysData.Add(new DaysData(1, 8, 18, CalenderType.Jalali, DateType.NationalEvent, "روز ملی کیفیت"));
            DaysData.Add(new DaysData(1, 8, 24, CalenderType.Jalali, DateType.NationalEvent, "روز کتاب و کتاب خوانی"));
            DaysData.Add(new DaysData(1, 9, 1, CalenderType.Jalali, DateType.NationalEvent, "آذر جشن"));
            DaysData.Add(new DaysData(1, 9, 5, CalenderType.Jalali, DateType.NationalEvent, "روز بسیج مستضعفان"));
            DaysData.Add(new DaysData(1, 9, 7, CalenderType.Jalali, DateType.NationalEvent, "روز نیروی دریایی"));
            DaysData.Add(new DaysData(1, 9, 9, CalenderType.Jalali, DateType.NationalEvent, "آذر روز، جشن آذرگان"));
            DaysData.Add(new DaysData(1, 9, 9, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت شیخ مفید"));
            DaysData.Add(new DaysData(1, 9, 10, CalenderType.Jalali, DateType.NationalEvent, "روز مجلس"));
            DaysData.Add(new DaysData(1, 9, 12, CalenderType.Jalali, DateType.NationalEvent, "تصویب قانون اساسی جمهوری اسلامی ایران"));
            DaysData.Add(new DaysData(1, 9, 13, CalenderType.Jalali, DateType.NationalEvent, "روز بیمه"));
            DaysData.Add(new DaysData(1, 9, 15, CalenderType.Jalali, DateType.NationalEvent, "روز حسابدار"));
            DaysData.Add(new DaysData(1, 9, 16, CalenderType.Jalali, DateType.NationalEvent, "روز دانشجو"));
            DaysData.Add(new DaysData(1, 9, 25, CalenderType.Jalali, DateType.NationalEvent, "روز پژوهش"));
            DaysData.Add(new DaysData(1, 9, 26, CalenderType.Jalali, DateType.NationalEvent, "روز حمل و نقل"));
            DaysData.Add(new DaysData(1, 9, 27, CalenderType.Jalali, DateType.NationalEvent, "روز وحدت حوزه و دانشگاه"));
            DaysData.Add(new DaysData(1, 9, 30, CalenderType.Jalali, DateType.NationalEvent, "جشن شب یلدا"));
            DaysData.Add(new DaysData(1, 9, 27, CalenderType.Jalali, DateType.NationalEvent, "روز وحدت حوزه و دانشگاه"));
            DaysData.Add(new DaysData(1, 10, 1, CalenderType.Jalali, DateType.NationalEvent, "روز میلاد خورشید، جشن خرم روز، نخستین جشن دیگان"));
            DaysData.Add(new DaysData(1358, 10, 7, CalenderType.Jalali, DateType.NationalEvent, "سالروز تشکیل نهضت سواد آموزی"));
            DaysData.Add(new DaysData(1, 10, 5, CalenderType.Jalali, DateType.NationalEvent, "سالروز شهادت آشو زرتشت، اَبَراِنسان بزرگ تاریخ"));
            DaysData.Add(new DaysData(1, 10, 8, CalenderType.Jalali, DateType.NationalEvent, "دی به آذر روز، دومین جشن دیگان"));
            DaysData.Add(new DaysData(1, 10, 14, CalenderType.Jalali, DateType.NationalEvent, "روز جهاد کشاورزی"));
            DaysData.Add(new DaysData(1, 10, 15, CalenderType.Jalali, DateType.NationalEvent, "دی به مهر روز، سومین جشن دیگان"));
            DaysData.Add(new DaysData(1, 10, 15, CalenderType.Jalali, DateType.NationalEvent, "روز خانواده"));
            DaysData.Add(new DaysData(1, 10, 15, CalenderType.Jalali, DateType.NationalEvent, "تکریم بازنشستگان"));
            DaysData.Add(new DaysData(1346, 10, 17, CalenderType.Jalali, DateType.NationalEvent, "درگذشت جهان پهلوان تختی"));
            DaysData.Add(new DaysData(1356, 10, 19, CalenderType.Jalali, DateType.NationalEvent, "قیام خونین مردم قم"));
            DaysData.Add(new DaysData(1230, 10, 20, CalenderType.Jalali, DateType.NationalEvent, "سالروز شهادت امیرکبیر به دستور ناصرالدین شاه قاجار"));
            DaysData.Add(new DaysData(1, 10, 23, CalenderType.Jalali, DateType.NationalEvent, "دی به دین روز ، چهارمین جشن دیگان"));
            DaysData.Add(new DaysData(1, 10, 27, CalenderType.Jalali, DateType.NationalEvent, "اجرای توافق نامه‌ی برجام"));
            DaysData.Add(new DaysData(1, 11, 1, CalenderType.Jalali, DateType.NationalEvent, "زادروز فردوسی"));
            DaysData.Add(new DaysData(1, 11, 2, CalenderType.Jalali, DateType.NationalEvent, "بهمن روز، جشن بهمنگان"));
            DaysData.Add(new DaysData(1, 11, 5, CalenderType.Jalali, DateType.NationalEvent, "جشن نوسره"));
            DaysData.Add(new DaysData(1, 11, 10, CalenderType.Jalali, DateType.NationalEvent, "جشن سده"));
            DaysData.Add(new DaysData(1, 11, 12, CalenderType.Jalali, DateType.NationalEvent, "بازگشت امام خمینی (ره) به ایران"));
            DaysData.Add(new DaysData(1, 11, 12, CalenderType.Jalali, DateType.NationalEvent, "آغاز دهه فجر"));
            DaysData.Add(new DaysData(1, 11, 15, CalenderType.Jalali, DateType.NationalEvent, "جشن میانه زمستان"));
            DaysData.Add(new DaysData(1, 11, 18, CalenderType.Jalali, DateType.NationalEvent, "روز ملی فناوری فضایی"));
            DaysData.Add(new DaysData(1, 11, 19, CalenderType.Jalali, DateType.NationalEvent, "روز نیروی هوایی"));
            DaysData.Add(new DaysData(1, 11, 29, CalenderType.Jalali, DateType.NationalEvent, "جشن سپندارمذگان ، روز عشق"));
            DaysData.Add(new DaysData(1, 12, 5, CalenderType.Jalali, DateType.NationalEvent, "جشن اسفندگان(سپندارمذگان) روز عشق بر اساس تقویم زرتشتی"));
            DaysData.Add(new DaysData(1, 12, 5, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت زمین و بانوان"));
            DaysData.Add(new DaysData(1, 12, 5, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت خواجه نصیر الدین طوسی و روز مهندس"));
            DaysData.Add(new DaysData(1, 12, 7, CalenderType.Jalali, DateType.NationalEvent, "سالروز استقلال کانون وکلای دادگستری و روز وکیل مدافع"));
            DaysData.Add(new DaysData(1, 12, 7, CalenderType.Jalali, DateType.NationalEvent, "سالروز درگذشت علی اکبر دهخدا"));
            DaysData.Add(new DaysData(1, 12, 9, CalenderType.Jalali, DateType.NationalEvent, "روز حمایت از حقوق مصرف کنندگان"));
            DaysData.Add(new DaysData(1, 12, 14, CalenderType.Jalali, DateType.NationalEvent, "روز احسان و نیکوکاری"));
            DaysData.Add(new DaysData(1, 12, 14, CalenderType.Jalali, DateType.NationalEvent, "سالروز درگذشت دکتر محمد مصدق"));
            DaysData.Add(new DaysData(1, 12, 15, CalenderType.Jalali, DateType.NationalEvent, "روز درختکاری"));
            DaysData.Add(new DaysData(1, 12, 22, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت شهدا"));
            DaysData.Add(new DaysData(1, 12, 25, CalenderType.Jalali, DateType.NationalEvent, "پایان سرایش شاهنامه"));
            DaysData.Add(new DaysData(1, 12, 25, CalenderType.Jalali, DateType.NationalEvent, "روز بزرگداشت پروین اعتصامی"));
        }
        private void FillHijriNormalDays()
        {
            DaysData.Add(new DaysData(95, 1, 12, CalenderType.Hijri, DateType.ReligiousEvent, "شهادت امام زین العابدین علیه السلام"));
            DaysData.Add(new DaysData(1, 3, 1, CalenderType.Hijri, DateType.ReligiousEvent, "هجرت پیامبر اکرم از مکه به مدینه"));
            DaysData.Add(new DaysData(-53, 3, 12, CalenderType.Hijri, DateType.ReligiousEvent, "میلاد رسول اکرم به روایت اهل سنت"));
            DaysData.Add(new DaysData(-53, 3, 12, CalenderType.Hijri, DateType.ReligiousEvent, "آغاز هفته وحدت"));
            DaysData.Add(new DaysData(232, 4, 8, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت امام حسن عسکری علیه السلام"));
            DaysData.Add(new DaysData(201, 4, 10, CalenderType.Hijri, DateType.ReligiousEvent, "وفات حضرت معصومه سلام الله علیها"));
            DaysData.Add(new DaysData(5, 5, 5, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت حضرت زینب سلام الله علیها و روز پرستار و بهورز"));
            DaysData.Add(new DaysData(-8, 6, 20, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت حضرت فاطمه زهرا سلام الله علیها و روز زن"));
            DaysData.Add(new DaysData(57, 7, 1, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت امام محمد باقر علیه السلام"));
            DaysData.Add(new DaysData(254, 7, 3, CalenderType.Hijri, DateType.ReligiousEvent, "شهادت امام علی النقی الهادی علیه السلام"));
            DaysData.Add(new DaysData(195, 7, 10, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت امام محمد تقی علیه السلام"));
            DaysData.Add(new DaysData(62, 7, 15, CalenderType.Hijri, DateType.ReligiousEvent, "وفات حضرت زینب سلام الله علیها"));
            DaysData.Add(new DaysData(183, 7, 25, CalenderType.Hijri, DateType.ReligiousEvent, "شهادت امام موسی کاظم علیه السلام"));
            DaysData.Add(new DaysData(4, 8, 3, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت سالار شهیدان، امام حسین علیه السلام و روز پاسدار"));
            DaysData.Add(new DaysData(26, 8, 4, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت ابوالفضل العباس علیه السلام و روز جانباز"));
            DaysData.Add(new DaysData(38, 8, 5, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت امام زین العابدین علیه السلام"));
            DaysData.Add(new DaysData(-3, 9, 10, CalenderType.Hijri, DateType.ReligiousEvent, "وفات حضرت خدیجه (س)"));
            DaysData.Add(new DaysData(33, 8, 11, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت حضرت علی اکبر علیه السلام و روز جوان"));
            DaysData.Add(new DaysData(3, 9, 15, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت امام حسن مجتبی علیه السلام"));
            DaysData.Add(new DaysData(1, 9, 18, CalenderType.Hijri, DateType.ReligiousEvent, "شب قدر"));
            DaysData.Add(new DaysData(40, 9, 19, CalenderType.Hijri, DateType.ReligiousEvent, "ضربت خوردن حضرت علی علیه السلام"));
            DaysData.Add(new DaysData(1, 9, 20, CalenderType.Hijri, DateType.ReligiousEvent, "شب قدر"));
            DaysData.Add(new DaysData(1, 9, 22, CalenderType.Hijri, DateType.ReligiousEvent, "شب قدر"));
            DaysData.Add(new DaysData(173, 11, 1, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت حضرت معصومه سلام الله علیها و روز دختر"));
            DaysData.Add(new DaysData(148, 11, 11, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت امام رضا علیه السلام"));
            DaysData.Add(new DaysData(1, 11, 29, CalenderType.Hijri, DateType.ReligiousEvent, "شهادت امام محمد تقی علیه السلام"));
            DaysData.Add(new DaysData(114, 12, 7, CalenderType.Hijri, DateType.ReligiousEvent, "شهادت امام محمد باقرعلیه السلام"));
            DaysData.Add(new DaysData(1, 12, 9, CalenderType.Hijri, DateType.ReligiousEvent, "روز عرفه"));
            DaysData.Add(new DaysData(212, 12, 15, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت امام علی النقی الهادی علیه السلام"));
            DaysData.Add(new DaysData(61, 12, 20, CalenderType.Hijri, DateType.ReligiousEvent, "ولادت امام موسی کاظم علیه السلام"));
        }
        private void FillMiladiNormalDays()
        {
            DaysData.Add(new DaysData(1, 1, 1, CalenderType.Miladi, DateType.InternationalEvent, "جشن آغاز سال نو میلادی"));
            DaysData.Add(new DaysData(1, 2, 14, CalenderType.Miladi, DateType.InternationalEvent, "روز ولنتاین، روز جهانی عشق"));
            DaysData.Add(new DaysData(1, 2, 21, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی زبان مادری"));
            DaysData.Add(new DaysData(1, 3, 8, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی زنان"));
            DaysData.Add(new DaysData(1, 3, 22, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی آب"));
            DaysData.Add(new DaysData(1, 3, 23, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی هواشناسی"));
            DaysData.Add(new DaysData(1, 3, 27, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی تئاتر"));
            DaysData.Add(new DaysData(1, 4, 7, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی بهداشت"));
            DaysData.Add(new DaysData(1, 4, 22, CalenderType.Jalali, DateType.InternationalEvent, "جشن گیاه آوری ، روز زمین پاک"));
            DaysData.Add(new DaysData(1, 4, 29, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی روانشناس و مشاور"));
            DaysData.Add(new DaysData(1, 5, 1, CalenderType.Miladi, DateType.InternationalEvent, "روزجهانی کارگر"));
            DaysData.Add(new DaysData(1, 5, 5, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی ماما"));
            DaysData.Add(new DaysData(1, 5, 8, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی صلیب سرخ و هلال احمر"));
            DaysData.Add(new DaysData(1, 5, 15, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی خانواده"));
            DaysData.Add(new DaysData(1, 5, 17, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی ارتباطات"));
            DaysData.Add(new DaysData(1, 5, 18, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی موزه و میراث فرهنگ"));
            DaysData.Add(new DaysData(1, 5, 21, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی توسعه فرهنگی"));
            DaysData.Add(new DaysData(1, 5, 31, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی بدون دخانیات"));
            DaysData.Add(new DaysData(1, 6, 5, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی محیط زیست"));
            DaysData.Add(new DaysData(1, 6, 10, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی صنایع دستی"));
            DaysData.Add(new DaysData(1, 6, 12, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی مبارزه با کار کودکان"));
            DaysData.Add(new DaysData(1, 6, 14, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی اهدای خون"));
            DaysData.Add(new DaysData(1, 6, 17, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی بیابان زدایی"));
            DaysData.Add(new DaysData(1, 6, 26, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی مبارزه با مواد مخدر"));
            DaysData.Add(new DaysData(1, 8, 1, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی شیر مادر"));
            DaysData.Add(new DaysData(1, 8, 13, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی چپ دست ها"));
            DaysData.Add(new DaysData(1, 8, 19, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی عکاسی"));
            DaysData.Add(new DaysData(1, 8, 21, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی مسجد"));
            DaysData.Add(new DaysData(1, 9, 10, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی پیشگیری از خودکشی"));
            DaysData.Add(new DaysData(1, 9, 11, CalenderType.Miladi, DateType.InternationalEvent, "حمله به برج‌های دوقلوی مرکز تجارت جهانی"));
            DaysData.Add(new DaysData(1, 9, 13, CalenderType.Miladi, DateType.InternationalEvent, "روز گرامیداشت برنامه نویسان"));
            DaysData.Add(new DaysData(1, 9, 21, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی صلح"));
            DaysData.Add(new DaysData(1, 9, 27, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی جهانگردی"));
            DaysData.Add(new DaysData(1, 9, 30, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی ناشنوایان"));
            DaysData.Add(new DaysData(1, 9, 30, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی دریا نوردی"));
            DaysData.Add(new DaysData(1, 9, 30, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی ترجمه و مترجم"));
            DaysData.Add(new DaysData(1, 10, 1, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی سالمندان"));
            DaysData.Add(new DaysData(1, 10, 5, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی معلم"));
            DaysData.Add(new DaysData(1, 10, 8, CalenderType.Miladi, DateType.InternationalEvent, "روز ملی کودک"));
            DaysData.Add(new DaysData(1, 10, 9, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی پست"));
            DaysData.Add(new DaysData(1, 10, 11, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی دختر"));
            DaysData.Add(new DaysData(1, 10, 14, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی استاندارد"));
            DaysData.Add(new DaysData(1, 10, 15, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی عصای سفید"));
            DaysData.Add(new DaysData(1, 10, 16, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی غذا"));
            DaysData.Add(new DaysData(1, 10, 17, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی ریشه کنی فقر"));
            DaysData.Add(new DaysData(1, 10, 29, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی بزرگداشت کورش کبیر"));
            DaysData.Add(new DaysData(1, 11, 17, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی فلسفه"));
            DaysData.Add(new DaysData(1, 11, 20, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی کودک"));
            DaysData.Add(new DaysData(1, 11, 25, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی مبارزه با خشونت علیه زنان"));
            DaysData.Add(new DaysData(1, 12, 1, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی مبارزه با ایدز"));
            DaysData.Add(new DaysData(1, 12, 3, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی معلولان"));
            DaysData.Add(new DaysData(1, 12, 7, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی هواپیمایی"));
            DaysData.Add(new DaysData(1, 12, 25, CalenderType.Miladi, DateType.InternationalEvent, "میلاد حضرت مسیح (ع) و جشن کریسمس"));
            DaysData.Add(new DaysData(1, 12, 3, CalenderType.Miladi, DateType.InternationalEvent, "روز جهانی معلولان"));
        }
        public IList<DateMetaData> GetMetaDataByDateTime(DateTime dateTime)
        {
            IList<DateMetaData> dateMetaDatas = new List<DateMetaData>();
            var data = DaysData.Where(a =>
            (a.Month == PersianCalendar.GetMonth(dateTime) && a.Day == PersianCalendar.GetDayOfMonth(dateTime) && a.CalenderType == CalenderType.Jalali) ||
            (a.Month == HijriCalendar.GetMonth(dateTime) && a.Day == HijriCalendar.GetDayOfMonth(dateTime) && a.CalenderType == CalenderType.Hijri) ||
            (a.Month == dateTime.Month && a.Day == dateTime.Day && a.CalenderType == CalenderType.Miladi)
            );
            foreach (var item in data)
            {
                dateMetaDatas.Add(new DateMetaData
                {
                    CalenderType = item.CalenderType
                ,
                    DateType = item.DateType
                ,
                    Description = item.Description
                ,
                    IsHoliDay = item.DateType == DateType.HoliDay
                    ,
                    Id = $"{ item.Year}-{ item.Month.ToString("00")}-{ item.Day.ToString("00")}"
                });
            }
            return dateMetaDatas;
        }
        private string GetCalenderType(CalenderType calenderType)
        {
            switch (calenderType)
            {
                case CalenderType.Hijri:
                    return "هجری قمری";
                case CalenderType.Jalali:
                    return "هجری شمسی";
                case CalenderType.Miladi:
                    return "میلادی";
                default:
                    return "نامشخص";
            }
        }
        private string GetDateType(DateType dateType)
        {
            switch (dateType)
            {
                case DateType.Event:
                    return "مناسبت غیرتعطیل";
                case DateType.HoliDay:
                    return "مناسبت تعطیل";
                case DateType.NormalDay:
                    return "بدون مناسب";
                case DateType.InternationalEvent:
                    return "مناسبت جهانی";
                case DateType.NationalEvent:
                    return "مناسبت ملی";
                default:
                    return "نامشخص";
            }
        }
    }

    public class DaysData
    {
        public string Description { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public CalenderType CalenderType { get; set; }
        public DateType DateType { get; set; }
        public DaysData(int year, int month, int day, CalenderType calenderType, DateType dateType, string description)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.CalenderType = calenderType;
            this.DateType = dateType;
            this.Description = description;
        }
    }
    public enum CalenderType
    {
        [Description("شمسی")]
        Jalali = 1,
        [Description("قمری")]
        Hijri = 2,
        [Description("میلادی")]
        Miladi = 3
    }
    public enum DateType
    {
        [Description("روز عادی")]
        NormalDay = 1,
        [Description("مناسبت")]
        Event = 2,
        [Description("تعطیل رسمی")]
        HoliDay = 3,
        [Description("مناسبت ملی")]
        NationalEvent = 4,
        [Description("مناسبت بین المللی")]
        InternationalEvent = 5,
        [Description("مناسبت مذهبی")]
        ReligiousEvent = 6
    }
}
