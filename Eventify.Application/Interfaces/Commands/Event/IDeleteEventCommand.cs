namespace Eventify.Application.Interfaces.Commands.Event
{
    public interface IDeleteEventCommand : IEventCommand
    {
        public Guid EventId { get; set; }
    }
}
