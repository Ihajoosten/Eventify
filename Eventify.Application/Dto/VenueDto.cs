using Eventify.Application.Interfaces.Dto;

namespace Eventify.Application.Dto
{
    public class VenueDto : IVenueDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string ContactPerson { get; set; }
        public IAddressDto VenueAddress { get; set; }

        // Related objects
        public IEnumerable<IEventDto>? Events { get; set; }
    }
}
