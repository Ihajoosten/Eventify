using Eventify.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Test.Domain
{
    public class EventUnitTests
    {
        [Fact]
        public void Event_ValidProperties_ShouldNotHaveValidationError()
        {
            // Arrange
            var @event = new Event
            {
                Description = "Description of the event.",
                StartDate = DateTime.Now.AddDays(7),
                EndDate = DateTime.Now.AddDays(8),
                EventUrl = "https://example.com/event",
                OrganizerEmail = "organizer@example.com",
                OrganizerPhoneNumber = "+1234567890",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var errorMessage = ValidateModel(@event);

            // Assert
            Assert.Contains("The Title field is required.", errorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Event_MissingDescription_ShouldHaveValidationError()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Sample Event",
                // Description is missing
                StartDate = DateTime.Now.AddDays(7),
                EndDate = DateTime.Now.AddDays(8),
                EventUrl = "https://example.com/event",
                OrganizerEmail = "organizer@example.com",
                OrganizerPhoneNumber = "+1234567890",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var errorMessage = ValidateModel(@event);

            // Assert
            Assert.Contains("The Description field is required.", errorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Event_EndDateBeforeStartDate_ShouldHaveValidationError()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Sample Event",
                Description = "Description of the event.",
                StartDate = DateTime.Now.AddDays(5),
                EndDate = DateTime.Now, // End date before start date
                EventUrl = "https://example.com/event",
                OrganizerEmail = "organizer@example.com",
                OrganizerPhoneNumber = "+1234567890",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var errorMessage = ValidateModel(@event);

            // Assert
            Assert.Contains("End date must be greater than Start date.", errorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Event_ValidEventUrl_ShouldNotHaveValidationError()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Sample Event",
                Description = "Description of the event.",
                StartDate = DateTime.Now.AddDays(7),
                EndDate = DateTime.Now.AddDays(8),
                EventUrl = "https://example.com/event", // Valid URL
                OrganizerEmail = "organizer@example.com",
                OrganizerPhoneNumber = "+1234567890",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var errorMessage = ValidateModel(@event);

            // Assert
            Assert.DoesNotContain("Event URL", errorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Event_InvalidEventUrl_ShouldHaveValidationError()
        {
            // Arrange
            var @event = new Event
            {
                Title = "Sample Event",
                Description = "Description of the event.",
                StartDate = DateTime.Now.AddDays(7),
                EndDate = DateTime.Now.AddDays(8),
                EventUrl = "invalid-url", // Invalid URL
                OrganizerEmail = "organizer@example.com",
                OrganizerPhoneNumber = "+1234567890",
                IsRegistrationRequired = true,
                MaximumAttendees = 100,
                VenueId = Guid.NewGuid(),
                SponsorId = Guid.NewGuid()
            };

            // Act
            var errorMessage = ValidateModel(@event);

            // Assert
            Assert.Contains("Invalid URL format", errorMessage, StringComparison.OrdinalIgnoreCase);
        }


        private static string ValidateModel(object model)
        {
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(model, validationContext, validationResults, true);

            var errorMessages = validationResults
                .SelectMany(result => result.MemberNames.Select(memberName => $"{memberName}: {result.ErrorMessage}"))
                .ToList();

            return string.Join(Environment.NewLine, errorMessages);
        }
    }
}
