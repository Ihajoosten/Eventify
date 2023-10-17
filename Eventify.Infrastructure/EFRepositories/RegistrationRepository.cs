using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Infrastructure.EFRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eventify.Infrastructure.EFRepositories
{
    public class RegistrationRepository : EFRepository<Registration>, IRegistrationRepository
    {
        public RegistrationRepository(IUnitOfWork unitOfWork, ILogger<RegistrationRepository> logger) : base(unitOfWork, logger) { }

        public async Task<IEnumerable<User>?> GetRegisteredUsersForEventAsync(Guid eventId)
        {
            return await _unitOfWork.Set<User>().Join(_unitOfWork.Set<Registration>(), user => user.Id,
            registration => registration.UserId, (user, registration) => new { User = user, Registration = registration })
                    .Where(joinResult => joinResult.Registration.EventId == eventId)
                    .Select(joinResult => joinResult.User)
                    .ToListAsync();
        }
    }
}
