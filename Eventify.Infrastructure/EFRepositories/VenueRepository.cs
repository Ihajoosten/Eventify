using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Infrastructure.EFRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eventify.Infrastructure.EFRepositories
{
    public class VenueRepository : EFRepository<Venue>, IVenueRepository
    {
        public VenueRepository(IUnitOfWork unitOfWork, ILogger<VenueRepository> logger) : base(unitOfWork, logger) { }

        public async Task<IEnumerable<Venue>?> GetVenuesByCountry(string country)
        {
            return await _unitOfWork.Set<Venue>()
                .Where(v => v.VenueAddress.Country == country)
                .ToListAsync();
        }

        public async Task<IEnumerable<Venue>?> GetVenuesByState(string state)
        {
            return await _unitOfWork.Set<Venue>()
                .Where(v => v.VenueAddress.State == state)
                .ToListAsync();
        }
    }
}