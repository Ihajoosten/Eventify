using Eventify.Application.Interfaces.Commands.Venue;
using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Commands.Venue
{
    public class UpdateVenueCommand : IUpdateVenueCommand
    {
        public Guid VenueId { get; set; }
        public string NewName { get; set; }
        public int NewCapacity { get; set; }
        public string NewContactPerson { get; set; }
        public Address NewVenueAddress { get; set; }
    }
}
