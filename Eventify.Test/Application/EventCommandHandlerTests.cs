using AutoMapper;
using Eventify.Application.Commands.Event;
using Eventify.Application.Dto;
using Eventify.Application.Handlers.Commands;
using Eventify.Application.Interfaces.Commands.Event;
using Eventify.Application.Interfaces.Dto;
using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Test.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace Eventify.Test.Application
{
    public class EventCommandHandlerTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        public EventCommandHandlerTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CreateEvent_ShouldReturnValidDto()
        {
            // clear data
            _fixture.ClearData<Event>();

            // Arrange
            var repositoryMock = new Mock<IEventRepository>();
            var loggerMock = new Mock<ILogger<EventCommandHandler>>();
            var mapperMock = new Mock<IMapper>();

            var handler = new EventCommandHandler(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            var createCommand = new CreateEventCommand
            {
                Description = "Test Description",
                StartDate = DateTime.Now.AddDays(10),
                EndDate = DateTime.Now.AddDays(25),
                EventUrl = "http://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 50,
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid(),
                OrganizerId = Guid.NewGuid(),
            };

            // Mock repository behavior
            var createdEvent = new Event
            {
                Id = Guid.NewGuid(),
                Description = "Sample Event",
            };

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Event>())).ReturnsAsync(createdEvent);

            // Mock mapper behavior
            var expectedDto = new EventDto
            {
                Id = createdEvent.Id,
                Description = createdEvent.Description,
                // Set other properties
            };

            mapperMock.Setup(mapper => mapper.Map<IEventDto>(It.IsAny<Event>())).Returns(expectedDto);

            // Act
            var result = await handler.Handle(createCommand);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<EventDto>(result);

            // Additional asserts for property matching
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Description, result.Description);

            // clean database
            _fixture.ClearData<Event>();
        }

        [Fact]
        public async Task UpdateEvent_ShouldReturnValidDto()
        {
            // clear data
            _fixture.ClearData<Event>();

            // Arrange
            var repositoryMock = new Mock<IEventRepository>();
            var loggerMock = new Mock<ILogger<EventCommandHandler>>();
            var mapperMock = new Mock<IMapper>();

            var handler = new EventCommandHandler(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            // Mock repository behavior
            var createdEvent = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Sample Title",
                Description = "Test Description",
                StartDate = DateTime.Now.AddDays(10),
                EndDate = DateTime.Now.AddDays(25),
                EventUrl = "http://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 50,
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid(),
                OrganizerId = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
            };

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Event>())).ReturnsAsync(createdEvent);


            var updateCommand = new UpdateEventCommand
            {
                Id = createdEvent.Id,
                Title = "Updated Title",
                Description = "Updated Description",
                EventUrl = "http://updated.com",
                IsRegistrationRequired = false,
                MaximumAttendees = 25,
                UpdatedAt = DateTime.UtcNow,
            };

            // Mock repository behavior
            var updatedEvent = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Updated Title",
                Description = "Updated Description",
                EventUrl = "http://updated.com",
                IsRegistrationRequired = false,
                MaximumAttendees = 25,
                Created = createdEvent.Created,
                Updated = updateCommand.UpdatedAt,
            };

            repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Event>())).ReturnsAsync(updatedEvent);

            // Mock mapper behavior
            var expectedDto = new EventDto
            {
                Id = updatedEvent.Id,
                Description = updatedEvent.Description,
                Title = updatedEvent.Title,
                EventUrl = updatedEvent.EventUrl,
                MaximumAttendees = updatedEvent.MaximumAttendees,
            };

            mapperMock.Setup(mapper => mapper.Map<IEventDto>(It.IsAny<Event>())).Returns(expectedDto);

            // Act
            var result = await handler.Handle(updateCommand);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<EventDto>(result);

            // Additional asserts for property matching
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Description, result.Description);
            Assert.Equal(expectedDto.EventUrl, result.EventUrl);

            // clean database
            _fixture.ClearData<Event>();
        }

        [Fact]
        public async Task DeleteEvent_ShouldReturnValidDto()
        {
            // clear data
            _fixture.ClearData<Event>();

            // Arrange
            var repositoryMock = new Mock<IEventRepository>();
            var loggerMock = new Mock<ILogger<EventCommandHandler>>();
            var mapperMock = new Mock<IMapper>();

            var handler = new EventCommandHandler(repositoryMock.Object, loggerMock.Object, mapperMock.Object);
            // Mock repository behavior
            var createdEvent = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Sample Title",
                Description = "Test Description",
                StartDate = DateTime.Now.AddDays(10),
                EndDate = DateTime.Now.AddDays(25),
                EventUrl = "http://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 50,
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid(),
                OrganizerId = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
            };

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Event>())).ReturnsAsync(createdEvent);

            var deleteCommand = new DeleteEventCommand
            {
                Id = createdEvent.Id
            };

            // Mock repository behavior
            var deletedEvent = new Event
            {
                Id = createdEvent.Id,
            };

            repositoryMock.Setup(repo => repo.RemoveAsync(It.IsAny<Event>())).ReturnsAsync(deletedEvent);

            // Mock mapper behavior
            var expectedDto = new EventDto
            {
                Id = createdEvent.Id,
                Description = createdEvent.Description,
                StartDate = createdEvent.StartDate,
                EndDate = createdEvent.EndDate,
            };

            mapperMock.Setup(mapper => mapper.Map<IEventDto>(It.IsAny<Event>())).Returns(expectedDto);

            // Act
            var result = await handler.Handle(deleteCommand);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<EventDto>(result);

            // Additional asserts for property matching
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Description, result.Description);
            Assert.Equal(expectedDto.StartDate, result.StartDate);
            Assert.Equal(expectedDto.StartDate, result.StartDate);

            // clean database
            _fixture.ClearData<Event>();
        }
    }
}
