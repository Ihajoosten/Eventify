using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Interfaces.Commands.Venue
{
    public interface IUpdateVenueCommand : IVenueCommand
    {
        public Guid VenueId { get; set; }
        public string NewName { get; set; }
        public int NewCapacity { get; set; }
        public string NewContactPerson { get; set; }
        public Address NewVenueAddress { get; set; }
    }
}
