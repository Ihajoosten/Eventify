using Eventify.Application.Interfaces.Commands.Venue;
using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Commands.Venue
{
    public class UpdateVenueCommand : IUpdateVenueCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string ContactPerson { get; set; }
        public Address VenueAddress { get; set; }
    }
}
