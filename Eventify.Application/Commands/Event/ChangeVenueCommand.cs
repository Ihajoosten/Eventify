using Eventify.Application.Interfaces.Commands.Event;

namespace Eventify.Application.Commands.Event
{
    public class ChangeVenueCommand : IChangeEventVenueCommand
    {
        public Guid EventId { get; set; }
        public Guid NewVenueId { get; set; }
    }
}
