namespace Eventify.IntegrationTests.Config.Fixtures
{
    public class AppLayerFixture : IDisposable
    {
        private readonly DbContextOptions<TestDbContext> _options;
        public TestDbContext Context { get; private set; }

        public AppLayerFixture()
        {
            // Initialize the database context with the same connection string
            _options = new DbContextOptionsBuilder<TestDbContext>()
                .UseNpgsql("Host=localhost;Port=5432;Database=eventify-app-test;Username=postgres;Password=postgres;Integrated Security=true;Pooling=true;")
                .Options;

            Context = new TestDbContext(_options);

            // Ensure the database is created and apply migrations
            Context.Database.EnsureCreated();
            // Migrate Database
            Context.Database.Migrate();
            // Seed the database with initial data
            SeedData.Initialize(Context);
        }

        public void Dispose()
        {
            // Clean up the database after all tests have run
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
