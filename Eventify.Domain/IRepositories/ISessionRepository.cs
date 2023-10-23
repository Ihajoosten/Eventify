using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories.Base;

namespace Eventify.Domain.IRepositories
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task<IEnumerable<Session>?> GetSessionsForEventAsync(Guid eventId);
    }
}
