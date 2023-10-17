using Eventify.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Domain.Entities
{
    public class Speaker : BaseEntity
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Bio field is required.")]
        [StringLength(500, ErrorMessage = "Bio cannot exceed 500 characters.")]
        public string Bio { get; set; }

        public byte[]? ProfileImage { get; set; }

        [Required(ErrorMessage = "The ContactEmail field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string ContactEmail { get; set; }

        // Navigation properties
        public List<Session>? Sessions { get; set; } = new List<Session>();
    }
}
