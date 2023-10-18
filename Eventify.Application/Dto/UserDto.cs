using Eventify.Application.Interfaces.Dto;
using Eventify.Domain.Entities;

namespace Eventify.Application.Dto
{
    public class UserDto : IUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IAddressDto UserAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
    }
}
