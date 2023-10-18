namespace Eventify.Application.Interfaces.Commands.Event
{
    public interface IChangeEventDateCommand : IEventCommand 
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
