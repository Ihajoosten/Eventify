using System.ComponentModel.DataAnnotations;

namespace Eventify.Domain.Attributes
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (propertyInfo == null)
            {
                return new ValidationResult($"Property {_comparisonProperty} not found.");
            }

            var comparisonValue = (DateTime)propertyInfo.GetValue(validationContext.ObjectInstance)!;

            if ((DateTime)value! <= comparisonValue)
            {
                return new ValidationResult(ErrorMessage ?? $"End date must be greater than {propertyInfo.Name}.");
            }

            return ValidationResult.Success!;
        }
    }
}
