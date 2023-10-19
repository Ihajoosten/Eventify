using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Interfaces.Commands.User
{
    public interface IUpdateUserCommand : IUserCommand
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address UserAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
