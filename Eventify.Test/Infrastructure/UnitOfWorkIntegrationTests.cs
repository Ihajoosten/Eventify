using Eventify.Domain.Entities;
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
    public class UnitOfWorkIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        public UnitOfWorkIntegrationTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CommitAsync_CommitsTransaction()
        {
            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();

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

                // clean database
                _fixture.ClearData<User>();
                _fixture.ClearData<Event>();
                _fixture.ClearData<Venue>();
            }
        }

        [Fact]
        public async Task RollbackAsync_RollsBackTransaction()
        {
            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();

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

                // clean database
                _fixture.ClearData<User>();
                _fixture.ClearData<Event>();
                _fixture.ClearData<Venue>();
            }
        }

        [Fact]
        public async Task SaveChangesAsync_SavesChanges()
        {
            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();

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

            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();
        }
    }

}
