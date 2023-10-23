using Eventify.Application.Interfaces.Commands.Base;

namespace Eventify.Application.Interfaces.Handlers
{
    public interface ICommandHandler<TDto, TCommand> where TCommand : ICommand where TDto : class
    {
        Task<TDto?> Handle(TCommand command);
    }
}
