using System;
using System.ComponentModel.DataAnnotations;

namespace PlannR.App.Infrastructure.Validation
{
    public class MustMatchAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public MustMatchAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage ??= ErrorMessageString;
            var currentValue = value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (!currentValue.Equals(comparisonValue))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
