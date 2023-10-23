using Eventify.Application.Commands.Event;
using Eventify.Application.Dto;

namespace Eventify.IntegrationTests.Handlers.Command
{
    [Collection("AppLayerCollection")]
    public class EventCommandHandlerTests : IClassFixture<AppLayerFixture>, IClassFixture<AutoMapperFixture>
    {
        // Repository
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EventRepository> _logger;
        private readonly IEventRepository _eventRepository;
        // Command Handler
        private readonly ICommandHandler<EventDto, IEventCommand> _commandHandler;
        private readonly ILogger<EventCommandHandler> _commandLogger;
        private readonly IMapper _mapper;
        // Fixture
        private readonly AppLayerFixture _fixture;


        public EventCommandHandlerTests(AppLayerFixture fixture, AutoMapperFixture mapFixture)
        {
            _fixture = fixture;

            _unitOfWork = new TestUnitOfWork(_fixture.Context);
            _logger = new Mock<ILogger<EventRepository>>().Object;
            _eventRepository = new EventRepository(_unitOfWork, _logger);

            _mapper = mapFixture.Mapper;
            _commandLogger = new Mock<ILogger<EventCommandHandler>>().Object;
            _commandHandler = new EventCommandHandler(_eventRepository, _commandLogger, _mapper);
        }

        [Fact]
        public async Task CreateEvent_ShouldReturnValidDto()
        {
            // Arrange
            var createCommand = new CreateEventCommand
            {
                Title = "Test",
                Description = "Test Description",
                StartDate = DateTime.Now.AddDays(10),
                EndDate = DateTime.Now.AddDays(25),
                EventUrl = "http://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 50,
                VenueId = Guid.Parse("7DF28005-7925-40AC-B90D-6AC60DDDADBC"),
                SponsorId = Guid.Parse("6B2ABF89-359C-463A-B083-9D062D1ECBE6"),
                OrganizerId = Guid.Parse("B37B6940-FF33-4AB4-8D22-BF99D4068B21"),
            };

            var expectedDto = new EventDto
            {
                Title = "Test",
                Description = "Test Description",
                StartDate = DateTime.Now.AddDays(10),
                EndDate = DateTime.Now.AddDays(25),
                EventUrl = "http://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 50,
                Organizer = _mapper.Map<UserDto>(await _fixture.Context.Users.FirstOrDefaultAsync(u => u.Id == createCommand.OrganizerId))
            };

            // Act
            var dtoResult = await _commandHandler.Handle(createCommand);
            var result = await _eventRepository.GetEventsByOrganizer(Guid.Parse("B37B6940-FF33-4AB4-8D22-BF99D4068B21"));

            // Assert
            Assert.NotNull(dtoResult);
            Assert.IsAssignableFrom<EventDto>(dtoResult);


            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Event>>(result);
            Assert.IsAssignableFrom<EventDto>(dtoResult);

            Assert.True(result.Any());
            Assert.Single(result);

            var @event = result.First();

            // Additional asserts for property matching
            Assert.Equal(expectedDto.Title, @event.Title);
            Assert.Equal(expectedDto.Description, @event.Description);
            Assert.Equal(expectedDto.StartDate.ToShortDateString(), @event.StartDate.ToShortDateString());
            Assert.Equal(expectedDto.EndDate.ToShortDateString(), @event.EndDate.ToShortDateString());
            Assert.Equal(expectedDto.EventUrl, @event.EventUrl);
            Assert.Equal(expectedDto.MaximumAttendees, @event.MaximumAttendees);
            Assert.Equal(expectedDto.Organizer.Id, @event.Organizer.Id);
        }
    }
}