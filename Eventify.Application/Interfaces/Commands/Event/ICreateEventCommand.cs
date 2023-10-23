namespace Eventify.Application.Interfaces.Commands.Event
{
    public interface ICreateEventCommand : IEventCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventUrl { get; set; }
        public bool IsRegistrationRequired { get; set; }
        public int MaximumAttendees { get; set; }
        public Guid OrganizerId { get; set; }
        public Guid VenueId { get; set; }
        public Guid SponsorId { get; set; }
    }
}
