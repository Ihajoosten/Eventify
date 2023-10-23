namespace Eventify.Application.Dto
{
    public class AttendeeFeedbackDto
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

        // Navigation properties
        public SessionDto Session { get; set; }
        public UserDto User { get; set; }
    }
}
