using System.ComponentModel.DataAnnotations;
using static System.Text.RegularExpressions.Regex;

namespace GC_NightClub.WebAPI.Domain.Attributes
{
    public class ValidateWithRegexAttribute(string rx, string propertyLabel, string propertyFormat) : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not string strVal)
                return null;

            return !IsMatch(strVal, rx)
                ? new ValidationResult(
                    $"{propertyLabel} \"{strVal}\" wrongly formatted, format should be \"{propertyFormat}\".")
                : null;
        }
    }
}
