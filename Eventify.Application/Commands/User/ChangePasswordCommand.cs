using Eventify.Application.Interfaces.Commands.User;

namespace Eventify.Application.Commands.User
{
    public class ChangePasswordCommand : IChangePasswordCommand
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
