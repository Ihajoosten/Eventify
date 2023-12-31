﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Eventify.IntegrationTests.Config
{
    public class TestUnitOfWork : IUnitOfWork
    {
        private readonly TestDbContext _dbContext;
        private IDbContextTransaction? _transaction;

        public TestUnitOfWork(TestDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _dbContext.SaveChangesAsync(cancellationToken);

        public DbSet<T> Set<T>() where T : class => _dbContext.Set<T>();
        public EntityEntry<T> Entry<T>(T entity) where T : class => _dbContext.Entry(entity);
        public void Dispose() => _transaction?.Dispose();
    }
}
