using Eventify.Domain.IRepositories;
using Moq;

namespace Eventify.Test.Domain
{
    public class UnitOfWorkTests
    {
        [Fact]
        public async Task CommitAsync_ShouldCommitChanges()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            // Act
            await unitOfWorkMock.Object.CommitAsync();

            // Assert
            unitOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task RollbackAsync_ShouldRollbackChanges()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            // Act
            await unitOfWorkMock.Object.RollbackAsync();

            // Assert
            unitOfWorkMock.Verify(uow => uow.RollbackAsync(), Times.Once);
        }

        [Fact]
        public async Task SaveChangesAsync_ShouldSaveChanges()
        {
            // Arrange
            var cancellationToken = new CancellationToken();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            // Act
            await unitOfWorkMock.Object.SaveChangesAsync(cancellationToken);

            // Assert
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(cancellationToken), Times.Once);
        }
    }
}
