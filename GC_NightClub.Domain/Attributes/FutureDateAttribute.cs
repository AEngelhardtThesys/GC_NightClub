using System.ComponentModel.DataAnnotations;

namespace GC_NightClub.Domain.Attributes
{
    internal class FutureDateAttribute(string propertyLabel = "Date") : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not DateTime date)
                return null;

            return date < DateTime.Today
                ? new ValidationResult($"{propertyLabel} \"{date:dd/MM/yyyy}\" should be higher than current date.")
                : base.IsValid(value, validationContext);
        }
    }
}
