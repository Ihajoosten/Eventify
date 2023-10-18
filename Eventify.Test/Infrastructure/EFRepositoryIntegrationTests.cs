using Eventify.Domain.Entities;
using Eventify.Infrastructure.EFRepositories.Base;
using Eventify.Test.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Eventify.Test.Infrastructure
{
    public class EFRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        public EFRepositoryIntegrationTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAllAsync_Returns_All_Entities()
        {
            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();

            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new TestDbContext(options);
            var unitOfWork = new TestUnitOfWork(context);
            var logger = new Mock<ILogger<EFRepository<User>>>();

            // Add some User entities
            // Add a User entity with all required properties
            var user1 = new User
            {
                Id = Guid.NewGuid(),
                ConfirmPassword = "password",
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Password = "password",
                PhoneNumber = "123456789",
                Username = "john.doe"
            };
            // Add a User entity with all required properties
            var user2 = new User
            {
                Id = Guid.NewGuid(),
                ConfirmPassword = "password",
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Password = "password",
                PhoneNumber = "123456789",
                Username = "john.doe"
            };

            await context.Users.AddRangeAsync(user1, user2);
            await context.SaveChangesAsync();

            var repository = new EFRepository<User>(unitOfWork, logger.Object);

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(user1, result);
            Assert.Contains(user2, result);

            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();
        }

        [Fact]
        public async Task GetByIdAsync_Returns_Entity_When_Found()
        {
            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();

            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new TestDbContext(options);
            var unitOfWork = new TestUnitOfWork(context);
            var logger = new Mock<ILogger<EFRepository<User>>>();

            // Add a User entity with all required properties
            var entity = new User
            {
                Id = Guid.NewGuid(),
                ConfirmPassword = "password",
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Password = "password",
                PhoneNumber = "123456789",
                Username = "john.doe"
            };

            await context.Set<User>().AddAsync(entity);
            await context.SaveChangesAsync();

            var repository = new EFRepository<User>(unitOfWork, logger.Object);

            // Act
            var result = await repository.GetByIdAsync(entity.Id);

            // Assert
            Assert.Equal(entity, result);

            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();
        }

        [Fact]
        public async Task UpdateAsync_Updates_Entity()
        {
            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();

            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new TestDbContext(options);
            var unitOfWork = new TestUnitOfWork(context);
            var logger = new Mock<ILogger<EFRepository<User>>>();

            // Add a User entity
            var user = new User
            {
                Id = Guid.NewGuid(),
                ConfirmPassword = "password",
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Password = "password",
                PhoneNumber = "123456789",
                Username = "john.doe"
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            var repository = new EFRepository<User>(unitOfWork, logger.Object);

            // Modify a property
            user.FirstName = "UpdatedFirstName";

            // Act
            var updatedUser = await repository.UpdateAsync(user);

            // Assert
            Assert.NotNull(updatedUser);
            Assert.Equal("UpdatedFirstName", updatedUser.FirstName);

            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();
        }

        [Fact]
        public async Task RemoveAsync_Removes_Entity()
        {
            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();

            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new TestDbContext(options);
            var unitOfWork = new TestUnitOfWork(context);
            var logger = new Mock<ILogger<EFRepository<User>>>();

            // Add a User entity
            var user = new User
            {
                Id = Guid.NewGuid(),
                ConfirmPassword = "password",
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Password = "password",
                PhoneNumber = "123456789",
                Username = "john.doe"
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            var repository = new EFRepository<User>(unitOfWork, logger.Object);

            // Act
            var removedUser = await repository.RemoveAsync(user);

            // Assert
            Assert.NotNull(removedUser);
            Assert.Equal(user, removedUser);

            // Ensure the entity is removed from the database
            var userFromDb = await context.Users.FindAsync(user.Id);
            Assert.Null(userFromDb);

            // clean database
            _fixture.ClearData<User>();
            _fixture.ClearData<Event>();
            _fixture.ClearData<Venue>();
        }
    }
}
