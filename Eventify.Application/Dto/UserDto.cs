using Eventify.Domain.Entities;

namespace Eventify.Application.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressDto UserAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }

        // Navigation properties
        public IEnumerable<AttendeeFeedbackDto> Feedbacks { get; set; }
        public IEnumerable<EventDto> OrganizedEvents { get; set; }
        public IEnumerable<RegistrationDto> Registrations { get; set; }
    }
}
