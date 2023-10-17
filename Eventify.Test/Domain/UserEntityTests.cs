using Eventify.Domain.Entities;
using Eventify.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Test.Domain
{
    public class UserEntityTests
    {
        [Fact]
        public void User_ValidProperties_ShouldNotHaveValidationError()
        {
            // Arrange
            var user = new User
            {
                Username = "john_doe",
                Email = "john.doe@example.com",
                Password = "Password123",
                ConfirmPassword = "Password123",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Parse("1990-01-01"),
                UserAddress = new Address { Street = "123 Main St", City = "Cityville", Country = "Countryland", State = "state", ZipCode = "zipCode" },
                PhoneNumber = "+1234567890",
                Gender = Gender.Male,
                Role = UserRole.User
            };

            // Act
            var errorMessage = ValidateModel(user);

            // Assert
            Assert.Empty(errorMessage);
        }

        [Fact]
        public void User_PasswordMismatch_ShouldHaveValidationError()
        {
            // Arrange
            var user = new User
            {
                Password = "Password123",
                ConfirmPassword = "MismatchedPassword"
            };

            // Act
            var errorMessage = ValidateModel(user);

            // Assert
            Assert.Contains("The password and confirmation password do not match.", errorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void User_InvalidEmail_ShouldHaveValidationError()
        {
            // Arrange
            var user = new User
            {
                Email = "invalid-email"
            };

            // Act
            var errorMessage = ValidateModel(user);

            // Assert
            Assert.Contains("Invalid email address.", errorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void User_TooShortUsername_ShouldHaveValidationError()
        {
            // Arrange
            var user = new User
            {
                Username = "ab"
            };

            // Act
            var errorMessage = ValidateModel(user);

            // Assert
            Assert.Contains("Username must be between 3 and 50 characters.", errorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void User_TooLongFirstName_ShouldHaveValidationError()
        {
            // Arrange
            var user = new User
            {
                FirstName = "VeryLongFirstNameThatExceedsFiftyCharactersAndCausesValidationError"
            };

            // Act
            var errorMessage = ValidateModel(user);

            // Assert
            Assert.Contains("First name cannot exceed 50 characters.", errorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void User_IsAdult_ShouldReturnTrue()
        {
            // Arrange
            var user = new User
            {
                BirthDate = DateTime.Now.AddYears(-20)
            };

            // Act
            var isAdult = user.IsAdult();

            // Assert
            Assert.True(isAdult);
        }

        [Fact]
        public void User_IsNotAdult_ShouldReturnFalse()
        {
            // Arrange
            var user = new User
            {
                BirthDate = DateTime.Now.AddYears(-17)
            };

            // Act
            var isAdult = user.IsAdult();

            // Assert
            Assert.False(isAdult);
        }

        // Add more tests as needed...

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
