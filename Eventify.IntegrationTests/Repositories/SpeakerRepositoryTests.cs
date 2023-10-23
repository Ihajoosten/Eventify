using Eventify.IntegrationTests.Config.Fixtures;

namespace Eventify.IntegrationTests.Repositories
{
    [Collection("InfraLayerCollection")]
    public class SpeakerRepositoryTests : IClassFixture<InfraLayerFixture>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SpeakerRepository> _logger;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly InfraLayerFixture _fixture;

        public SpeakerRepositoryTests(InfraLayerFixture fixture)
        {
            _fixture = fixture;

            _unitOfWork = new TestUnitOfWork(_fixture.Context);
            _logger = new Mock<ILogger<SpeakerRepository>>().Object;
            _speakerRepository = new SpeakerRepository(_unitOfWork, _logger);
        }

        [Theory]
        [InlineData("F2EE2F5F-0549-452E-8FA2-687454E3D427", 1, "Speaker", "Speaker bio")]
        [InlineData("9933D33A-92A2-4F37-8101-CADC1CDC858C", 2, "Speaker 2", "Speaker bio 2")]
        public async Task GetSpeakersForEvent_ReturnSpeaker(string eventId, int expectedAmount, string name, string bio)
        {
            var speakers = await _speakerRepository.GetSpeakersForEventAsync(Guid.Parse(eventId));

            if (speakers.Any())
            {
                Assert.Equal(expectedAmount, speakers.Count());

                if (speakers.Count() > 1)
                {
                    for (int i = 0; i < speakers.Count(); i++)
                    {
                        Assert.Equal(speakers.ToList()[i].Name, $"{name}");
                        Assert.Equal(speakers.ToList()[i].Bio, $"{bio}");
                    }
                }
                else
                {
                    Assert.Equal(speakers.ToList()[0].Name, $"{name} 1");
                    Assert.Equal(speakers.ToList()[0].Bio, $"{bio} 1");
                }
            }
            else { Assert.Empty(speakers); }
        }
    }
}
