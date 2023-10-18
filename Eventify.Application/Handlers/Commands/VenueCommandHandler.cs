using Eventify.Application.Interfaces.Commands;
using Eventify.Application.Interfaces.Commands.Venue;
using Eventify.Application.Interfaces.Dto;
using Eventify.Application.Interfaces.Handlers;

namespace Eventify.Application.Handlers.Commands
{
    public class VenueCommandHandler : ICommandHandler<IVenueDto, IVenueCommand>
    {
        public IVenueDto? Handle(IVenueCommand command)
        {
            if (command is ICreateVenueCommand createVenueCommand)
            {
                return null;
            }
            else if (command is IUpdateVenueCommand updateVenueCommand)
            {
                return null;
            }
            else if (command is IDeleteVenueCommand deleteVenueCommand)
            {
                return null;
            }
            else if (command is IChangeVenueAddressCommand changeVenueAddressCommand)
            {
                return null;
            }
            return null;
        }
    }
}
