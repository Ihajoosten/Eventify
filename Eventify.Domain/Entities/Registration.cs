using System.ComponentModel.DataAnnotations;

namespace Eventify.Domain.Entities
{
    public class Registration
    {
        [Required(ErrorMessage = "The Id field is required.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The UserId field is required.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "The EventId field is required.")]
        public Guid EventId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Event Event { get; set; }
    }
}