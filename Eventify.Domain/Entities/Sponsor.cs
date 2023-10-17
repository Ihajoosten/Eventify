using Eventify.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Domain.Entities
{
    public class Sponsor : BaseEntity
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        public byte[]? Logo { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Website URL field is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string WebsiteUrl { get; set; }

        // Navigation properties
        public List<Event>? SponsoredEvents { get; set; } = new List<Event>();
    }
}
