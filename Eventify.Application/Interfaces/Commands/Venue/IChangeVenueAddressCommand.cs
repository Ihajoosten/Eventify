using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Interfaces.Commands.Venue
{
    public interface IChangeVenueAddressCommand : IVenueCommand
    {
        public Guid Id { get; set; }
        public Address VenueAddress { get; set; }
    }
}
