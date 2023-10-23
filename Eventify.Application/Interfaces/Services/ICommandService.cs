using Eventify.Application.Interfaces.Commands.Base;

namespace Eventify.Application.Interfaces.Services
{
    public interface ICommandService<T> where T : class
    {
        T HandleCommand(ICommand command);
    }
}
