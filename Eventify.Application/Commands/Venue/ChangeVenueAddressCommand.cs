using Eventify.Application.Interfaces.Commands.Venue;
using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Commands.Venue
{
    public class ChangeVenueAddressCommand : IChangeVenueAddressCommand
    {
        public Guid Id { get; set; }
        public Address VenueAddress { get; set; }
    }
}
