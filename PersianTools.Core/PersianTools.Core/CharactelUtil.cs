using System;
using System.Collections.Generic;
using System.Text;

namespace PersianTools.Core
{
    public class ConvertList
    {
        public long Level { get; set; }
        public long Number { get; set; }
        public ConvertList(long level, long number)
        {
            this.Level = level;
            this.Number = number;
        }
    }
    
    public static class CharacterUtil
    {
        private static Dictionary<long, string> numDic = new Dictionary<long, string>()
        {
            { 0, "" },{ 1, "یک" },{ 2, "دو" },{ 3, "سه" },{ 4, "چهار" },{ 5, "پنج" },
            { 6, "شش" },{ 7, "هفت" },{ 8, "هشت" },{ 9, "نه" },{ 10, "ده" },
            { 11, "یازده" },{ 12, "دوازده" },{ 13, "سیزده" },{ 14, "چهارده" },{ 15, "پانزده" },
            { 16, "شانزده" },{ 17, "هفده" },{ 18, "هجده" },{ 19, "نوزده" },{ 20, "بیست" },
            { 30, "سی" },{ 40, "چهل" },{ 50, "پنجاه" },{ 60, "شصت" },{ 70, "هفتاد" },
            { 80, "هشتاد" },{ 90, "نود" },{ 100, "صد" },{ 110, "صد و ده" },{ 120, "صد و بیست" },
            { 130, "صد و سی" },{ 140, "صد و چهل" },{ 150, "صد و پنجاه" },{ 160, "صد و شصت" },
            { 170, "صد و هفتاد" },{ 180, "صد و هشتاد" },{ 190, "صد و نود" },{ 200, "دویست" },
            { 300, "سیصد" },{ 400, "چهارصد" },{ 500, "پانصد" },{ 600, "ششصد" },{ 700, "هفتصد" },
            { 800, "هشتصد" },{ 900, "نهصد " },{ 1000, "هزار " },{ 1000000, "میلیون " },{ 1000000000, "میلیارد " },

        };
        private static List<ConvertList> ConList = new List<ConvertList>()
        {
            new ConvertList(1000000000,1000000000),
            new ConvertList(1000000,1000000),
            new ConvertList(100000,1000 ),
            new ConvertList(10000,1000 ),
            new ConvertList(1000,1000 ),
            new ConvertList(100,100 ),
            new ConvertList(21,10)
        };
        public static string ConvertToPersianDigit(this string num) =>
            num.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴")
            .Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹").Replace(".", ".");
        public static string ConvertToPersianChar(this string str) =>
            str.Replace("q", "ض").Replace("w", "ص").Replace("e", "ث").Replace("r", "ق").Replace("t", "ف")
            .Replace("y", "غ").Replace("u", "ع").Replace("i", "ه").Replace("o", "خ").Replace("p", "ح")
            .Replace("[", "ج").Replace("]", "چ").Replace("a", "ش").Replace("s", "س").Replace("d", "ی")
            .Replace("f", "ب").Replace("g", "ل").Replace("h", "ا").Replace("j", "ت").Replace("k", "ن")
            .Replace("l", "م").Replace(";", "ک").Replace("\"", "گ").Replace("z", "ظ").Replace("x", "ط")
            .Replace("c", "ز").Replace("v", "ر").Replace("b", "ذ").Replace("n", "د").Replace("m", "پ")
            .Replace(")", "و").Replace("?", "؟");

        public static string ConvertToEnglishDigit(this string num) =>
            num.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4")
            .Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9").Replace(".", ".");
        public static Int32 ConvertToInt(this string num) =>
            System.Convert.ToInt32(ConvertToEnglishDigit(num));
        public static decimal ConvertToDecimal(this string num) =>
            System.Convert.ToDecimal(ConvertToEnglishDigit(num));
        private static long Remaining(long i, long j)
        {
            return (i - (j * Quotient(i, j)));
        }



        public static string Convert(int i)
        {
            if (i == 0)
                return "صفر";
            return ConvertUltraHuge((long)i).Replace("  ", " ");
        }

