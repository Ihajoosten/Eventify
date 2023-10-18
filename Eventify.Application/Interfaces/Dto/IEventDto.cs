namespace Eventify.Application.Interfaces.Dto
{
    public interface IEventDto : IDto
    {
        string Title { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string EventUrl { get; set; }
        bool IsRegistrationRequired { get; set; }
        int MaximumAttendees { get; set; }

        // Navigation properties
        IUserDto Organizer { get; set; }
        IVenueDto Venue { get; set; }
        ISponsorDto Sponsor { get; set; }
    }
}
