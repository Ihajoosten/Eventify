using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories.Base;

namespace Eventify.Domain.IRepositories
{
    public interface ISpeakerRepository : IRepository<Speaker>
    {
        Task<IEnumerable<Speaker>> GetSpeakersForEventAsync(Guid eventId);
    }
}
