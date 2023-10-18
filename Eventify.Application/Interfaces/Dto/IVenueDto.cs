namespace Eventify.Application.Interfaces.Dto
{
    public interface IVenueDto : IDto
    {
        string Name { get; set; }
        int Capacity { get; set; }
        string ContactPerson { get; set; }
        IAddressDto VenueAddress { get; set; }

        // Navigation properties
        IEnumerable<IEventDto>? Events { get; set; }
    }
}
