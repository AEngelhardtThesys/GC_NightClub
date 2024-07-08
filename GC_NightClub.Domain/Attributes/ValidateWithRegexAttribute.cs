using System.ComponentModel.DataAnnotations;
using static System.Text.RegularExpressions.Regex;

namespace GC_NightClub.Domain.Attributes
{
    public class ValidateWithRegexAttribute(string rx, string propertyLabel, string propertyFormat) : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var strVal = value as string;

            if (strVal == null)
            {
                return null;
            }

            if (!IsMatch(strVal, rx))
            {
                return new ValidationResult(
                    $"{propertyLabel} \"{strVal}\" wrongly formatted, format should be \"{propertyFormat}\".");
            }

            return base.IsValid(value, validationContext);
        }
    }
}
