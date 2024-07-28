using System.ComponentModel.DataAnnotations;

namespace Appointment.Models.Validation
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext ctx)
        {
            if (value is DateTime)
            {
                DateTime datetoCheck = (DateTime)value;
                if (datetoCheck > DateTime.Today)
                {
                    return ValidationResult.Success!;
                }
            }
            string msg = base.ErrorMessage ?? $"{ctx.DisplayName} Appointment cant be set in the past.";
            return new ValidationResult(msg);
        }
    }
}
