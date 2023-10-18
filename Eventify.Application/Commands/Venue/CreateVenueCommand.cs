using Eventify.Application.Interfaces.Commands.Venue;
using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Commands.Venue
{
    public class CreateVenueCommand : ICreateVenueCommand
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string ContactPerson { get; set; }
        public Address VenueAddress { get; set; }
    }
}
