using Eventify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Eventify.Infrastructure.Data
{
    public class EventifyDbContext : DbContext
    {
        public EventifyDbContext() { }
        public EventifyDbContext(DbContextOptions<EventifyDbContext> options) : base(options) { }

        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<AttendeeFeedback> AttendeeFeedbacks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddSerilog()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Venue entity
            modelBuilder.Entity<Venue>()
                .HasMany(v => v.Events)
                .WithOne(e => e.Venue)
                .HasForeignKey(e => e.VenueId);

            // Event entity
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany(u => u.OrganizedEvents)
                .HasForeignKey(e => e.OrganizerId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Sponsor)
                .WithMany(s => s.SponsoredEvents)
                .HasForeignKey(e => e.SponsorId);

            // Speaker entity
            modelBuilder.Entity<Speaker>()
                .HasMany(s => s.Sessions)
                .WithOne(session => session.Speaker)
                .HasForeignKey(session => session.SpeakerId);

            // Session entity
            modelBuilder.Entity<Session>()
                .HasOne(session => session.Event)
                .WithMany(e => e.Sessions)
                .HasForeignKey(session => session.EventId);

            // AttendeeFeedback entity
            modelBuilder.Entity<AttendeeFeedback>()
                .HasOne(feedback => feedback.Session)
                .WithMany(session => session.Feedbacks)
                .HasForeignKey(feedback => feedback.SessionId);

            modelBuilder.Entity<AttendeeFeedback>()
                .HasOne(feedback => feedback.User)
                .WithMany(user => user.Feedbacks)
                .HasForeignKey(feedback => feedback.UserId);

            // User entity
            modelBuilder.Entity<User>()
                .HasMany(user => user.Feedbacks)
                .WithOne(feedback => feedback.User)
                .HasForeignKey(feedback => feedback.UserId);

            modelBuilder.Entity<User>()
                .HasMany(user => user.OrganizedEvents)
                .WithOne(e => e.Organizer)
                .HasForeignKey(e => e.OrganizerId);

            // Add the Registration entity configuration
            modelBuilder.Entity<Registration>()
                .HasKey(r => r.Id);

            // Relationships
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.User)
                .WithMany(u => u.Registrations)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(r => r.EventId);

            // Address owned property
            modelBuilder.Entity<Venue>()
                .OwnsOne(venue => venue.VenueAddress, address =>
                {
                    address.Property(a => a.Street).IsRequired().HasMaxLength(100);
                    address.Property(a => a.City).IsRequired().HasMaxLength(50);
                    address.Property(a => a.State).IsRequired().HasMaxLength(50);
                    address.Property(a => a.ZipCode).IsRequired().HasMaxLength(20);
                    address.Property(a => a.Country).IsRequired().HasMaxLength(50);
                });

            modelBuilder.Entity<User>()
                .OwnsOne(user => user.UserAddress, address =>
                {
                    address.Property(a => a.Street).IsRequired().HasMaxLength(100);
                    address.Property(a => a.City).IsRequired().HasMaxLength(50);
                    address.Property(a => a.State).IsRequired().HasMaxLength(50);
                    address.Property(a => a.ZipCode).IsRequired().HasMaxLength(20);
                    address.Property(a => a.Country).IsRequired().HasMaxLength(50);
                });

            // Additional configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
