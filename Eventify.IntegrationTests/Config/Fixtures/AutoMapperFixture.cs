namespace Eventify.IntegrationTests.Config.Fixtures
{
    public class AutoMapperFixture : IDisposable
    {
        public IMapper Mapper { get; }

        public AutoMapperFixture()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TestMappingProfile());
            });

            Mapper = config.CreateMapper();
        }

        public void Dispose()
        {
            // Clean up resources, if necessary
        }
    }

}
