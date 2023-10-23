using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Infrastructure.EFRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eventify.Infrastructure.EFRepositories
{
    public class SponsorRepository : EFRepository<Sponsor>, ISponsorRepository
    {
        public SponsorRepository(IUnitOfWork unitOfWork, ILogger<SponsorRepository> logger) : base(unitOfWork, logger) { }

        public async Task<Sponsor?> GetSponsorForEventAsync(Guid eventId)
        {
            return await _unitOfWork.Set<Sponsor>().Join(_unitOfWork.Set<Event>(),
             sponsor => sponsor.Id, @event => @event.SponsorId, (sponsor, @event) => new { Sponsor = sponsor, Event = @event })
                .Where(joinResult => joinResult.Event.Id == eventId)
                .Select(joinResult => joinResult.Sponsor).FirstOrDefaultAsync();
        }
    }
}
