using Eventify.Application.Interfaces.Commands.User;
using Eventify.Domain.Entities;
using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Commands.User
{
    public class CreateUserCommand : ICreateUserCommand
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address UserAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
    }
}
