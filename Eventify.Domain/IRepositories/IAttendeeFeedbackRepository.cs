using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories.Base;

namespace Eventify.Domain.IRepositories
{
    internal interface IAttendeeFeedbackRepository : IRepository<AttendeeFeedback>
    {
        Task<AttendeeFeedback> GetFeedbackForSessionAsync(int sessionId);
        Task<double> GetAverageFeedbackForSession(int sessionId);
        Task<int> GetAmountOfFeedbackRatingsPerRating(int ratingAmount);
    }
}