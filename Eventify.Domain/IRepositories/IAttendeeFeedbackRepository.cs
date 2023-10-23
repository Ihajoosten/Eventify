using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories.Base;

namespace Eventify.Domain.IRepositories
{
    public interface IAttendeeFeedbackRepository : IRepository<AttendeeFeedback>
    {
        Task<IEnumerable<AttendeeFeedback>?> GetFeedbackForSessionAsync(Guid sessionId);
        Task<double> GetAverageFeedbackForSession(Guid sessionId);
        Task<int> GetAmountOfFeedbackRatingsPerRating(int ratingAmount);
    }
}