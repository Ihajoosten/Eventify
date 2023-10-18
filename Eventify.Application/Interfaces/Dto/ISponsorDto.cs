namespace Eventify.Application.Interfaces.Dto
{
    public interface ISponsorDto : IDto
    {
        string Name { get; set; }
        byte[]? Logo { get; set; }
        string Description { get; set; }
        string WebsiteUrl { get; set; }

        // Navigation properties
        IEnumerable<IEventDto>? SponsoredEvents { get; set; }
    }
}