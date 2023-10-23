using Eventify.Application.Interfaces.Commands.Event;

namespace Eventify.Application.Commands.Event
{
    public class ChangeEventDateCommand : IChangeEventDateCommand
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
