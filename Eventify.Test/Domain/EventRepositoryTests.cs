using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Moq;

namespace Eventify.Test.Domain
{
    public class EventRepositoryTests
    {
        [Fact]
        public async Task GetUpcomingEventsAsync_ReturnsEvents_WhenEventsExist()
        {
            // Arrange
            var expectedEvents = new List<Event>
        {
            new Event { /* event properties */ },
            new Event { /* event properties */ },
            // Add more events as needed
        };

            var eventRepositoryMock = new Mock<IEventRepository>();
            eventRepositoryMock.Setup(repo => repo.GetUpcomingEventsAsync()).ReturnsAsync(expectedEvents);

            // Act
            var result = await eventRepositoryMock.Object.GetUpcomingEventsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedEvents, result);
        }

        [Fact]
        public async Task GetUpcomingEventsAsync_ReturnsEmptyList_WhenNoEventsExist()
        {
            // Arrange
            var eventRepositoryMock = new Mock<IEventRepository>();
            eventRepositoryMock.Setup(repo => repo.GetUpcomingEventsAsync()).ReturnsAsync(new List<Event>());

            // Act
            var result = await eventRepositoryMock.Object.GetUpcomingEventsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetEventsByOrganizer_ReturnsEvents_WhenEventsExist()
        {
            // Arrange
            var organizerEmail = "organizer@example.com";
            var expectedEvents = new List<Event>
        {
            new Event { /* event properties */ },
            new Event { /* event properties */ },
            // Add more events as needed
        };

            var eventRepositoryMock = new Mock<IEventRepository>();
            eventRepositoryMock.Setup(repo => repo.GetEventsByOrganizer(organizerEmail)).ReturnsAsync(expectedEvents);

            // Act
            var result = await eventRepositoryMock.Object.GetEventsByOrganizer(organizerEmail);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedEvents, result);
        }

        [Fact]
        public async Task GetEventsByOrganizer_ReturnsEmptyList_WhenNoEventsExist()
        {
            // Arrange
            var organizerEmail = "nonexistent_organizer@example.com";

            var eventRepositoryMock = new Mock<IEventRepository>();
            eventRepositoryMock.Setup(repo => repo.GetEventsByOrganizer(organizerEmail)).ReturnsAsync(new List<Event>());

            // Act
            var result = await eventRepositoryMock.Object.GetEventsByOrganizer(organizerEmail);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
