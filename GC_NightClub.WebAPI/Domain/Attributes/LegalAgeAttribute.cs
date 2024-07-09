using System.ComponentModel.DataAnnotations;

namespace GC_NightClub.WebAPI.Domain.Attributes
{
    public class LegalAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not DateTime date)
                return null;

            return date >= DateTime.Today.AddYears(-18)
                ? new ValidationResult("Minors can't subscribe !")
                : null;
        }
    }
}
