using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Infrastructure.EFRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eventify.Infrastructure.EFRepositories
{
    public class SessionRepository : EFRepository<Session>, ISessionRepository
    {
        public SessionRepository(IUnitOfWork unitOfWork, ILogger<SessionRepository> logger) : base(unitOfWork, logger) { }

        public async Task<IEnumerable<Session>?> GetSessionsForEventAsync(Guid eventId) =>
            await _unitOfWork.Set<Session>().Where(s => s.EventId == eventId).ToListAsync();
    }
}
