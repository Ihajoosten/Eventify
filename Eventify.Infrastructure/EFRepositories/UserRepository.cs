using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Infrastructure.EFRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Eventify.Infrastructure.EFRepositories
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork, ILogger<UserRepository> logger) : base(unitOfWork, logger) { }

        public async Task<User?> GetUserByEmailAsync(string email) => 
            await _unitOfWork.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        public async Task<User?> GetUserByUsernameAsync(string username) => 
            await _unitOfWork.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
        
        public async Task<IEnumerable<User>?> GetUsersByCity(string city) => 
            await _unitOfWork.Set<User>().Where(u => u.UserAddress.City == city).ToListAsync();

        public async Task<IEnumerable<User>?> GetUsersByCountry(string country) =>
            await _unitOfWork.Set<User>().Where(u => u.UserAddress.Country == country).ToListAsync();
        public async Task<IEnumerable<User>?> GetUsersByState(string state)=>
            await _unitOfWork.Set<User>().Where(u => u.UserAddress.State == state).ToListAsync();

        public async Task<IEnumerable<User>?> GetUsersByGenderAsync(Gender gender) =>
            await _unitOfWork.Set<User>().Where(u => u.Gender == gender).ToListAsync();

        public async Task<IEnumerable<User>?> GetUsersByRoleAsync(UserRole role) =>
            await _unitOfWork.Set<User>().Where(u => u.Role == role).ToListAsync();
    }
}
