namespace Eventify.Application.Interfaces.Commands.Event
{
    public interface IChangeEventVenueCommand : IEventCommand
    {
        public Guid Id { get; set; }
        public Guid VenueId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
