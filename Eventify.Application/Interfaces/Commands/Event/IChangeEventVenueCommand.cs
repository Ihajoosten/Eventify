namespace Eventify.Application.Interfaces.Commands.Event
{
    public interface IChangeEventVenueCommand : IEventCommand
    {
        public Guid EventId { get; set; }
        public Guid NewVenueId { get; set; }
    }
}
