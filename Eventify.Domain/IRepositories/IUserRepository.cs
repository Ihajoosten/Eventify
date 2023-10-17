using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories.Base;

namespace Eventify.Domain.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>?> GetUsersByGenderAsync(Gender gender);
        Task<IEnumerable<User>?> GetUsersByRoleAsync(UserRole role);
        Task<IEnumerable<User>?> GetUsersByCity(string city);
        Task<IEnumerable<User>?> GetUsersByCountry(string country);
        Task<IEnumerable<User>?> GetUsersByState(string state);
    }
}
