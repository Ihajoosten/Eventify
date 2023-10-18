using Eventify.Application.Interfaces.Commands.Event;

namespace Eventify.Application.Commands.Event
{
    internal class DeleteEventCommand : IDeleteEventCommand
    {
        public Guid EventId { get; set; }
    }
}
