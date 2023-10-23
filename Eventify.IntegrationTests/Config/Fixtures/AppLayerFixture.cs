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
                .UseNpgsql("Host=ep-soft-sunset-52153316.eu-central-1.aws.neon.tech;Port=5432;Database=eventify2-test;Username=Ihajoosten;Password=vaIM1win0Ucs;Integrated Security=true;")
                .Options;

            Context = new TestDbContext(_options);

            // Ensure the database is created and apply migrations
            Context.Database.EnsureCreated();

            // Clean Database
            Context.Users.Clear();
            Context.Venues.Clear();
            Context.Events.Clear();
            Context.Sponsors.Clear();
            Context.Speakers.Clear();
            Context.Sessions.Clear();
            Context.Registrations.Clear();
            Context.AttendeeFeedbacks.Clear();
            Context.SaveChanges();

            // Migrate Database
            Context.Database.Migrate();
            // Seed the database with initial data
            SeedData.Initialize(Context);
        }

        public void Dispose()
        {
            // Clean up the database after all tests have run
            //Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }

    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
