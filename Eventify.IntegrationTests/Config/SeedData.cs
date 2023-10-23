namespace Eventify.IntegrationTests.Config
{
    public static class SeedData
    {
        public static void Initialize(TestDbContext context)
        {
            if (!context.Users.Any())
            {
                // Seed User data
                context.Users.AddRange(new List<User>
                    {
                        new User
                {
                    Id = Guid.Parse("8A89AED6-E3D8-409C-B188-77A56DA25889"),
                    Username = "ValidUsername1",
                    Email = "user1@example.com",
                    Password = "Password123",
                    ConfirmPassword = "Password123",
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = DateTime.UtcNow.AddYears(-5),
                    UserAddress = new Address { Street = "Street1", ZipCode = "zipCode1", City = "City1", Country = "Country 1", State = "State1"},
                    PhoneNumber = "1234567890",
                    Gender = Gender.Male,
                    Role = UserRole.User,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,

                },
                        new User
                {
                    Id = Guid.Parse("B37B6940-DE24-4AB4-8D22-BF99D4068B21"),
                    Username = "ValidUsername2",
                    Email = "user2@example.com",
                    Password = "Password123",
                    ConfirmPassword = "Password123",
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = DateTime.UtcNow.AddYears(-25),
                    UserAddress = new Address { Street = "Street2", ZipCode = "zipCode2", City = "City2", Country = "Country2", State = "State2"},
                    PhoneNumber = "1234567890",
                    Gender = Gender.Female,
                    Role = UserRole.Admin,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,

                },
                        new User
                {
                    Id = Guid.Parse("B37B6940-FF33-4AB4-8D22-BF99D4068B21"),
                    Username = "ValidUsername3",
                    Email = "user2@example.com",
                    Password = "Password123",
                    ConfirmPassword = "Password123",
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = DateTime.UtcNow.AddYears(-15),
                    UserAddress = new Address { Street = "Street2", ZipCode = "zipCode2", City = "City2", Country = "Country2", State = "State2"},
                    PhoneNumber = "1234567890",
                    Gender = Gender.Female,
                    Role = UserRole.Admin,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,

                },
                    });

                // Seed Venue data
                context.Venues.AddRange(new List<Venue>
                    {
                        new Venue
                {
                    Id = Guid.Parse("7DF28005-7925-40AC-B90D-6AC60DDDADBC"),
                    Name = "Valid Venue Name",
                    Capacity = 100,
                    ContactPerson = "John Doe",
                    VenueAddress = new Address { Street = "VenueStreet2", ZipCode = "VenuezipCode2", City = "VenueCity2", Country = "VenueCountry2", State = "VenueState2"},
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                },
                        new Venue
                {
                    Id = Guid.Parse("DEDD230B-8208-4C03-9689-51DA60A77431"),
                    Name = "Valid Venue Name",
                    Capacity = 100,
                    ContactPerson = "John Doe",
                    VenueAddress = new Address { Street = "VenueStreet2", ZipCode = "VenuezipCode2", City = "VenueCity2", Country = "VenueCountry2", State = "VenueState2"},
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                },
                    });

                // Seed Sponsor data
                context.Sponsors.AddRange(new List<Sponsor>
                    {
                        new Sponsor
                    {
                        Id = Guid.Parse("6B2ABF89-359C-463A-B083-9D062D1ECBE6"),
                        Name = "Sponsor1",
                        Logo = null,
                        Description = "Description 1",
                        WebsiteUrl = "http://sponsor1.com",
                        Created = DateTime.UtcNow,
                        Updated = DateTime.UtcNow,
                    },
                        new Sponsor
                    {
                        Id = Guid.Parse("3152262D-95DE-438D-9FB7-242147A6EBD9"),
                        Name = "Sponsor2",
                        Logo = null,
                        Description = "Description 1",
                        WebsiteUrl = "http://sponsor2.com",
                        Created = DateTime.UtcNow,
                        Updated = DateTime.UtcNow,
                    }
                    });

                // Seed Event data
                context.Events.AddRange(new List<Event>
                    {
                        new Event
                    {
                        Id = Guid.Parse("F2EE2F5F-0549-452E-8FA2-687454E3D427"),
                        Title = "Valid Title",
                        Description = "Description",
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddDays(-5),
                        EventUrl = "https://example.com",
                        IsRegistrationRequired = true,
                        MaximumAttendees = 100,
                        OrganizerId = Guid.Parse("8A89AED6-E3D8-409C-B188-77A56DA25889"),
                        VenueId = Guid.Parse("7DF28005-7925-40AC-B90D-6AC60DDDADBC"),
                        SponsorId = Guid.Parse("6B2ABF89-359C-463A-B083-9D062D1ECBE6"),
                        Created = DateTime.UtcNow,
                        Updated = DateTime.UtcNow,
                    },
                        new Event
                    {
                        Id = Guid.Parse("9933D33A-92A2-4F37-8101-CADC1CDC858C"),
                        Title = "Valid Title",
                        Description = "Description",
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddDays(5),
                        EventUrl = "https://example.com",
                        IsRegistrationRequired = true,
                        MaximumAttendees = 100,
                        OrganizerId = Guid.Parse("B37B6940-DE24-4AB4-8D22-BF99D4068B21"),
                        VenueId = Guid.Parse("DEDD230B-8208-4C03-9689-51DA60A77431"),
                        SponsorId = Guid.Parse("3152262D-95DE-438D-9FB7-242147A6EBD9"),
                        Created = DateTime.UtcNow,
                        Updated = DateTime.UtcNow,
                    },
                        new Event
                    {
                        Id = Guid.Parse("4499D33A-92A2-4F37-8101-CADC1CDC858C"),
                        Title = "Valid Title",
                        Description = "Description",
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddDays(2),
                        EventUrl = "https://example.com",
                        IsRegistrationRequired = true,
                        MaximumAttendees = 100,
                        OrganizerId = Guid.Parse("B37B6940-DE24-4AB4-8D22-BF99D4068B21"),
                        VenueId = Guid.Parse("DEDD230B-8208-4C03-9689-51DA60A77431"),
                        SponsorId = Guid.Parse("3152262D-95DE-438D-9FB7-242147A6EBD9"),
                        Created = DateTime.UtcNow,
                        Updated = DateTime.UtcNow,
                    },
                    });

                // Seed Speaker data
                context.Speakers.AddRange(new List<Speaker>
                    {
                        new Speaker
                        {
                            Id = Guid.Parse("D1C31A91-4D7E-4498-9FB0-F9C0E42C4337"),
                            Name = "Speaker 1",
                            Bio = "Speaker bio 1",
                            ProfileImage = null,
                            ContactEmail = "speaker1@contact.nl",
                            Created = DateTime.UtcNow,
                            Updated = DateTime.UtcNow
                        },
                        new Speaker
                        {
                            Id = Guid.Parse("C7D53828-820D-420C-8885-3E94A6C3F9F4"),
                            Name = "Speaker 2",
                            Bio = "Speaker bio 2",
                            ProfileImage = null,
                            ContactEmail = "speaker2@contact.nl",
                            Created = DateTime.UtcNow,
                            Updated = DateTime.UtcNow
                        },
                        new Speaker
                        {
                            Id = Guid.Parse("6850E2E5-0C97-4AF6-B265-93097EB47EEC"),
                            Name = "Speaker 2",
                            Bio = "Speaker bio 2",
                            ProfileImage = null,
                            ContactEmail = "speaker2@contact.nl",
                            Created = DateTime.UtcNow,
                            Updated = DateTime.UtcNow
                        },
                    });

                // Seed Session data
                context.Sessions.AddRange(new List<Session>
                    {
                        new Session
                        {
                            Id = Guid.Parse("DCCDE830-A08D-403F-B52C-03A8A3CDA539"),
                            Title = "Session 1 Title",
                            Description = "Session 1 Description",
                            StartTime = DateTime.UtcNow.AddHours(2).ToLocalTime(),
                            EndTime = DateTime.UtcNow.AddHours(4).ToLocalTime(),
                            SpeakerId = Guid.Parse("D1C31A91-4D7E-4498-9FB0-F9C0E42C4337"),
                            EventId = Guid.Parse("F2EE2F5F-0549-452E-8FA2-687454E3D427"),
                            Created = DateTime.UtcNow,
                            Updated = DateTime.UtcNow
                        },
                        new Session
                        {
                            Id = Guid.Parse("99A7762C-3806-436C-96F8-0FBBF48ABFCD"),
                            Title = "Session 2 Title",
                            Description = "Session 2 Description",
                            StartTime = DateTime.UtcNow.AddHours(2).ToLocalTime(),
                            EndTime = DateTime.UtcNow.AddHours(4).ToLocalTime(),
                            SpeakerId = Guid.Parse("C7D53828-820D-420C-8885-3E94A6C3F9F4"),
                            EventId = Guid.Parse("9933D33A-92A2-4F37-8101-CADC1CDC858C"),
                            Created = DateTime.UtcNow,
                            Updated = DateTime.UtcNow
                        },
                        new Session
                        {
                            Id = Guid.Parse("1755FCFC-9CED-4849-86B8-82657754EDCA"),
                            Title = "Session 3 Title",
                            Description = "Session 3 Description",
                            StartTime = DateTime.UtcNow.AddHours(2).ToLocalTime(),
                            EndTime = DateTime.UtcNow.AddHours(4).ToLocalTime(),
                            SpeakerId = Guid.Parse("6850E2E5-0C97-4AF6-B265-93097EB47EEC"),
                            EventId = Guid.Parse("9933D33A-92A2-4F37-8101-CADC1CDC858C"),
                            Created = DateTime.UtcNow,
                            Updated = DateTime.UtcNow
                        }
                    });

                context.SaveChanges();
            }
        }
    }
}
