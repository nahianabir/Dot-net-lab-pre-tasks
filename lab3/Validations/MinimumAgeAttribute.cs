using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
namespace lab3.Validations
{
    public class MinimumAgeAttribute : ValidationAttribute
    {

        private readonly int _minimumAge;
        public MinimumAgeAttribute(int minimumAge)

        {
            _minimumAge = minimumAge;
            ErrorMessage = $"Student must be at least {minimumAge} years old";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value is DateTime dateOfBirth)
            {
                //Date of birth must be in past

                if (dateOfBirth >= DateTime.Today)
                {
                    return new ValidationResult("Date of birth must be in past");
                }


                //calculate age

                int age = DateTime.Today.Year - dateOfBirth.Year;
                if (dateOfBirth > DateTime.Today.AddYears(-age)) age --;

                if (age < _minimumAge)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }

    }
}
