using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories.Base;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Test.Domain
{
    public class IRepositoryTests
    {
        [Fact]
        public async Task GetByIdAsync_Returns_Entity_When_Found()
        {
            // Arrange
            var entityId = Guid.NewGuid();
            var entity = new User { Id = entityId };
            var repository = new Mock<IRepository<User>>();
            repository.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(entity);

            // Act
            var result = await repository.Object.GetByIdAsync(entityId);

            // Assert
            Assert.Equal(entity, result);
        }

        [Fact]
        public async Task GetByIdAsync_Returns_Null_When_Entity_Not_Found()
        {
            // Arrange
            var entityId = Guid.NewGuid();
            var repository = new Mock<IRepository<User>>();
            repository.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync((User)null);

            // Act
            var result = await repository.Object.GetByIdAsync(entityId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAsync_Returns_Entities_When_Found()
        {
            // Arrange
            var entities = new List<User> { new User(), new User() };
            var repository = new Mock<IRepository<User>>();
            repository.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);

            // Act
            var result = await repository.Object.GetAllAsync();

            // Assert
            Assert.Equal(entities, result);
        }

        [Fact]
        public async Task GetAllAsync_Returns_Null_When_No_Entities_Found()
        {
            // Arrange
            var repository = new Mock<IRepository<User>>();
            repository.Setup(r => r.GetAllAsync()).ReturnsAsync((IEnumerable<User>)null);

            // Act
            var result = await repository.Object.GetAllAsync();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddAsync_Returns_Added_Entity()
        {
            // Arrange
            var entity = new User();
            var repository = new Mock<IRepository<User>>();
            repository.Setup(r => r.AddAsync(entity)).ReturnsAsync(entity);

            // Act
            var result = await repository.Object.AddAsync(entity);

            // Assert
            Assert.Equal(entity, result);
        }

        [Fact]
        public async Task UpdateAsync_Returns_Updated_Entity()
        {
            // Arrange
            var entity = new User();
            var repository = new Mock<IRepository<User>>();
            repository.Setup(r => r.UpdateAsync(entity)).ReturnsAsync(entity);

            // Act
            var result = await repository.Object.UpdateAsync(entity);

            // Assert
            Assert.Equal(entity, result);
        }

        [Fact]
        public async Task RemoveAsync_Returns_Removed_Entity()
        {
            // Arrange
            var entity = new User();
            var repository = new Mock<IRepository<User>>();
            repository.Setup(r => r.RemoveAsync(entity)).ReturnsAsync(entity);

            // Act
            var result = await repository.Object.RemoveAsync(entity);

            // Assert
            Assert.Equal(entity, result);
        }
    }
}
