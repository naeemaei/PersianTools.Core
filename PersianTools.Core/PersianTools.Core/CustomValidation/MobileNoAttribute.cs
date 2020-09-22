using System.ComponentModel.DataAnnotations;

namespace PersianTools.Core.CustomValidation
{
	class MobileNoAttribute : ValidationAttribute
	{
		protected MobileNoAttribute()
		{
		}
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value.ToString().IsMobileNoValid())
				return ValidationResult.Success;
			return new ValidationResult("شماره موبایل وارد شده معتبر نیست");
		}
	}
}
