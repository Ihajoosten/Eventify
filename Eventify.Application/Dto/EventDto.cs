using Eventify.Application.Interfaces.Dto;

namespace Eventify.Application.Dto
{
    public class EventDto : IEventDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventUrl { get; set; }
        public bool IsRegistrationRequired { get; set; }
        public int MaximumAttendees { get; set; }

        // Related objects
        public IUserDto Organizer { get; set; }
        public IVenueDto Venue { get; set; }
        public ISponsorDto Sponsor { get; set; }
    }
}
