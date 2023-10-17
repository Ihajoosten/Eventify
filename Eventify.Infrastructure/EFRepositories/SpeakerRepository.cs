using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Infrastructure.EFRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eventify.Infrastructure.EFRepositories
{
    public class SpeakerRepository : EFRepository<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(IUnitOfWork unitOfWork, ILogger<SpeakerRepository> logger) : base(unitOfWork, logger) { }

        public async Task<IEnumerable<Speaker>?> GetSpeakersForEventAsync(Guid eventId)
        {
            return await _unitOfWork.Set<Speaker>().Join(_unitOfWork.Set<Session>(),
             speaker => speaker.Id, session => session.SpeakerId, (speaker, session) => new { Speaker = speaker, Session = session })
                .Join(_unitOfWork.Set<Event>(), joinedResult => joinedResult.Session.EventId, @event => @event.Id, (joinedResult, @event) => new { Speaker = joinedResult.Speaker, Event = @event })
                        .Where(joinResult => joinResult.Event.Id == eventId)
                        .Select(joinResult => joinResult.Speaker)
                        .ToListAsync();
        }
    }
}
