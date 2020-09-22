using System.ComponentModel.DataAnnotations;

namespace PersianTools.Core.CustomValidation
{
	public class NationalCodeAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (!PersianHelper.IsValidNationalCode(value.ToString()))
			{
				return new ValidationResult("کد ملی وارد شده معتبر نمی باشد");
			}
			return ValidationResult.Success;
		}
	}
}
