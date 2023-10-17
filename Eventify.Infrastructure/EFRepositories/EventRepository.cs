using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Infrastructure.EFRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eventify.Infrastructure.EFRepositories
{
    public class EventRepository : EFRepository<Event>, IEventRepository
    {
        public EventRepository(IUnitOfWork unitOfWork, ILogger<EventRepository> logger) : base(unitOfWork, logger) { }

        public async Task<IEnumerable<Event>?> GetEventsByOrganizer(string email)
        {
            return await _unitOfWork.Set<Event>()
                .Where(e => e.Organizer.Email == email)
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>?> GetEventsBySponsor(Guid sponsorId)
        {
            return await _unitOfWork.Set<Event>()
                .Where(e => e.SponsorId == sponsorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>?> GetEventsByVenue(Guid venueId)
        {
            return await _unitOfWork.Set<Event>()
                .Where(e => e.VenueId == venueId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>?> GetUpcomingEventsAsync()
        {
            return await _unitOfWork.Set<Event>()
                .Where(e => e.EndDate > DateTime.Now)
                .ToListAsync();
        }
    }
}
