using Eventify.Application.Interfaces.Commands;
using Eventify.Application.Interfaces.Commands.Event;
using Eventify.Application.Interfaces.Dto;
using Eventify.Application.Interfaces.Handlers;

namespace Eventify.Application.Handlers.Commands
{
    public class EventCommandHandler : ICommandHandler<IEventDto, IEventCommand>
    {
        public IEventDto? Handle(IEventCommand command)
        {
            if (command is ICreateEventCommand createEventCommand)
            {
                return null;
            }
            else if (command is IUpdateEventCommand updateEventCommand)
            {
                return null;
            }
            else if (command is IDeleteEventCommand deleteEventCommand)
            {
                return null;
            }
            else if (command is IChangeEventDateCommand changeEventDateCommand)
            {
                return null;
            }
            else if (command is IChangeEventVenueCommand changeEventVenueCommand)
            {
                return null;
            }
            return null;
        }
    }
}
