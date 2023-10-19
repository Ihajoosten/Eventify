using Eventify.Domain.Entities;

namespace Eventify.Application.Interfaces.Commands.User
{
    public interface IChangeUserRoleCommand : IUserCommand
    {
        public Guid Id { get; set; }
        public UserRole Role { get; set; }
    }
}
