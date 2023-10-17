using Eventify.Domain.IRepositories;
using Eventify.Domain.IRepositories.Base;
using Eventify.Infrastructure.EFRepositories.Base;
using Eventify.Infrastructure.EFRepositories;
using Eventify.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Eventify.Test.Configuration
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDatabase");
            });

            // Infrastructure Repository Dependencies
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVenueRepository, VenueRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAttendeeFeedbackRepository, AttendeeFeedbackRepository>();
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            services.AddScoped<ISponsorRepository, SponsorRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Core services
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog();
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
        }
    }
}