        public static string Convert(long i)
        {
            if (i == 0)
                return "صفر";
            return ConvertUltraHuge(i).Replace("  ", "");
        }
        public static string Convert2(long number)
        {
            string result = ConvertToText(0, number);

            return result.Replace("  ", "");
        }
        private static string GetNumDicValue(long key)
        {
            string TempValue;
            return numDic.TryGetValue(key, out TempValue) ? TempValue : String.Empty;
        }
        private static string ConvertToText(int id, long number)
        {
            string TempValue = GetNumDicValue(number);


            if (number < ConList[ConList.Count - 1].Level)
            {
                //return ConvertOne(i);
                return TempValue;
            }
            //long lev = number < 20+1 ? 10 : level;
            if (number < ConList[id].Level)
            {
                ConvertToText(id + 1, number);// numDic.GetValueOrDefault(number);
            }
            if (number < 1000)
            {
                return (ConvertToText(id + 1, Quotient(ConList[id].Number * number, ConList[id].Level))
                + GetNumDicValue(ConList[id].Level)
                + Space(ConvertToText(id + 1, Remaining(number, ConList[id].Level)))
                + ConvertToText(id + 1, Remaining(number, ConList[id].Level)));
            }
            return (ConvertToText(id + 1, Quotient(number, ConList[id].Level))
                + GetNumDicValue(ConList[id].Level)
                + Space(ConvertToText(id + 1, Remaining(number, ConList[id].Level)))
                + ConvertToText(id + 1, Remaining(number, ConList[id].Level)));
        }
        private static string ConvertUltraHuge(long i)
        {
            if (i < 1000000000)
            {
                return ConvertHuge(i);
            }
            return (ConvertHuge(Quotient(i, 1000000000))
                + GetNumDicValue(1000000000)
                + Space(ConvertHuge(Remaining(i, 1000000000)))
                + ConvertHuge(Remaining(i, 1000000000)) + " ريال").Replace("  ", "");
        }
        private static string ConvertHuge(long i)
        {
            if (i < 1000000)
            {
                return ConvertBiger(i);
            }
            return (ConvertBiger(Quotient(i, 1000000))
                + GetNumDicValue(1000000)
                + Space(ConvertBiger(Remaining(i, 1000000)))
                + ConvertBiger(Remaining(i, 1000000)));
        }
        private static string ConvertBiger(long i)
        {
            if (i < 100000)
            {
                return ConvertBig(i);
            }
            return (ConvertLarge(Quotient(i, 1000))
                + GetNumDicValue(1000)
                + Space(ConvertBig(Remaining(i, 1000)))
                + ConvertBig(Remaining(i, 1000)));
        }
        private static string ConvertBig(long i)
        {
            if (i < 10000)
            {
                return ConvertLarger(i);
            }
            return (ConvertLarger(Quotient(i, 1000))
                + GetNumDicValue(1000)
                + Space(ConvertLarge(Remaining(i, 1000)))
                + ConvertLarge(Remaining(i, 1000)));
        }
        private static string ConvertLarger(long i)
        {
            if (i < 1000)
            {
                return ConvertLarge(i);
            }
            return (ConvertLarge(Quotient(i, 1000))
                + GetNumDicValue(1000)
                + Space(ConvertLarge(Remaining(i, 1000)))
                + ConvertLarge(Remaining(i, 1000)));
        }
        private static string ConvertLarge(long i)
        {
            if (i < 100)
            {
                return ConvertMedium(i);
            }
            return (//ConvertHundred(100 * Quotient(i, 100))
                 GetNumDicValue(100 * Quotient(i, 100))
                + Space(ConvertMedium(Remaining(i, 100)))
                + ConvertMedium(Remaining(i, 100)));
        }
        private static string ConvertMedium(long i)
        {
            if (i < 21)
            {
                //return ConvertOne(i);
                return GetNumDicValue(i);
            }
            //long num = 10 * Quotient(i, 10);
            return (//ConvertTen(num)
                GetNumDicValue(10 * Quotient(i, 10))
                + Space(GetNumDicValue(Remaining(i, 10)))
                + GetNumDicValue(Remaining(i, 10)));
        }



        private static string ConvertOne(long i)
        {
            long num = i;
            if ((num <= 20) && (num >= 0))
            {
                switch (((int)num))
                {
                    case 0: return " ";
                    case 1: return "یک";
                    case 2: return "دو";
                    case 3: return "سه";
                    case 4: return "چهار";
                    case 5: return "پنج";
                    case 6: return "شش";
                    case 7: return "هفت";
                    case 8: return "هشت";
                    case 9: return "نه";
                    case 10: return "ده";
                    case 11: return "یازده";
                    case 12: return "دوازده";
                    case 13: return "سیزده";
                    case 14: return "چهارده";
                    case 15: return "پانزده";
                    case 16: return "شانزده";
                    case 17: return "هفده";
                    case 18: return "هجده";
                    case 19: return "نوزده";
                    case 20: return "بیست";
                    default: return " ";
                }
            }
            return "******";
        }
        private static string ConvertTen(long i)
        {
            switch (i)
            {
                case 20:
                    return "بیست";

                case 30:
                    return "سی";

                case 40:
                    return "چهل";

                case 0:
                    return " ";

                case 10:
                    return "ده";

                case 50:
                    return "پنجاه";

                case 60:
                    return "شصت";

                case 70:
                    return "هفتاد";

                case 80:
                    return "هشتاد";

                case 90:
                    return "نود";

                case 120:
                    return "صدوبیست";

                case 130:
                    return "صدوسی";

                case 140:
                    return "صدوچهل";

                case 100:
                    return "صد";

                case 110:
                    return "صدوده";

                case 150:
                    return "صدوپنجاه";

                case 160:
                    return "صدوشست";

                case 170:
                    return "صدوهفتاد";

                case 180:
                    return "صدوهشتاد";

                case 190:
                    return "صدونود";

                case 200:
                    return "دویست";
            }
            return "***";
        }
        private static string ConvertHundred(long i)
        {
            switch (i)
            {
                case 0: return " ";
                case 100: return "صد";
                case 200: return "دویست";
                case 300: return "سیصد";
                case 400: return "چهارصد";
                case 500: return "پانصد";
                case 600: return "ششصد";
                case 700: return "هفتصد";
                case 800: return "هشتصد";
                case 900: return "نهصد";
                case 1000: return "هزار";
                default: return "******";
            }
        }

        private static long Quotient(long i, long j)
        {
            return (long)(((double)i) / ((double)j));
        }

        private static string Space(string digit)
        {
            return (((digit == "") || (digit == " ")) ? " " : " و ");
        }

    }
}

