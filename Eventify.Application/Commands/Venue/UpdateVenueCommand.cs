using Eventify.Application.Dto;
using Eventify.Application.Interfaces.Commands.Venue;

namespace Eventify.Application.Commands.Venue
{
    public class UpdateVenueCommand : IUpdateVenueCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string ContactPerson { get; set; }
        public AddressDto VenueAddress { get; set; }
    }
}
