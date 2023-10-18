using Eventify.Application.Interfaces.Dto;

namespace Eventify.Application.Dto
{
    public class SpeakerDto : ISpeakerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public byte[]? ProfileImage { get; set; }
        public string ContactEmail { get; set; }

        // Navigation properties
        public IEnumerable<ISessionDto>? Sessions { get; set; }
    }
}
