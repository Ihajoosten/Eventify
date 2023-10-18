using Eventify.Domain.Entities;
using Eventify.Infrastructure.EFRepositories;
using Eventify.Test.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Eventify.Test.Infrastructure
{
    public class EventRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        public EventRepositoryIntegrationTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetEventsBySponsor_Returns_Events()
        {

            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new TestDbContext(options);
            var unitOfWork = new TestUnitOfWork(context);
            var logger = new Mock<ILogger<EventRepository>>().Object;

            // Add some events
            var sponsorId = Guid.NewGuid();
            var @event1 = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Title of the Event",
                Description = "Description of the event.",
                StartDate = DateTime.Now.AddDays(7),
                EndDate = DateTime.Now.AddDays(8),
                EventUrl = "https://example.com/event",
                OrganizerId = Guid.NewGuid(),
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                VenueId = Guid.NewGuid(),
                SponsorId = sponsorId
            };

            var @event2 = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Title of the Event",
                Description = "Description of the event.",
                StartDate = DateTime.Now.AddDays(7),
                EndDate = DateTime.Now.AddDays(8),
                EventUrl = "https://example.com/event",
                OrganizerId = Guid.NewGuid(),
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                VenueId = Guid.NewGuid(),
                SponsorId = sponsorId
            };

            await context.Events.AddRangeAsync(@event1, @event2);
            await context.SaveChangesAsync();

            var repository = new EventRepository(unitOfWork, logger);

            // Act
            var result = await repository.GetEventsBySponsor(sponsorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(@event1, result);
            Assert.Contains(@event2, result);

            // clean database
            _fixture.ClearData<Event>();
        }

        [Fact]
        public async Task GetEventsByVenue_Returns_Events()
        {
            // clean database
            _fixture.ClearData<Event>();

            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new TestDbContext(options);
            var unitOfWork = new TestUnitOfWork(context);
            var logger = new Mock<ILogger<EventRepository>>().Object;

            // Add some events
            var venueId = Guid.NewGuid();
            var @event1 = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Title of the Event",
                Description = "Description of the event.",
                StartDate = DateTime.Now.AddDays(7),
                EndDate = DateTime.Now.AddDays(8),
                EventUrl = "https://example.com/event",
                OrganizerId = Guid.NewGuid(),
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                VenueId = venueId,
                SponsorId = Guid.NewGuid()
            };

            var @event2 = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Title of the Event",
                Description = "Description of the event.",
                StartDate = DateTime.Now.AddDays(7),
                EndDate = DateTime.Now.AddDays(8),
                EventUrl = "https://example.com/event",
                OrganizerId = Guid.NewGuid(),
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                VenueId = venueId,
                SponsorId = Guid.NewGuid()
            };

            await context.Events.AddRangeAsync(@event1, @event2);
            await context.SaveChangesAsync();

            var repository = new EventRepository(unitOfWork, logger);

            // Act
            var result = await repository.GetEventsByVenue(venueId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(@event1, result);
            Assert.Contains(@event2, result);

            // clean database
            _fixture.ClearData<Event>();
        }

        [Fact]
        public async Task GetUpcomingEventsAsync_Returns_Upcoming_Events()
        {
            // clean database
            _fixture.ClearData<Event>();

            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new TestDbContext(options);
            var unitOfWork = new TestUnitOfWork(context);
            var logger = new Mock<ILogger<EventRepository>>().Object;

            // Add some events
            var @event1 = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Title of the Event",
                Description = "Description of the event.",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                EventUrl = "https://example.com/event",
                OrganizerId = Guid.NewGuid(),
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            var @event2 = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Title of the Event",
                Description = "Description of the event.",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                EventUrl = "https://example.com/event",
                OrganizerId = Guid.NewGuid(),
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            await context.Events.AddRangeAsync(@event1, @event2);
            await context.SaveChangesAsync();

            var repository = new EventRepository(unitOfWork, logger);

            // Act
            var result = await repository.GetUpcomingEventsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(@event1, result);
            Assert.Contains(@event2, result);

            // clean database
            _fixture.ClearData<Event>();
        }   

        [Fact]
        public async Task GetEventsByOrganizer_Returns_Events()
        {
            // clean database
            _fixture.ClearData<Event>();

            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new TestDbContext(options))
            {
                var unitOfWork = new TestUnitOfWork(context);
                var logger = new Mock<ILogger<EventRepository>>().Object;

                // Add some events
                var organizerEmail = "organizer@example.com";
                var organizer = new User
                {
                    Id = Guid.NewGuid(),
                    ConfirmPassword = "password",
                    Email = organizerEmail,
                    FirstName = "John",
                    LastName = "Doe",
                    Password = "password",
                    PhoneNumber = "123456789",
                    Username = "john.doe"
                };

                var @event1 = new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Title of the Event 1",
                    Description = "Description of the event 1.",
                    StartDate = DateTime.Now.AddDays(7),
                    EndDate = DateTime.Now.AddDays(8),
                    EventUrl = "https://example.com/event1",
                    OrganizerId = organizer.Id,
                    IsRegistrationRequired = true,
                    MaximumAttendees = 100,
                    VenueId = Guid.NewGuid(),
                    SponsorId = Guid.NewGuid()
                };

                var @event2 = new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Title of the Event 2",
                    Description = "Description of the event 2.",
                    StartDate = DateTime.Now.AddDays(7),
                    EndDate = DateTime.Now.AddDays(8),
                    EventUrl = "https://example.com/event2",
                    OrganizerId = organizer.Id,
                    IsRegistrationRequired = true,
                    MaximumAttendees = 100,
                    VenueId = Guid.NewGuid(),
                    SponsorId = Guid.NewGuid()
                };

                await context.Users.AddAsync(organizer);
                await context.Events.AddRangeAsync(@event1, @event2);
                await context.SaveChangesAsync();

                var repository = new EventRepository(unitOfWork, logger);

                // Act
                var result = await repository.GetEventsByOrganizer(organizerEmail);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count());
                Assert.Contains(@event1, result);
                Assert.Contains(@event2, result);

                // clean database
                _fixture.ClearData<Event>();
            }
        }
    }
}
