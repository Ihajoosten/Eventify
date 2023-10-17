using Eventify.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Domain.Entities
{
    public class AttendeeFeedback : BaseEntity
    {
        [Required(ErrorMessage = "The Rating field is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public required int Rating { get; set; }

        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "The SessionId field is required.")]
        public required Guid SessionId { get; set; }

        [Required(ErrorMessage = "The UserId field is required.")]
        public required Guid UserId { get; set; }

        // Navigation properties
        public Session Session { get; set; }
        public User User { get; set; }
    }
}
