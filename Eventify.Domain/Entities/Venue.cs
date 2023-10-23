using Eventify.Domain.Entities.Base;
using Eventify.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Domain.Entities
{
    public class Venue : BaseEntity
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Capacity field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "The Contact Person field is required.")]
        [StringLength(50, ErrorMessage = "Contact Person Name exceed 50 characters.")]
        public string ContactPerson { get; set; }

        // Address owned property
        public Address VenueAddress { get; set; }

        // Navigation properties
        public List<Event>? Events { get; set; } = new List<Event>();
    }
}
