using Eventify.Application.Interfaces.Commands.Base;
using Eventify.Application.Interfaces.Dto;

namespace Eventify.Application.Interfaces.Handlers
{
    public interface ICommandHandler<TDto, TCommand> where TCommand : ICommand where TDto : IDto
    {
        TDto? Handle(TCommand command);
    }
}
