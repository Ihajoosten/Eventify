using Eventify.Application.Dto;
using Eventify.Application.Interfaces.Commands.Venue;

namespace Eventify.Application.Commands.Venue
{
    public class ChangeVenueAddressCommand : IChangeVenueAddressCommand
    {
        public Guid Id { get; set; }
        public AddressDto VenueAddress { get; set; }
    }
}
