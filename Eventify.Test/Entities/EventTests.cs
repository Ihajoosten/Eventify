namespace Eventify.UnitTest.Entities
{
    public class EventTests
    {
        [Fact]
        public void TitleValidation_ValidCase()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Valid Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                EventUrl = "https://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                OrganizerId = Guid.NewGuid(),
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var validationResults = ValidateModel(@event);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void TitleValidation_LengthTooLong()
        {
            // Arrange
            var @event = new Event
            {
                Title = new string('a', 101), // Exceeds the 100 character limit
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                EventUrl = "https://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                OrganizerId = Guid.NewGuid(),
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var validationResults = ValidateModel(@event);

            // Assert
            Assert.Single(validationResults);
            Assert.Equal("Title cannot exceed 100 characters.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void StartDateValidation_ValidCase()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Valid Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                EventUrl = "https://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                OrganizerId = Guid.NewGuid(),
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var validationResults = ValidateModel(@event);

            // Assert
            Assert.Empty(validationResults);
        }

        // Add similar tests for other validation attributes...

        [Fact]
        public void EventUrlValidation_InvalidUrl()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Valid Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                EventUrl = "invalid-url",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                OrganizerId = Guid.NewGuid(),
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var validationResults = ValidateModel(@event);

            // Assert
            Assert.Single(validationResults);
            Assert.Equal("Invalid URL format.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void EndDateValidation_EndDateBeforeStartDate()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Valid Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(-2), // Set end date before start date
                EventUrl = "https://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                OrganizerId = Guid.NewGuid(),
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var validationResults = ValidateModel(@event);

            // Assert
            Assert.Single(validationResults);
            Assert.Equal("End date must be greater than Start date.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void IsRegistrationRequiredValidation_True()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Valid Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                EventUrl = "https://example.com",
                IsRegistrationRequired = true, // True is valid
                MaximumAttendees = 100,
                OrganizerId = Guid.NewGuid(),
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var validationResults = ValidateModel(@event);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void MaximumAttendeesValidation_ValidCase()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Valid Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                EventUrl = "https://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 100, // Valid maximum attendees value
                OrganizerId = Guid.NewGuid(),
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var validationResults = ValidateModel(@event);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void OrganizerIdValidation_ValidCase()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Valid Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                EventUrl = "https://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                OrganizerId = Guid.NewGuid(), // Valid organizer ID
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var validationResults = ValidateModel(@event);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void VenueIdValidation_ValidCase()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Valid Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                EventUrl = "https://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                OrganizerId = Guid.NewGuid(),
                VenueId = Guid.NewGuid(), // Valid venue ID
                SponsorId = Guid.NewGuid()
            };

            // Act
            var validationResults = ValidateModel(@event);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void SponsorIdValidation_ValidCase()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Valid Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                EventUrl = "https://example.com",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                OrganizerId = Guid.NewGuid(),
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid() // Valid sponsor ID
            };

            // Act
            var validationResults = ValidateModel(@event);

            // Assert
            Assert.Empty(validationResults);
        }

        private static ValidationResult[] ValidateModel(object model)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(model, context, results, validateAllProperties: true);

            return results.ToArray();
        }
    }
}
