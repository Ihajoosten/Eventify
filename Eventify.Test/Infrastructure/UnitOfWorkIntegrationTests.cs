using Eventify.Infrastructure.UnitOfWork;
using Eventify.Test.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Test.Infrastructure
{
    public class UnitOfWorkIntegrationTests
    {
        [Fact]
        public async Task CommitAsync_CommitsTransaction()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new TestDbContext(options))
            {
                var unitOfWork = new TestUnitOfWork(context);

                // Act
                await unitOfWork.BeginTransactionAsync();
                await unitOfWork.CommitAsync();

                // Assert
                Assert.Null(context.Database.CurrentTransaction); // No active transaction after commit
            }
        }

        [Fact]
        public async Task RollbackAsync_RollsBackTransaction()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new TestDbContext(options))
            {
                var unitOfWork = new TestUnitOfWork(context);

                // Act
                await unitOfWork.BeginTransactionAsync();
                await unitOfWork.RollbackAsync();

                // Assert
                Assert.Null(context.Database.CurrentTransaction); // No active transaction after rollback
            }
        }

        [Fact]
        public async Task SaveChangesAsync_SavesChanges()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new TestDbContext(options))
            {
                var unitOfWork = new TestUnitOfWork(context);

                // Act
                var result = await unitOfWork.SaveChangesAsync();

                // Assert
                Assert.True(result >= 0);
            }
        }
    }

}
