using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories.Base;

namespace Eventify.Domain.IRepositories
{
    public interface IRegistrationRepository : IRepository<Registration>
    {
        Task<IEnumerable<User>> GetRegisteredUsersForEventAsync(Guid eventId);
    }
}
