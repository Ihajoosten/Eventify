using Eventify.IntegrationTests.Config.Fixtures;

namespace Eventify.IntegrationTests.Repositories
{
    [Collection("InfraLayerCollection")]
    public class EventRepositoryTests : IClassFixture<InfraLayerFixture>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EventRepository> _logger;
        private readonly IEventRepository _eventRepository;
        private readonly InfraLayerFixture _fixture;

        public EventRepositoryTests(InfraLayerFixture fixture)
        {
            _fixture = fixture;

            _unitOfWork = new TestUnitOfWork(_fixture.Context);
            _logger = new Mock<ILogger<EventRepository>>().Object;
            _eventRepository = new EventRepository(_unitOfWork, _logger);
        }

        [Theory]
        [InlineData("6B2ABF89-9C35-353A-B083-9D062D1ECBE6", 0)] // non existing ID
        [InlineData("8A89AED6-E3D8-409C-B188-77A56DA25889", 1)]
        [InlineData("B37B6940-DE24-4AB4-8D22-BF99D4068B21", 2)]
        public async Task GetEventsByOrganizer_ReturnsEventsForOrganizer(string organizerId, int expectedAmount)
        {
            var events = await _eventRepository.GetEventsByOrganizer(Guid.Parse(organizerId));

            if (events!.Any())
            {
                Assert.Equal(expectedAmount, events.Count());
            }
            else { Assert.Empty(events); }
        }

        [Theory]
        [InlineData("6B2ABF89-9C35-353A-B083-9D062D1ECBE6", 0)] // non existing ID
        [InlineData("6B2ABF89-359C-463A-B083-9D062D1ECBE6", 1)]
        [InlineData("3152262D-95DE-438D-9FB7-242147A6EBD9", 2)]
        public async Task GetEventsBySponsor_ReturnsEventsForSponsor(string sponsorId, int expectedAmount)
        {
            var events = await _eventRepository.GetEventsBySponsor(Guid.Parse(sponsorId));

            if (events!.Any())
            {
                Assert.Equal(expectedAmount, events.Count());
            }
            else { Assert.Empty(events); }
        }

        [Theory]
        [InlineData("6B2ABF89-9C35-353A-B083-9D062D1ECBE6", 0)] // non existing ID
        [InlineData("7DF28005-7925-40AC-B90D-6AC60DDDADBC", 1)]
        [InlineData("DEDD230B-8208-4C03-9689-51DA60A77431", 2)]
        public async Task GetEventsByVenue_ReturnsEventsForVenue(string venueId, int expectedAmount)
        {
            var events = await _eventRepository.GetEventsByVenue(Guid.Parse(venueId));

            if (events!.Any())
            {
                Assert.Equal(expectedAmount, events.Count());
            }
            else { Assert.Empty(events); }
        }

        [Fact]
        public async Task GetUpcomingEvents_ReturnsEventsHeldSoon()
        {
            var events = await _eventRepository.GetUpcomingEventsAsync();

            if (events!.Any())
            {
                Assert.Equal(2, events.Count());
            }
            else { Assert.Empty(events); }
        }
    }
}
