namespace Eventify.UnitTest.Entities
{
    public class VenueEntityTests
    {
        [Fact]
        public void NameValidation_ValidCase()
        {
            // Arrange
            var venue = new Venue
            {
                Name = "Valid Venue Name",
                Capacity = 100,
                ContactPerson = "John Doe",
                VenueAddress = new Address { /* Address properties here */ },
                Events = new List<Event>()
            };

            // Act
            var validationResults = ValidateModel(venue);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void NameValidation_LengthTooLong()
        {
            // Arrange
            var venue = new Venue
            {
                Name = new string('a', 101), // Exceeds the 100 character limit
                Capacity = 100,
                ContactPerson = "John Doe",
                VenueAddress = new Address { /* Address properties here */ },
                Events = new List<Event>()
            };

            // Act
            var validationResults = ValidateModel(venue);

            // Assert
            Assert.Single(validationResults);
            Assert.Equal("Name cannot exceed 100 characters.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void CapacityValidation_ValidCase()
        {
            // Arrange
            var venue = new Venue
            {
                Name = "Valid Venue Name",
                Capacity = 100, // Valid capacity
                ContactPerson = "John Doe",
                VenueAddress = new Address { /* Address properties here */ },
                Events = new List<Event>()
            };

            // Act
            var validationResults = ValidateModel(venue);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void CapacityValidation_ZeroCapacity()
        {
            // Arrange
            var venue = new Venue
            {
                Name = "Valid Venue Name",
                Capacity = 0, // Capacity must be greater than 0
                ContactPerson = "John Doe",
                VenueAddress = new Address { /* Address properties here */ },
                Events = new List<Event>()
            };

            // Act
            var validationResults = ValidateModel(venue);

            // Assert
            Assert.Single(validationResults);
            Assert.Equal("Capacity must be greater than 0.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void ContactPersonValidation_ValidCase()
        {
            // Arrange
            var venue = new Venue
            {
                Name = "Valid Venue Name",
                Capacity = 100,
                ContactPerson = "John Doe", // Valid contact person name
                VenueAddress = new Address { /* Address properties here */ },
                Events = new List<Event>()
            };

            // Act
            var validationResults = ValidateModel(venue);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void ContactPersonValidation_LengthTooLong()
        {
            // Arrange
            var venue = new Venue
            {
                Name = "Valid Venue Name",
                Capacity = 100,
                ContactPerson = new string('a', 51), // Exceeds the 50 character limit
                VenueAddress = new Address { /* Address properties here */ },
                Events = new List<Event>()
            };

            // Act
            var validationResults = ValidateModel(venue);

            // Assert
            Assert.Single(validationResults);
            Assert.Equal("Contact Person Name exceed 50 characters.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void VenueAddressValidation_ValidCase()
        {
            // Arrange
            var venue = new Venue
            {
                Name = "Valid Venue Name",
                Capacity = 100,
                ContactPerson = "John Doe",
                VenueAddress = new Address { /* Address properties here */ }, // Valid VenueAddress
                Events = new List<Event>()
            };

            // Act
            var validationResults = ValidateModel(venue);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void EventsListValidation_EmptyEvents()
        {
            // Arrange
            var venue = new Venue
            {
                Name = "Valid Venue Name",
                Capacity = 100,
                ContactPerson = "John Doe",
                VenueAddress = new Address { /* Address properties here */ },
                Events = new List<Event>() // Empty Events list
            };

            // Act
            var validationResults = ValidateModel(venue);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void EventsListValidation_NullEvents()
        {
            // Arrange
            var venue = new Venue
            {
                Name = "Valid Venue Name",
                Capacity = 100,
                ContactPerson = "John Doe",
                VenueAddress = new Address { /* Address properties here */ },
                Events = null // Null Events list
            };

            // Act
            var validationResults = ValidateModel(venue);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void EventsListValidation_WithEvents()
        {
            // Arrange
            var venue = new Venue
            {
                Name = "Valid Venue Name",
                Capacity = 100,
                ContactPerson = "John Doe",
                VenueAddress = new Address { /* Address properties here */ },
                Events = new List<Event> { new Event(), new Event() } // Events with data
            };

            // Act
            var validationResults = ValidateModel(venue);

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
