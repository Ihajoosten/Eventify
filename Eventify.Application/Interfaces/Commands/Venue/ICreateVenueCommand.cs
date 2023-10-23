using Eventify.Application.Dto;

namespace Eventify.Application.Interfaces.Commands.Venue
{
    public interface ICreateVenueCommand
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string ContactPerson { get; set; }
        public AddressDto VenueAddress { get; set; }
    }
}
