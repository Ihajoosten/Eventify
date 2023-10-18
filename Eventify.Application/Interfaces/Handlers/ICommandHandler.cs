using Eventify.Application.Interfaces.Commands.Base;
using Eventify.Application.Interfaces.Dto;

namespace Eventify.Application.Interfaces.Handlers
{
    public interface ICommandHandler<TDto, TCommand> where TCommand : ICommand where TDto : IDto
    {
        Task<TDto?> Handle(TCommand command);
    }
}
