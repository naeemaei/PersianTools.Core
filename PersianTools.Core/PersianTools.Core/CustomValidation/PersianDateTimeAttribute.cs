using System;
using System.ComponentModel.DataAnnotations;

namespace PersianTools.Core.CustomValidation
{
    class PersianDateTimeAttribute : ValidationAttribute
    {
        protected PersianDateTimeAttribute()
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool result;
            if (value is PersianDateTime time)
                result = PersianHelper.IsPersianDateValid(time);
            else if (value is String)
                result = PersianHelper.IsPersianDateValid((string)value);
            else
                return new ValidationResult("تاریخ وارد شده معتبر نمی باشد");
            return result ? ValidationResult.Success : new ValidationResult("تاریخ وارد شده معتبر نمی باشد");
        }
    }
}
