using Eventify.Domain.Attributes;
using Eventify.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Domain.Entities
{
    public class Event : BaseEntity
    {
        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "The StartDate field is required.")]
        [DataType(DataType.DateTime)]
        public required DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The EndDate field is required.")]
        [DataType(DataType.DateTime)]
        [DateGreaterThan("StartDate", ErrorMessage = "End date must be greater than Start date.")]
        public required DateTime EndDate { get; set; }

        [Required(ErrorMessage = "The Event URL field is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public required string EventUrl { get; set; }

        [Required(ErrorMessage = "The OrganizerEmail field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string OrganizerEmail { get; set; }

        [RegularExpression(@"^(\+\d{1,3}[-.\s]?)?(\d{1,4}[-.\s]?){1,14}\d{1,4}$", ErrorMessage = "Invalid phone number format.")]
        public required string OrganizerPhoneNumber { get; set; }

        [Required(ErrorMessage = "The IsRegistrationRequired field is required.")]
        public required bool IsRegistrationRequired { get; set; }

        [Required(ErrorMessage = "The MaximumAttendees field is required.")]
        public required int MaximumAttendees { get; set; }

        [Required(ErrorMessage = "The VenueId field is required.")]
        public required Guid VenueId { get; set; }

        [Required(ErrorMessage = "The SponsorId field is required.")]
        public required Guid SponsorId { get; set; }

        // Navigation properties
        public Venue Venue { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}
