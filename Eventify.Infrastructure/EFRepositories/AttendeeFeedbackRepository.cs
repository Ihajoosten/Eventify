using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Infrastructure.EFRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eventify.Infrastructure.EFRepositories
{
    public class AttendeeFeedbackRepository : EFRepository<AttendeeFeedback>, IAttendeeFeedbackRepository
    {
        public AttendeeFeedbackRepository(IUnitOfWork unitOfWork, ILogger<AttendeeFeedbackRepository> logger) : base(unitOfWork, logger) { }

        public async Task<int> GetAmountOfFeedbackRatingsPerRating(int ratingAmount)
        {
            return await _unitOfWork.Set<AttendeeFeedback>()
                .CountAsync(feedback => feedback.Rating == ratingAmount);
        }

        public async Task<double> GetAverageFeedbackForSession(Guid sessionId)
        {
            return await _unitOfWork.Set<AttendeeFeedback>()
                .Where(feedback => feedback.SessionId == sessionId)
                .AverageAsync(feedback => feedback.Rating);
        }

        public async Task<IEnumerable<AttendeeFeedback>?> GetFeedbackForSessionAsync(Guid sessionId)
        {
            return await _unitOfWork.Set<AttendeeFeedback>()
                .Where(feedback => feedback.SessionId == sessionId)
                .ToListAsync();
        }
    }
}