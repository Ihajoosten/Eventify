using System.ComponentModel.DataAnnotations;

namespace Eventify.Domain.ValueObjects
{
    public class Address
    {
        [Required(ErrorMessage = "The Street field is required.")]
        [StringLength(100, ErrorMessage = "Street cannot exceed 100 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "The City field is required.")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The State field is required.")]
        [StringLength(50, ErrorMessage = "State cannot exceed 50 characters.")]
        public string State { get; set; }

        [Required(ErrorMessage = "The ZipCode field is required.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "The State field is required.")]
        [StringLength(50, ErrorMessage = "State cannot exceed 50 characters.")]
        public string Country { get; set; }

        public override string ToString()
        {
            // Return a formatted string representing the address
            return $"{Street}, {City}, {State} {ZipCode}, {Country}";
        }
    }
}
