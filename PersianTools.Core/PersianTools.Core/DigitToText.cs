using System;
using System.Collections.Generic;
using System.Text;

namespace PersianTools.Core
{
    public static class DigitToText
    {
        private static long Baghimande(long i, long j)
        {
            return (i - (j * KharejGhesmat(i, j)));
        }

        private static string ConverSmall(long i)
        {
            switch (i)
            {
                case 20L:
                    return "بیست";

                case 30L:
                    return "سی";

                case 40L:
                    return "چهل";

                case 0L:
                    return " ";

                case 10L:
                    return "ده";

                case 50L:
                    return "پنجاه";

                case 60L:
                    return "شصت";

                case 70L:
                    return "هفتاد";

                case 80L:
                    return "هشتاد";

                case 90L:
                    return "نود";

                case 120L:
                    return "صدوبیست";

                case 130L:
                    return "صدوسی";

                case 140L:
                    return "صدوچهل";

                case 100L:
                    return "صد";

                case 110L:
                    return "صدوده";

                case 150L:
                    return "صدوپنجاه";

                case 160L:
                    return "صدوشست";

                case 170L:
                    return "صدوهفتاد";

                case 180L:
                    return "صدوهشتاد";

                case 190L:
                    return "صدونود";

                case 200L:
                    return "دویست";
            }
            return "***";
        }

        public static string Convert(int i)
        {
            return ConvertUlteraHuge((long)i);
        }

        public static string Convert(long i)
        {
            return ConvertUlteraHuge(i);
        }

        private static string ConvertBig(long i)
        {
            if (i < 0x2710L)
            {
                return ConvertLarger(i);
            }
            return (ConvertLarger(KharejGhesmat(i, 0x3e8L)) + " هزار" + Space(ConvertLarg(Baghimande(i, 0x3e8L))) + ConvertLarg(Baghimande(i, 0x3e8L)));
        }

        private static string ConvertBiger(long i)
        {
            if (i < 0x186a0L)
            {
                return ConvertBig(i);
            }
            return (ConvertLarg(KharejGhesmat(i, 0x3e8L)) + " هزار" + Space(ConvertBig(Baghimande(i, 0x3e8L))) + ConvertBig(Baghimande(i, 0x3e8L)));
        }

        private static string ConvertHuge(long i)
        {
            if (i < 0xf4240L)
            {
                return ConvertBiger(i);
            }
            return (ConvertBiger(KharejGhesmat(i, 0xf4240L)) + " میلیون" + Space(ConvertBiger(Baghimande(i, 0xf4240L))) + ConvertBiger(Baghimande(i, 0xf4240L)));
        }

        private static string ConverTini(long i)
        {
            long num = i;
            if ((num <= 20L) && (num >= 0L))
            {
                switch (((int)num))
                {
                    case 0:
                        return " ";

                    case 1:
                        return "یک";

                    case 2:
                        return "دو";

                    case 3:
                        return "سه";

                    case 4:
                        return "چهار";

                    case 5:
                        return "پنج";

                    case 6:
                        return "شش";

                    case 7:
                        return "هفت";

                    case 8:
                        return "هشت";

                    case 9:
                        return "نه";

                    case 10:
                        return "ده";

                    case 11:
                        return "یازده";

                    case 12:
                        return "دوازده";

                    case 13:
                        return "سیزده";

                    case 14:
                        return "چهارده";

                    case 15:
                        return "پانزده";

                    case 0x10:
                        return "شانزده";

                    case 0x11:
                        return "هفده";

                    case 0x12:
                        return "هجده";

                    case 0x13:
                        return "نوزده";

                    case 20:
                        return "بیست";
                }
            }
            return "***";
        }

        private static string ConvertLarg(long i)
        {
            if (i < 100L)
            {
                return ConvertMedium(i);
            }
            return (ConvertSad(100L * KharejGhesmat(i, 100L)) + Space(ConvertMedium(Baghimande(i, 100L))) + ConvertMedium(Baghimande(i, 100L)));
        }

        private static string ConvertLarger(long i)
        {
            if (i < 0x3e8L)
            {
                return ConvertLarg(i);
            }
            return (ConvertLarg(KharejGhesmat(i, 0x3e8L)) + " هزار" + Space(ConvertLarg(Baghimande(i, 0x3e8L))) + ConvertLarg(Baghimande(i, 0x3e8L)));
        }

        private static string ConvertMedium(long i)
        {
            if (i < 0x15L)
            {
                return ConverTini(i);
            }
            long num = 10L * KharejGhesmat(i, 10L);
            return (ConverSmall(num) + Space(ConverTini(Baghimande(i, 10L))) + ConverTini(Baghimande(i, 10L)));
        }

        private static string ConvertSad(long i)
        {
            switch (i)
            {
                case 200L:
                    return "دویست";

                case 300L:
                    return "سیصد";

                case 400L:
                    return "چهارصد";

                case 0L:
                    return " ";

                case 100L:
                    return "صد";

                case 500L:
                    return "پانصد";

                case 600L:
                    return "ششصد";

                case 700L:
                    return "هفتصد";

                case 800L:
                    return "هشتصد";

                case 900L:
                    return "نهصد";

                case 0x3e8L:
                    return "هزار";
            }
            return "***";
        }

        private static string ConvertUlteraHuge(long i)
        {
            if (i < 0x3b9aca00L)
            {
                return ConvertHuge(i);
            }
            return (ConvertHuge(KharejGhesmat(i, 0x3b9aca00L)) + " میلیارد" + Space(ConvertHuge(Baghimande(i, 0x3b9aca00L))) + ConvertHuge(Baghimande(i, 0x3b9aca00L)) + " ريال").Replace("  ", " ");
        }

        private static long KharejGhesmat(long i, long j)
        {
            return (long)(((double)i) / ((double)j));
        }

        private static string Space(string digit)
        {
            return (((digit == "") || (digit == " ")) ? " " : " و ");
        }
    }


}
