namespace Eventify.Application.Dto
{
    public class EventDto
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
        public UserDto Organizer { get; set; }
        public VenueDto Venue { get; set; }
        public SponsorDto Sponsor { get; set; }
    }
}
