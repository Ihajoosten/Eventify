using Eventify.Application.Interfaces.Commands.Venue;
using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Commands.Venue
{
    public class ChangeVenueAddressCommand : IChangeVenueAddressCommand
    {
        public Guid VenueId { get; set; }
        public Address NewVenueAddress { get; set; }
    }
}
