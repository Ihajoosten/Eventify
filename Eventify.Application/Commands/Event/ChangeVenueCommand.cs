using Eventify.Application.Interfaces.Commands.Event;

namespace Eventify.Application.Commands.Event
{
    public class ChangeVenueCommand : IChangeEventVenueCommand
    {
        public Guid Id { get; set; }
        public Guid VenueId { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
