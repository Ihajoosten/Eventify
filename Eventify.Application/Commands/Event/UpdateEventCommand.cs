using Eventify.Application.Interfaces.Commands.Event;

namespace Eventify.Application.Commands.Event
{
    public class UpdateEventCommand : IUpdateEventCommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EventUrl { get; set; }
        public bool IsRegistrationRequired { get; set; }
        public int MaximumAttendees { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
