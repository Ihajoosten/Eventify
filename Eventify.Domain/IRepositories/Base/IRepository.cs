namespace Eventify.Domain.IRepositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
