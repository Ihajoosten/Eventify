using System.ComponentModel.DataAnnotations;

namespace Eventify.Domain.Entities
{
    public class Registration
    {
        [Required(ErrorMessage = "The Id field is required.")]
        public required Guid Id { get; set; }

        [Required(ErrorMessage = "The UserId field is required.")]
        public required Guid UserId { get; set; }

        [Required(ErrorMessage = "The EventId field is required.")]
        public required Guid EventId { get; set; }

        [DataType(DataType.DateTime)]
        public required DateTime RegistrationDate { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Event Event { get; set; }
    }
}