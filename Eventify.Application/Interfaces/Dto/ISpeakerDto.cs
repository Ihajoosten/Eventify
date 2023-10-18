namespace Eventify.Application.Interfaces.Dto
{
    public interface ISpeakerDto : IDto
    {
        string Name { get; set; }
        string Bio { get; set; }
        byte[]? ProfileImage { get; set; }
        string ContactEmail { get; set; }

        // Navigation properties
        IEnumerable<ISessionDto>? Sessions { get; set; }
    }
}
