namespace Eventify.Application.Interfaces.Commands.Event
{
    public interface IChangeEventDateCommand : IEventCommand 
    {
        public Guid EventId { get; set; }
        public DateTime NewStartDate { get; set; }
        public DateTime NewEndDate { get; set; }
    }
}
