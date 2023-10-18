namespace Eventify.Application.Interfaces.Commands.Event
{
    public interface IUpdateEventCommand : IEventCommand 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EventUrl { get; set; }
        public bool IsRegistrationRequired { get; set; }
        public int MaximumAttendees { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
