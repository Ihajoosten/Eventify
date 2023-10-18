using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Interfaces.Commands.Venue
{
    public interface IChangeVenueAddressCommand : IVenueCommand
    {
        public Guid VenueId { get; set; }
        public Address NewVenueAddress { get; set; }
    }
}
