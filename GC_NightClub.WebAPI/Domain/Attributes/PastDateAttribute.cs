using System.ComponentModel.DataAnnotations;

namespace GC_NightClub.WebAPI.Domain.Attributes
{
    public class PastDateAttribute(string propertyLabel = "Date") : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not DateTime date)
                return null;

            return date >= DateTime.Today
                ? new ValidationResult($"{propertyLabel} \"{date:dd/MM/yyyy}\" should be lower than current date.")
                : null;
        }
    }
}
