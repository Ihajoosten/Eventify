namespace Eventify.Application.Dto
{
    public class SessionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Navigation properties
        public SpeakerDto Speaker { get; set; }
        public EventDto Event { get; set; }
        public IEnumerable<AttendeeFeedbackDto>? Feedbacks { get; set; }
    }
}
