namespace Eventify.IntegrationTests.Repositories
{
    [Collection("DatabaseCollection")]
    public class SponsorRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SponsorRepository> _logger;
        private readonly ISponsorRepository _sponsorRepository;
        private readonly SharedDatabaseFixture _fixture;

        public SponsorRepositoryTests(SharedDatabaseFixture fixture)
        {
            _fixture = fixture;

            _unitOfWork = new TestUnitOfWork(_fixture.Context);
            _logger = new Mock<ILogger<SponsorRepository>>().Object;
            _sponsorRepository = new SponsorRepository(_unitOfWork, _logger);
        }

        [Theory]
        [InlineData("6B2ABF89-9C35-353A-B083-9D062D1ECBE6", "notExisting", "notExisting", "notExisting")] // non existing ID
        [InlineData("F2EE2F5F-0549-452E-8FA2-687454E3D427", "Sponsor1", "http://sponsor1.com", "6B2ABF89-359C-463A-B083-9D062D1ECBE6")]
        [InlineData("9933D33A-92A2-4F37-8101-CADC1CDC858C", "Sponsor2", "http://sponsor2.com", "3152262D-95DE-438D-9FB7-242147A6EBD9")]
        public async Task GetSponsorForEvent_ReturnSponsor(string eventId, string name, string websiteUrl, string sponsorId)
        {
            var sponsor = await _sponsorRepository.GetSponsorForEventAsync(Guid.Parse(eventId));

            if (sponsor != null ) 
            {
                Assert.Equal(Guid.Parse(sponsorId!), sponsor.Id);
                Assert.Equal(name, sponsor.Name);
                Assert.Equal(websiteUrl, sponsor.WebsiteUrl);
            }
            else { Assert.Null(sponsor); }
        }
    }
}
