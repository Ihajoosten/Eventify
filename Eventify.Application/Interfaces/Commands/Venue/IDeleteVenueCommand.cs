namespace Eventify.Application.Interfaces.Commands.Venue
{
    public interface IDeleteVenueCommand : IVenueCommand
    {
        public Guid VenueId { get; set; }
    }
}
