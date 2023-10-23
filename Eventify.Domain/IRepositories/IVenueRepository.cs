using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories.Base;

namespace Eventify.Domain.IRepositories
{
    public interface IVenueRepository : IRepository<Venue>
    {
        Task<IEnumerable<Venue>?> GetVenuesByCountry(string country);
        Task<IEnumerable<Venue>?> GetVenuesByState(string state);    
    }
}
