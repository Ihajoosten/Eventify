namespace Eventify.Domain.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
