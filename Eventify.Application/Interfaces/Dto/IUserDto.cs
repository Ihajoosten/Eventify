using Eventify.Domain.Entities;

namespace Eventify.Application.Interfaces.Dto
{
    public interface IUserDto : IDto
    {
        string Username { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
        IAddressDto UserAddress { get; set; }
        string PhoneNumber { get; set; }
        Gender Gender { get; set; }
        UserRole Role { get; set; }

        // Navigation properties
        IEnumerable<IAttendeeFeedbackDto> Feedbacks { get; set; }
        IEnumerable<IEventDto> OrganizedEvents { get; set; } 
        IEnumerable<IRegistrationDto> Registrations { get; set; } 
    }
}
