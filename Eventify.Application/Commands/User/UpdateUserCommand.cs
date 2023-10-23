using Eventify.Application.Dto;
using Eventify.Application.Interfaces.Commands.User;

namespace Eventify.Application.Commands.User
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDto UserAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
