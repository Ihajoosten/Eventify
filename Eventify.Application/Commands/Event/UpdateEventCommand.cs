using Eventify.Application.Interfaces.Commands.Event;

namespace Eventify.Application.Commands.Event
{
    public class UpdateEventCommand : IUpdateEventCommand
    {
        public Guid EventId { get; set; }
        public string NewTitle { get; set; }
        public string NewDescription { get; set; }
        public string NewEventUrl { get; set; }
        public bool NewIsRegistrationRequired { get; set; }
        public int NewMaximumAttendees { get; set; }
    }
}
