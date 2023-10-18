namespace Eventify.Application.Interfaces.Dto
{
    public interface ISessionDto : IDto
    {
        string Title { get; set; }
        string Description { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }

        // Navigation properties
        ISpeakerDto Speaker { get; set; }
        IEventDto Event { get; set; }
        IEnumerable<IAttendeeFeedbackDto>? Feedbacks { get; set; }
    }
}
