using Eventify.Application.Interfaces.Commands.User;

namespace Eventify.Application.Commands.User
{
    public class ChangePasswordCommand : IChangePasswordCommand
    {
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
