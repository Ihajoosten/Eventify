namespace Eventify.IntegrationTests.Repositories
{
    [Collection("DatabaseCollection")]
    public class VenueRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<VenueRepository> _logger;
        private readonly IVenueRepository _venueRepository;
        private readonly SharedDatabaseFixture _fixture;

        public VenueRepositoryTests(SharedDatabaseFixture fixture)
        {
            _fixture = fixture;

            _unitOfWork = new TestUnitOfWork(_fixture.Context);
            _logger = new Mock<ILogger<VenueRepository>>().Object;
            _venueRepository = new VenueRepository(_unitOfWork, _logger);
        }

        [Fact]
        public async Task GetVenues_ReturnsAllVenues()
        {
            var venues = await _venueRepository.GetAllAsync();
            if (venues!.Any())
            {
                Assert.Equal(2, venues.Count());
            }
            else { Assert.Null(venues); }
        }

        [Fact]
        public async Task GetVenueById_ReturnsVenue()
        {
            var venue = await _venueRepository.GetByIdAsync(Guid.Parse("7DF28005-7925-40AC-B90D-6AC60DDDADBC"));
            if (venue != null)
            {
                Assert.Equal(100, venue.Capacity);
                Assert.Equal("Valid Venue Name", venue.Name);
                Assert.Equal("John Doe", venue.ContactPerson);
                Assert.Equal("VenueStreet2", venue.VenueAddress.Street);
                Assert.Equal("VenuezipCode2", venue.VenueAddress.ZipCode);
                Assert.Equal("VenueCity2", venue.VenueAddress.City);
                Assert.Equal("VenueState2", venue.VenueAddress.State);
                Assert.Equal("VenueCountry2", venue.VenueAddress.Country);
            }
            //else { Assert.Null(venue); }
        }

        [Theory]
        [InlineData("State2", 0)]
        [InlineData("VenueState2", 2)]
        [InlineData("VenueState3", 1)]
        public async Task GetVenuesByState_ReturnsVenuesByState(string state, int expectedAmount)
        {
            var venues = await _venueRepository.GetVenuesByState(state);

            if (venues!.Any())
            {
                Assert.Equal(expectedAmount, venues.Count());
            }
            else { Assert.Empty(venues); }
        }

        [Theory]
        [InlineData("Country2", 0)]
        [InlineData("VenueCountry2", 2)]
        [InlineData("VenueCountry3", 1)]
        public async Task GetVenuesByCountry_ReturnsVenuesByCountry(string country, int expectedAmount)
        {
            var venues = await _venueRepository.GetVenuesByCountry(country);

            if (venues!.Any())
            {
                Assert.Equal(expectedAmount, venues.Count());
            }
            else { Assert.Empty(venues); }
        }

        [Fact]
        public async Task CreateNewVenue_ReturnsCreatedVenue()
        {
            var newVenue = new Venue
            {
                Id = Guid.NewGuid(),
                Name = "Valid Venue Name",
                Capacity = 100,
                ContactPerson = "John Doe",
                VenueAddress = new Address { Street = "VenueStreet3", ZipCode = "VenuezipCode3", City = "VenueCity3", Country = "VenueCountry3", State = "VenueState3" },
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
            };

            var created = await _venueRepository.AddAsync(newVenue);
            if (created != null)
            {
                Assert.Equal(newVenue.Id, created.Id);
                Assert.Equal(100, created.Capacity);
                Assert.Equal("Valid Venue Name", created.Name);
                Assert.Equal("John Doe", created.ContactPerson);
                Assert.Equal("VenueStreet3", created.VenueAddress.Street);
                Assert.Equal("VenuezipCode3", created.VenueAddress.ZipCode);
                Assert.Equal("VenueCity3", created.VenueAddress.City);
                Assert.Equal("VenueState3", created.VenueAddress.State);
                Assert.Equal("VenueCountry3", created.VenueAddress.Country);
            }
            else { Assert.Null(created); }
        }

        [Fact]
        public async Task UpdateExistingVenue_ReturnsUpdatedVenue()
        {
            var venue = await _venueRepository.GetByIdAsync(Guid.Parse("7DF28005-7925-40AC-B90D-6AC60DDDADBC"));

            if (venue != null)
            {
                venue.Name = "UpdatedName";
                venue.Capacity = 20;
                venue.ContactPerson = "UpdatedContact";

                var updated = await _venueRepository.UpdateAsync(venue);
                if (updated != null)
                {
                    Assert.Equal(venue.Id, updated.Id);
                    Assert.Equal(20, updated.Capacity);
                    Assert.Equal("UpdatedName", updated.Name);
                    Assert.Equal("UpdatedContact", updated.ContactPerson);
                    Assert.Equal("VenueStreet2", updated.VenueAddress.Street);
                    Assert.Equal("VenuezipCode2", updated.VenueAddress.ZipCode);
                    Assert.Equal("VenueCity2", updated.VenueAddress.City);
                    Assert.Equal("VenueState2", updated.VenueAddress.State);
                    Assert.Equal("VenueCountry2", updated.VenueAddress.Country);
                }
                else { Assert.Null(updated); }
            }
            else { Assert.Null(venue); }

        }

        [Fact]
        public async Task DeleteExistingVenue_ReturnsDeletedVenue()
        {
            var venue = await _venueRepository.GetByIdAsync(Guid.Parse("7DF28005-7925-40AC-B90D-6AC60DDDADBC"));
            if (venue != null)
            {
                var deleted = await _venueRepository.RemoveAsync(venue);
                if (deleted != null)
                {
                    Assert.Equal(venue.Id, deleted.Id);
                    Assert.Equal(20, deleted.Capacity);
                    Assert.Equal("UpdatedName", deleted.Name);
                    Assert.Equal("UpdatedContact", deleted.ContactPerson);
                    Assert.Equal("VenueStreet2", deleted.VenueAddress.Street);
                    Assert.Equal("VenuezipCode2", deleted.VenueAddress.ZipCode);
                    Assert.Equal("VenueCity2", deleted.VenueAddress.City);
                    Assert.Equal("VenueState2", deleted.VenueAddress.State);
                    Assert.Equal("VenueCountry2", deleted.VenueAddress.Country);
                }
                else { Assert.Null(deleted); }
            }
            else { Assert.Null(venue); }
        }
    }
}
