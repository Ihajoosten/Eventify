using Eventify.Application.Interfaces.Commands.Venue;

namespace Eventify.Application.Commands.Venue
{
    public class DeleteVenueCommand : IDeleteVenueCommand
    {
        public Guid Id { get; set; }
    }
}
