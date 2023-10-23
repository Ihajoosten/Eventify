namespace Eventify.UnitTest.Entities
{
    public class UserTests
    {
        [Fact]
        public void UsernameValidation_ValidCase()
        {
            // Arrange
            var user = new User
            {
                Username = "ValidUsername",
                Email = "user@example.com",
                Password = "Password123",
                ConfirmPassword = "Password123",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-25),
                UserAddress = new Address { /* Address properties here */ },
                PhoneNumber = "1234567890",
                Gender = Gender.Male,
                Role = UserRole.User
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void UsernameValidation_LengthTooShort()
        {
            // Arrange
            var user = new User
            {
                Username = "ab",
                Email = "user@example.com",
                Password = "Password123",
                ConfirmPassword = "Password123",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-25),
                UserAddress = new Address { /* Address properties here */ },
                PhoneNumber = "1234567890",
                Gender = Gender.Male,
                Role = UserRole.User
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.Single(validationResults);
            Assert.Equal("Username must be between 3 and 50 characters.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void UsernameValidation_LengthTooLong()
        {
            // Arrange
            var user = new User
            {
                Username = new string('a', 51),
                Email = "user@example.com",
                Password = "Password123",
                ConfirmPassword = "Password123",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-25),
                UserAddress = new Address { /* Address properties here */ },
                PhoneNumber = "1234567890",
                Gender = Gender.Male,
                Role = UserRole.User
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.Single(validationResults);
            Assert.Equal("Username must be between 3 and 50 characters.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void EmailValidation_ValidCase()
        {
            // Arrange
            var user = new User
            {
                Username = "ValidUsername",
                Email = "user@example.com",
                Password = "Password123",
                ConfirmPassword = "Password123",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-25),
                UserAddress = new Address { /* Address properties here */ },
                PhoneNumber = "1234567890",
                Gender = Gender.Male,
                Role = UserRole.User
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void EmailValidation_InvalidCase()
        {
            // Arrange
            var user = new User
            {
                Username = "ValidUsername",
                Email = "invalid-email",
                Password = "Password123",
                ConfirmPassword = "Password123",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-25),
                UserAddress = new Address { /* Address properties here */ },
                PhoneNumber = "1234567890",
                Gender = Gender.Male,
                Role = UserRole.User
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.Single(validationResults);
            Assert.Equal("Invalid email address.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void PasswordValidation_ValidCase()
        {
            // Arrange
            var user = new User
            {
                Username = "ValidUsername",
                Email = "user@example.com",
                Password = "Password123",
                ConfirmPassword = "Password123",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-25),
                UserAddress = new Address { /* Address properties here */ },
                PhoneNumber = "1234567890",
                Gender = Gender.Male,
                Role = UserRole.User
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void PasswordValidation_LengthTooShort()
        {
            // Arrange
            var user = new User
            {
                Username = "ValidUsername",
                Email = "user@example.com",
                Password = "short",
                ConfirmPassword = "short",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-25),
                UserAddress = new Address { /* Address properties here */ },
                PhoneNumber = "1234567890",
                Gender = Gender.Male,
                Role = UserRole.User
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.Single(validationResults);
            Assert.Equal("Password must be at least 6 characters.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void ConfirmPasswordValidation_MatchPassword()
        {
            // Arrange
            var user = new User
            {
                Username = "ValidUsername",
                Email = "user@example.com",
                Password = "Password123",
                ConfirmPassword = "Password123",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-25),
                UserAddress = new Address { /* Address properties here */ },
                PhoneNumber = "1234567890",
                Gender = Gender.Male,
                Role = UserRole.User
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void ConfirmPasswordValidation_MismatchPassword()
        {
            // Arrange
            var user = new User
            {
                Username = "ValidUsername",
                Email = "user@example.com",
                Password = "Password123",
                ConfirmPassword = "Mismatched",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-25),
                UserAddress = new Address { /* Address properties here */ },
                PhoneNumber = "1234567890",
                Gender = Gender.Male,
                Role = UserRole.User
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.Single(validationResults);
            Assert.Equal("The password and confirmation password do not match.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void IsAdult_CalculatesAgeAndReturnsTrue()
        {
            // Arrange
            var birthdate = DateTime.Now.AddYears(-25);
            var user = new User
            {
                Username = "ValidUsername",
                Email = "user@example.com",
                Password = "Password123",
                ConfirmPassword = "Password123",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = birthdate,
                UserAddress = new Address { /* Address properties here */ },
                PhoneNumber = "1234567890",
                Gender = Gender.Male,
                Role = UserRole.User
            };

            // Act
            var isAdult = user.IsAdult();

            // Assert
            Assert.True(isAdult);
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
