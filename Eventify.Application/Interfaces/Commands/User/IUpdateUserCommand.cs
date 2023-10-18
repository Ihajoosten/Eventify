using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Interfaces.Commands.User
{
    public interface IUpdateUserCommand : IUserCommand
    {
        public Guid UserId { get; set; }
        public string NewUsername { get; set; }
        public string NewEmail { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
        public Address NewUserAddress { get; set; }
        public string NewPhoneNumber { get; set; }
    }
}
