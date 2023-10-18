using Eventify.Application.Interfaces.Dto;

namespace Eventify.Application.Dto
{
    public class SessionDto : ISessionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Navigation properties
        public ISpeakerDto Speaker { get; set; }
        public IEventDto Event { get; set; }
        public IEnumerable<IAttendeeFeedbackDto>? Feedbacks { get; set; }
    }
}
