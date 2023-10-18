namespace Eventify.Application.Interfaces.Dto
{
    public interface IRegistrationDto : IDto
    {
        DateTime RegistrationDate { get; set; }

        // Navigation properties
        IUserDto User { get; set; }
        IEventDto Event { get; set; }
    }
}
