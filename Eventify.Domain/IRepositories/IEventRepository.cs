using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories.Base;

namespace Eventify.Domain.IRepositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<IEnumerable<Event>?> GetUpcomingEventsAsync();
        Task<IEnumerable<Event>?> GetEventsByOrganizer(Guid organizerId);
        Task<IEnumerable<Event>?> GetEventsByVenue(Guid venueName);
        Task<IEnumerable<Event>?> GetEventsBySponsor(Guid venueName);
    }
}
