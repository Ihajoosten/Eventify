using Eventify.Application.Interfaces.Dto;

namespace Eventify.Application.Dto
{
    public class RegistrationDto : IRegistrationDto
    {
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }

        // Navigation properties
        public IUserDto User { get; set; }
        public IEventDto Event { get; set; }
    }
}
