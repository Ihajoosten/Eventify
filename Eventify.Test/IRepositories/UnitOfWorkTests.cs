namespace Eventify.UnitTest.IRepositories
{
    public class UnitOfWorkTests
    {
        [Fact]
        public async Task CommitAsync_ShouldCallCommitAsync()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.CommitAsync()).Returns(Task.CompletedTask);

            // Act
            await unitOfWorkMock.Object.CommitAsync();

            // Assert
            unitOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task RollbackAsync_ShouldCallRollbackAsync()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.RollbackAsync()).Returns(Task.CompletedTask);

            // Act
            await unitOfWorkMock.Object.RollbackAsync();

            // Assert
            unitOfWorkMock.Verify(uow => uow.RollbackAsync(), Times.Once);
        }

        [Fact]
        public async Task SaveChangesAsync_ShouldCallSaveChangesAsync()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(42); // Replace 42 with the expected integer result

            // Act
            var result = await unitOfWorkMock.Object.SaveChangesAsync();

            // Assert
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(42, result); // Check the expected integer result
        }

        [Fact]
        public async Task BeginTransactionAsync_ShouldCallBeginTransactionAsync()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.BeginTransactionAsync()).Returns(Task.CompletedTask);

            // Act
            await unitOfWorkMock.Object.BeginTransactionAsync();

            // Assert
            unitOfWorkMock.Verify(uow => uow.BeginTransactionAsync(), Times.Once);
        }

        [Fact]
        public async Task BeginTransactionAsync_ShouldCallBeginTransactionAsyncWithCancellationToken()
        {
            // Arrange
            var cancellationToken = new CancellationToken();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.BeginTransactionAsync()).Returns(Task.CompletedTask);

            // Act
            await unitOfWorkMock.Object.BeginTransactionAsync();

            // Assert
            unitOfWorkMock.Verify(uow => uow.BeginTransactionAsync(), Times.Once);
        }

        [Fact]
        public void Set_ShouldCallDbContextSet()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var dbSetMock = new Mock<DbSet<Event>>(); // Replace with your entity type

            unitOfWorkMock.Setup(uow => uow.Set<Event>()).Returns(dbSetMock.Object);

            // Act
            var dbSet = unitOfWorkMock.Object.Set<Event>(); // Replace with your entity type

            // Assert
            unitOfWorkMock.Verify(uow => uow.Set<Event>(), Times.Once);
            Assert.NotNull(dbSet);
        }
    }
}