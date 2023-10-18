using Eventify.Application.Interfaces.Commands.Event;

namespace Eventify.Application.Commands.Event
{
    public class ChangeEventDateCommand : IChangeEventDateCommand
    {
        public Guid EventId { get; set; }
        public DateTime NewStartDate { get; set; }
        public DateTime NewEndDate { get; set; }
    }
}
