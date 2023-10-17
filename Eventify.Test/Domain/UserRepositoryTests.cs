using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Domain.ValueObjects;
using Moq;

namespace Eventify.Test.Domain
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task GetUserByUsernameAsync_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var username = "john_doe";
            var expectedUser = new User { Username = username, /* other properties */ };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserByUsernameAsync(username)).ReturnsAsync(expectedUser);

            // Act
            var result = await userRepositoryMock.Object.GetUserByUsernameAsync(username);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUser, result);
        }

        [Fact]
        public async Task GetUserByUsernameAsync_ReturnsNull_WhenUserDoesNotExist()
        {
            // Arrange
            var username = "nonexistent_user";

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserByUsernameAsync(username)).ReturnsAsync((User)null);

            // Act
            var result = await userRepositoryMock.Object.GetUserByUsernameAsync(username);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUsersByGenderAsync_ReturnsUsers_WhenUsersExist()
        {
            // Arrange
            var gender = Gender.Male;
            var expectedUsers = new List<User>
        {
            new User { Gender = gender, /* other properties */ },
            new User { Gender = gender, /* other properties */ },
            // Add more users as needed
        };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByGenderAsync(gender)).ReturnsAsync(expectedUsers);

            // Act
            var result = await userRepositoryMock.Object.GetUsersByGenderAsync(gender);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUsers, result);
        }

        [Fact]
        public async Task GetUsersByGenderAsync_ReturnsEmptyList_WhenNoUsersExist()
        {
            // Arrange
            var gender = Gender.Other;

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByGenderAsync(gender)).ReturnsAsync(new List<User>());

            // Act
            var result = await userRepositoryMock.Object.GetUsersByGenderAsync(gender);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetUsersByRoleAsync_ReturnsUsers_WhenUsersExist()
        {
            // Arrange
            var role = UserRole.Admin;
            var expectedUsers = new List<User>
        {
            new User { Role = role, /* other properties */ },
            new User { Role = role, /* other properties */ },
            // Add more users as needed
        };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByRoleAsync(role)).ReturnsAsync(expectedUsers);

            // Act
            var result = await userRepositoryMock.Object.GetUsersByRoleAsync(role);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUsers, result);
        }

        [Fact]
        public async Task GetUsersByRoleAsync_ReturnsEmptyList_WhenNoUsersExist()
        {
            // Arrange
            var role = UserRole.Moderator;

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByRoleAsync(role)).ReturnsAsync(new List<User>());

            // Act
            var result = await userRepositoryMock.Object.GetUsersByRoleAsync(role);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetUsersByCity_ReturnsUsers_WhenUsersExist()
        {
            // Arrange
            var city = "Cityville";
            var expectedUsers = new List<User>
        {
            new User { UserAddress = new Address { Street = "123 Main St", City = "Cityville", Country = "Countryland", State = "state", ZipCode = "zipCode" }, /* other properties */ },
            new User { UserAddress = new Address { Street = "123 Main St", City = "Cityville", Country = "Countryland", State = "state", ZipCode = "zipCode" }, /* other properties */ },
            // Add more users as needed
        };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByCity(city)).ReturnsAsync(expectedUsers);

            // Act
            var result = await userRepositoryMock.Object.GetUsersByCity(city);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUsers, result);
        }

        [Fact]
        public async Task GetUsersByCity_ReturnsEmptyList_WhenNoUsersExist()
        {
            // Arrange
            var city = "NonexistentCity";

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByCity(city)).ReturnsAsync(new List<User>());

            // Act
            var result = await userRepositoryMock.Object.GetUsersByCity(city);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetUsersByCountry_ReturnsUsers_WhenUsersExist()
        {
            // Arrange
            var country = "Countryland";
            var expectedUsers = new List<User>
        {
            new User { UserAddress = new Address { Street = "123 Main St", City = "Cityville", Country = country, State = "state", ZipCode = "zipCode" }, /* other properties */ },
            new User { UserAddress = new Address { Street = "123 Main St", City = "Cityville", Country = country, State = "state", ZipCode = "zipCode" }, /* other properties */ },
            // Add more users as needed
        };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByCountry(country)).ReturnsAsync(expectedUsers);

            // Act
            var result = await userRepositoryMock.Object.GetUsersByCountry(country);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUsers, result);
        }
    }
}
