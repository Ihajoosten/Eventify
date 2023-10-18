using Eventify.Application.Interfaces.Commands;
using Eventify.Application.Interfaces.Dto;
using Eventify.Application.Interfaces.Handlers.Base;

namespace Eventify.Application.Interfaces.Handlers
{
    public interface IVenueCommandHandler : ICommandHandler<IVenueDto, IVenueCommand> { }
}
