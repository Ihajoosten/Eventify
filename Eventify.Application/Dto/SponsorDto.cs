namespace Eventify.Application.Dto
{
    public class SponsorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[]? Logo { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }

        // Related objects
        public IEnumerable<EventDto>? SponsoredEvents { get; set; }
    }
}