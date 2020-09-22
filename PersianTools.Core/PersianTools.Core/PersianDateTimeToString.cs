using PersianTools.Core;
using System;

namespace PersianTools.Core
{
    public partial class PersianDateTime
    {
        /// <summary>
        /// شنبه بیست آذر سال یکهزار سیصد و نود وهفت ساعت هفت و سی دقیقه و بیست ثانیه
        /// </summary>
        /// <returns></returns>
        public string ToLongStringYMDHMS()
        {
            return $"{this.DayOfWeek} {CharacterUtil.Convert(this.Day)} {months[this.Month]} سال  {CharacterUtil.Convert(this.Year)} ساعت {CharacterUtil.Convert(this.Hour)} و {CharacterUtil.Convert(this.Minute)} دقیقه و {CharacterUtil.Convert(this.Second)} ثانیه";
        }

        /// <summary>
        /// شنبه بیست آذر سال یکهزار سیصد و نود وهفت ساعت هفت و سی دقیقه
        /// </summary>
        /// <returns></returns>
        public string ToLongStringYMDHM()
        {
            return $"{DayOfWeek} {CharacterUtil.Convert(this.Day)} {months[this.Month]} سال  {CharacterUtil.Convert(this.Year)} ساعت {CharacterUtil.Convert(this.Hour)} و {CharacterUtil.Convert(this.Minute)} دقیقه";
        }

        /// <summary>
        /// شنبه بیست آذر سال یکهزار سیصد و نود وهفت
        /// </summary>
        /// <returns></returns>
        public string ToLongStringYMD()
        {
            return $"{DayOfWeek} {CharacterUtil.Convert(this.Day)} {months[this.Month]} سال  {CharacterUtil.Convert(this.Year)}";
        }

        /// <summary>
        /// ساعت پانزده و سی دقیقه و ده ثانیه
        /// </summary>
        /// <returns></returns>
        public string ToLongStringHMS()
        {
            return $"ساعت {CharacterUtil.Convert(this.Hour)} و {CharacterUtil.Convert(this.Minute)} دقیقه و {CharacterUtil.Convert(this.Second)} ثانیه";
        }

        /// <summary>
        /// ساعت پانزده و سی دقیقه
        /// </summary>
        /// <returns></returns>
        public string ToLongStringHM()
        {
            return $"ساعت {CharacterUtil.Convert(this.Hour)} و {CharacterUtil.Convert(this.Minute)} دقیقه";
        }

        public override string ToString()
        {
            return $"{this.Year}/{this.Month.ToString("00")}/{this.Day.ToString("00")}";
        }

    }
}
