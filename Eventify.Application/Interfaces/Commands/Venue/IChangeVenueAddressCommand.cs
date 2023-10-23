using Eventify.Application.Dto;

namespace Eventify.Application.Interfaces.Commands.Venue
{
    public interface IChangeVenueAddressCommand : IVenueCommand
    {
        public Guid Id { get; set; }
        public AddressDto VenueAddress { get; set; }
    }
}
