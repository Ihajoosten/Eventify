namespace Eventify.Application.Interfaces.Dto
{
    public interface IAttendeeFeedbackDto : IDto
    {
        int Rating { get; set; }
        string? Comment { get; set; }

        // Navigation properties
        ISessionDto Session { get; set; }
        IUserDto User { get; set; }
    }
}
