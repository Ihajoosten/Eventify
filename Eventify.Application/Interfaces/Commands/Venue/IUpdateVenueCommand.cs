using Eventify.Application.Interfaces.Dto;
using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Interfaces.Commands.Venue
{
    public interface IUpdateVenueCommand : IVenueCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string ContactPerson { get; set; }
        public Address VenueAddress { get; set; }
    }
}
