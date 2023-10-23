namespace Eventify.Application.Dto
{
    public class RegistrationDto
    {
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }

        // Navigation properties
        public UserDto User { get; set; }
        public EventDto Event { get; set; }
    }
}
