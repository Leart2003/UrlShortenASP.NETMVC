using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Shortly.Redirect.Helpers.Validators
{
    public class CustomEmailValidator : ValidationAttribute
    {
        private const string _emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var email = value as string;

            if (string.IsNullOrWhiteSpace(email))
            {
              
                return ValidationResult.Success;
            }

            if (Regex.IsMatch(email, _emailPattern))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Invalid email format.");
        }
    }
}
