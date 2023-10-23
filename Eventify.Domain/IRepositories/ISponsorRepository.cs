using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories.Base;

namespace Eventify.Domain.IRepositories
{
    public interface ISponsorRepository : IRepository<Sponsor>
    {
        Task<Sponsor?> GetSponsorForEventAsync(Guid eventId);
    }
}
