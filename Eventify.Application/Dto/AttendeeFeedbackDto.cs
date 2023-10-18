using Eventify.Application.Interfaces.Dto;

namespace Eventify.Application.Dto
{
    public class AttendeeFeedbackDto : IAttendeeFeedbackDto
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

        // Navigation properties
        public ISessionDto Session { get; set; }
        public IUserDto User { get; set; }
    }
}
