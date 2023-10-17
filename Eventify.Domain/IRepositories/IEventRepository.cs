using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories.Base;

namespace Eventify.Domain.IRepositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<IEnumerable<Event>> GetUpcomingEventsAsync();
        Task<IEnumerable<Event>> GetEventsByOrganizer(string email);
        Task<IEnumerable<Event>> GetEventsByVenue(Guid venueId);
        Task<IEnumerable<Event>> GetEventsBySponsor(Guid sponsorId);
    }
}
