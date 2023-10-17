﻿using Eventify.Domain.Entities;
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

        [Fact]
        public async Task GetEventsByVenue_ReturnsEvents_WhenEventsExistForVenue()
        {
            // Arrange
            var venueId = Guid.NewGuid();
            var expectedEvents = new List<Event>
        {
            new Event { VenueId = venueId, /* other properties */ },
            new Event { VenueId = venueId, /* other properties */ },
            // Add more events as needed
        };

            var eventRepositoryMock = new Mock<IEventRepository>();
            eventRepositoryMock.Setup(repo => repo.GetEventsByVenue(venueId)).ReturnsAsync(expectedEvents);

            // Act
            var result = await eventRepositoryMock.Object.GetEventsByVenue(venueId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedEvents, result);
        }

        [Fact]
        public async Task GetEventsByVenue_ReturnsEmptyList_WhenNoEventsExistForVenue()
        {
            // Arrange
            var venueId = Guid.NewGuid();

            var eventRepositoryMock = new Mock<IEventRepository>();
            eventRepositoryMock.Setup(repo => repo.GetEventsByVenue(venueId)).ReturnsAsync(new List<Event>());

            // Act
            var result = await eventRepositoryMock.Object.GetEventsByVenue(venueId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetEventsBySponsor_ReturnsEvents_WhenEventsExistForSponsor()
        {
            // Arrange
            var sponsorId = Guid.NewGuid();
            var expectedEvents = new List<Event>
        {
            new Event { SponsorId = sponsorId, /* other properties */ },
            new Event { SponsorId = sponsorId, /* other properties */ },
            // Add more events as needed
        };

            var eventRepositoryMock = new Mock<IEventRepository>();
            eventRepositoryMock.Setup(repo => repo.GetEventsBySponsor(sponsorId)).ReturnsAsync(expectedEvents);

            // Act
            var result = await eventRepositoryMock.Object.GetEventsBySponsor(sponsorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedEvents, result);
        }

        [Fact]
        public async Task GetEventsBySponsor_ReturnsEmptyList_WhenNoEventsExistForSponsor()
        {
            // Arrange
            var sponsorId = Guid.NewGuid();

            var eventRepositoryMock = new Mock<IEventRepository>();
            eventRepositoryMock.Setup(repo => repo.GetEventsBySponsor(sponsorId)).ReturnsAsync(new List<Event>());

            // Act
            var result = await eventRepositoryMock.Object.GetEventsBySponsor(sponsorId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

    }
}
