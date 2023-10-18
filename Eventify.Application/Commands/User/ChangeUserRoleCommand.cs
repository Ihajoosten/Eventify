using Eventify.Application.Interfaces.Commands.User;
using Eventify.Domain.Entities;

namespace Eventify.Application.Commands.User
{
    public class ChangeUserRoleCommand : IChangeUserRoleCommand
    {
        public Guid UserId { get; set; }
        public UserRole NewRole { get; set; }
    }
}
