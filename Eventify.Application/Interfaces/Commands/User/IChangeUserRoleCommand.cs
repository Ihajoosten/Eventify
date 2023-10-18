using Eventify.Domain.Entities;

namespace Eventify.Application.Interfaces.Commands.User
{
    public interface IChangeUserRoleCommand : IUserCommand
    {
        public Guid UserId { get; set; }
        public UserRole NewRole { get; set; }
    }
}
