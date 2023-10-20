namespace Eventify.UnitTest.IRepositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task GetUserByUsernameAsync_ValidUsername_ReturnsUser()
        {
            // Arrange
            var username = "TestUser";
            var expectedUser = new User { Username = username };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserByUsernameAsync(username)).ReturnsAsync(expectedUser);

            // Act
            var result = await userRepositoryMock.Object.GetUserByUsernameAsync(username);

            // Assert
            Assert.Equal(expectedUser, result);
        }

        [Fact]
        public async Task GetUserByUsernameAsync_InvalidUsername_ReturnsNull()
        {
            // Arrange
            var username = "NonExistentUser";
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserByUsernameAsync(username)).ReturnsAsync((User)null);

            // Act
            var result = await userRepositoryMock.Object.GetUserByUsernameAsync(username);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUsersByCity_ValidCity_ReturnsUsers()
        {
            // Arrange
            var city = "TestCity";
            var users = new List<User> { new User { UserAddress = new Address { City = city } }, new User { UserAddress = new Address { City = city } } };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByCity(city)).ReturnsAsync(users);

            // Act
            var result = await userRepositoryMock.Object.GetUsersByCity(city);

            // Assert
            Assert.Equal(users, result);
        }

        [Fact]
        public async Task GetUsersByCity_NonExistentCity_ReturnsEmptyList()
        {
            // Arrange
            var city = "NonExistentCity";
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByCity(city)).ReturnsAsync(new List<User>());

            // Act
            var result = await userRepositoryMock.Object.GetUsersByCity(city);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetUsersByCountry_NonExistentCountry_ReturnsEmptyList()
        {
            // Arrange
            var country = "NonExistentCountry";
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByCountry(country)).ReturnsAsync(new List<User>());

            // Act
            var result = await userRepositoryMock.Object.GetUsersByCountry(country);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetUsersByState_NonExistentState_ReturnsEmptyList()
        {
            // Arrange
            var state = "NonExistentState";
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByState(state)).ReturnsAsync(new List<User>());

            // Act
            var result = await userRepositoryMock.Object.GetUsersByState(state);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetUsersByGenderAsync_ValidGender_ReturnsUsers()
        {
            // Arrange
            var gender = Gender.Male; // Replace with your desired gender
            var users = new List<User> { new User { Gender = gender }, new User { Gender = gender } };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByGenderAsync(gender)).ReturnsAsync(users);

            // Act
            var result = await userRepositoryMock.Object.GetUsersByGenderAsync(gender);

            // Assert
            Assert.Equal(users, result);
        }

        [Fact]
        public async Task GetUsersByGenderAsync_NonExistentGender_ReturnsEmptyList()
        {
            // Arrange
            var gender = Gender.Other; // Replace with a gender that is not in your test data
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsersByGenderAsync(gender)).ReturnsAsync(new List<User>());

            // Act
            var result = await userRepositoryMock.Object.GetUsersByGenderAsync(gender);

            // Assert
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

