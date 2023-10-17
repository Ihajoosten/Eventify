using Eventify.Domain.IRepositories;
using Eventify.Domain.IRepositories.Base;
using Eventify.Infrastructure.Data;
using Eventify.Infrastructure.EFRepositories;
using Eventify.Infrastructure.EFRepositories.Base;
using Eventify.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Infastructure Database Dependencies
services.AddDbContext<EventifyDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

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
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog();
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
