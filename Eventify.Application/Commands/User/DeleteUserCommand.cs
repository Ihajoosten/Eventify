using Eventify.Application.Interfaces.Commands.User;

namespace Eventify.Application.Commands.User
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        public Guid Id { get; set; }
    }
}
