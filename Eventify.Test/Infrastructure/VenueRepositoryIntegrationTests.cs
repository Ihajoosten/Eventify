using Eventify.Domain.Entities;
using Eventify.Domain.ValueObjects;
using Eventify.Infrastructure.EFRepositories;
using Eventify.Test.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Eventify.Test.Infrastructure
{
    public class VenueRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        public VenueRepositoryIntegrationTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetVenuesByCountry_Returns_Venues()
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
                var logger = new Mock<ILogger<VenueRepository>>().Object;

                // Add some venues
                var venue1 = new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = "Venue 1",
                    VenueAddress = new Address
                    {
                        Country = "Country1",
                        State = "State1",
                        City = "city1",
                        Street = "street 1",
                        ZipCode = "zipCode1"
                    },
                    Capacity = 100,
                    ContactPerson = "Contact Person 1",
                };

                var venue2 = new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = "Venue 2",
                    VenueAddress = new Address
                    {
                        Country = "Country2",
                        State = "State2",
                        City = "city2",
                        Street = "street2",
                        ZipCode = "zipCode2"
                    },
                    Capacity = 150,
                    ContactPerson = "Contact Person 2"
                };

                await context.Venues.AddRangeAsync(venue1, venue2);
                await context.SaveChangesAsync();

                var repository = new VenueRepository(unitOfWork, logger);

                // Act
                var result = await repository.GetVenuesByCountry("Country1");

                // Assert
                Assert.NotNull(result);
                Assert.Single(result);
                Assert.Contains(venue1, result);

                // clean database
                _fixture.ClearData<User>();
                _fixture.ClearData<Event>();
                _fixture.ClearData<Venue>();
            }
        }

        [Fact]
        public async Task GetVenuesByState_Returns_Venues()
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
                var logger = new Mock<ILogger<VenueRepository>>().Object;

                // Add some venues
                var venue1 = new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = "Venue 1",
                    VenueAddress = new Address
                    {
                        Country = "Country1",
                        State = "State1",
                        City = "city1",
                        Street = "street 1",
                        ZipCode = "zipCode1"
                    },
                    Capacity = 100,
                    ContactPerson = "Contact Person 1",
                };

                var venue2 = new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = "Venue 2",
                    VenueAddress = new Address
                    {
                        Country = "Country2",
                        State = "State2",
                        City = "city2",
                        Street = "street2",
                        ZipCode = "zipCode2"
                    },
                    Capacity = 150,
                    ContactPerson = "Contact Person 2"
                };

                await context.Venues.AddRangeAsync(venue1, venue2);
                await context.SaveChangesAsync();

                var repository = new VenueRepository(unitOfWork, logger);

                // Act
                var result = await repository.GetVenuesByState("State1");

                // Assert
                Assert.NotNull(result);
                Assert.Equal(1, result.Count());
                Assert.Contains(venue1, result);

                // clean database
                _fixture.ClearData<User>();
                _fixture.ClearData<Event>();
                _fixture.ClearData<Venue>();
            }
        }
    }
}
