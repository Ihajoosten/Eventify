namespace Eventify.Application.Interfaces.Commands.User
{
    public interface IChangePasswordCommand : IUserCommand
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
