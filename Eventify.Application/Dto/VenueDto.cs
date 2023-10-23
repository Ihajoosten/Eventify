namespace Eventify.Application.Dto
{
    public class VenueDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string ContactPerson { get; set; }
        public AddressDto VenueAddress { get; set; }

        // Related objects
        public IEnumerable<EventDto>? Events { get; set; }
    }
}
