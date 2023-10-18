using Eventify.Application.Interfaces.Dto;

namespace Eventify.Application.Dto
{
    internal class SponsorDto : ISponsorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[]? Logo { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }

        // Related objects
        public IEnumerable<IEventDto>? SponsoredEvents { get; set; }
    }
}