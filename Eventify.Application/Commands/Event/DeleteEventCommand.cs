using Eventify.Application.Interfaces.Commands.Event;

namespace Eventify.Application.Commands.Event
{
    public class DeleteEventCommand : IDeleteEventCommand
    {
        public Guid Id { get; set; }
    }
}
