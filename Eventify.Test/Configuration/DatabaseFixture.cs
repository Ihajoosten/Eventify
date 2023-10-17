using Eventify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Test.Configuration
{
    public class DatabaseFixture : IDisposable
    {
        public TestDbContext Context { get; private set; }

        public DatabaseFixture()
        {
            // Initialize your context or other setup here
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            Context = new TestDbContext(options);
        }


        public void Dispose()
        {
            ClearData<Venue>();
            ClearData<User>();
            ClearData<Session>();
            ClearData<Speaker>();
            ClearData<Registration>();
            ClearData<AttendeeFeedback>();
            ClearData<Event>();
            ClearData<Sponsor>();

            // Clean up resources, e.g., close the context
            Context.Dispose();
            GC.SuppressFinalize(this);

        }

        public void ClearData<T>() where T : class
        {
            var tableData = Context.Set<T>();
            tableData.RemoveRange(tableData);
            Context.SaveChangesAsync();
        }
    }
}
