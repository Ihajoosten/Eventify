using AutoMapper;
using Eventify.Application.Commands.User;
using Eventify.Application.Dto;
using Eventify.Application.Handlers.Commands;
using Eventify.Application.Interfaces.Dto;
using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Domain.ValueObjects;
using Eventify.Test.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace Eventify.Test.Application
{
    public class UserCommandHandlerTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public UserCommandHandlerTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CreateUser_ShouldReturnValidDto()
        {
            // clear data
            _fixture.ClearData<User>();

            // Arrange
            var repositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<UserCommandHandler>>();
            var mapperMock = new Mock<IMapper>();

            var handler = new UserCommandHandler(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            var createCommand = new CreateUserCommand
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

            // Mock repository behavior
            var createdUser = new User
            {
                Id = Guid.NewGuid(),
                Username = "john_doe",
                Email = "john.doe@example.com",
                Password = "Password123",
                ConfirmPassword = "Password123",
                BirthDate = DateTime.Parse("1990-01-01"),
                UserAddress = new Address { Street = "123 Main St", City = "Cityville", Country = "Countryland", State = "state", ZipCode = "zipCode" },
            };

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<User>())).ReturnsAsync(createdUser);

            var address = new AddressDto()
            {
                Street = createdUser.UserAddress.Street,
                City = createdUser.UserAddress.City,
                Country = createdUser.UserAddress.Country,
                State = createdUser.UserAddress.State,
                ZipCode = createdUser.UserAddress.ZipCode
            };

            // Mock mapper behavior
            var expectedDto = new UserDto
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                Email = createdUser.Email,
                BirthDate = createdUser.BirthDate,
                UserAddress = address
            };

            mapperMock.Setup(mapper => mapper.Map<IUserDto>(It.IsAny<User>())).Returns(expectedDto);

            // Act
            var result = await handler.Handle(createCommand);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserDto>(result);

            // Additional asserts for property matching
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Username, result.Username);

            // clean database
            _fixture.ClearData<User>();
        }

        [Fact]
        public async Task UpdateUser_ShouldReturnValidDto()
        {
            // clear data
            _fixture.ClearData<User>();

            // Arrange
            var repositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<UserCommandHandler>>();
            var mapperMock = new Mock<IMapper>();

            var handler = new UserCommandHandler(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            // Mock repository behavior
            var createdUser = new User
            {
                Id = Guid.NewGuid(),
                Username = "john_doe",
                Email = "john.doe@example.com",
                Password = "Password123",
                FirstName = "John",
                LastName = "Doe",
                ConfirmPassword = "Password123",
                BirthDate = DateTime.Parse("1990-01-01"),
                UserAddress = new Address { Street = "123 Main St", City = "Cityville", Country = "Countryland", State = "state", ZipCode = "zipCode" },
            };

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<User>())).ReturnsAsync(createdUser);

            var updateCommand = new UpdateUserCommand
            {
                Id = createdUser.Id,
                Username = "updatedUsername",
                Email = "updatedEmail",
                PhoneNumber = "updatedPhone",
                FirstName = "John",
                LastName = "Doe"
            };

            // Mock repository behavior
            var updatedUser = new User
            {
                Id = createdUser.Id,
                Username = "updatedUsername",
                Email = "updatedEmail",
                PhoneNumber = "updatedPhone",
                FirstName = "John",
                LastName = "Doe"
            };

            repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).ReturnsAsync(updatedUser);

            // Mock mapper behavior
            var expectedDto = new UserDto
            {
                Id = updatedUser.Id,
                Username = updatedUser.Username,
                Email = updatedUser.Email,
                PhoneNumber = updatedUser.PhoneNumber,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
            };

            mapperMock.Setup(mapper => mapper.Map<IUserDto>(It.IsAny<User>())).Returns(expectedDto);

            // Act
            var result = await handler.Handle(updateCommand);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserDto>(result);

            // Additional asserts for property matching
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Username, result.Username);
            Assert.Equal(expectedDto.Email, result.Email);
            Assert.Equal(expectedDto.FirstName, result.FirstName);
            Assert.Equal(expectedDto.LastName, result.LastName);

            // clean database
            _fixture.ClearData<User>();
        }

        [Fact]
        public async Task DeleteUser_ShouldReturnValidDto()
        {
            // clear data
            _fixture.ClearData<User>();

            // Arrange
            var repositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<UserCommandHandler>>();
            var mapperMock = new Mock<IMapper>();
            var handler = new UserCommandHandler(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            // Mock repository behavior
            var createdUser = new User
            {
                Id = Guid.NewGuid(),
                Username = "testuser",
                // Set other properties
            };

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<User>())).ReturnsAsync(createdUser);

            var deleteCommand = new DeleteUserCommand
            {
                Id = createdUser.Id
            };

            // Mock repository behavior
            var deletedUser = new User
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                // Set other properties
            };

            repositoryMock.Setup(repo => repo.RemoveAsync(It.IsAny<User>())).ReturnsAsync(deletedUser);

            // Mock mapper behavior
            var expectedDto = new UserDto
            {
                Id = deletedUser.Id,
                Username = deletedUser.Username,
                // Set other properties
            };

            mapperMock.Setup(mapper => mapper.Map<IUserDto>(It.IsAny<User>())).Returns(expectedDto);

            // Act
            var result = await handler.Handle(deleteCommand);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserDto>(result);

            // Additional asserts for property matching
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Username, result.Username);

            // clean database
            _fixture.ClearData<User>();
        }

        [Fact]
        public async Task ChangePassword_ShouldReturnValidDto()
        {
            // clear data
            _fixture.ClearData<User>();

            // Arrange
            var repositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<UserCommandHandler>>();
            var mapperMock = new Mock<IMapper>();
            var handler = new UserCommandHandler(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            // Mock repository behavior
            var createdUser = new User
            {
                Id = Guid.NewGuid(),
                Username = "testuser",
                // Set other properties
            };

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<User>())).ReturnsAsync(createdUser);

            var changePasswordCommand = new ChangePasswordCommand
            {
                Id = createdUser.Id,
                // Set command properties
            };

            // Mock repository behavior
            var updatedUser = new User
            {
                Id = createdUser.Id,
                Username = "testuser",
                // Set other properties
            };

            repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).ReturnsAsync(updatedUser);

            // Mock mapper behavior
            var expectedDto = new UserDto
            {
                Id = updatedUser.Id,
                Username = updatedUser.Username,
                // Set other properties
            };

            mapperMock.Setup(mapper => mapper.Map<IUserDto>(It.IsAny<User>())).Returns(expectedDto);

            // Act
            var result = await handler.Handle(changePasswordCommand);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserDto>(result);

            // Additional asserts for property matching
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Username, result.Username);

            // clean database
            _fixture.ClearData<User>();
        }

        [Fact]
        public async Task ChangeUserRole_ShouldReturnValidDto()
        {
            // clear data
            _fixture.ClearData<User>();

            // Arrange
            var repositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<UserCommandHandler>>();
            var mapperMock = new Mock<IMapper>();

            var handler = new UserCommandHandler(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            // Mock repository behavior
            var createdUser = new User
            {
                Id = Guid.NewGuid(),
                Username = "testuser",
                // Set other properties
            };

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<User>())).ReturnsAsync(createdUser);

            var changeUserRoleCommand = new ChangeUserRoleCommand
            {
                Id = createdUser.Id,
                // Set command properties
            };

            // Mock repository behavior
            var updatedUser = new User
            {
                Id = createdUser.Id,
                Username = "testuser",
                // Set other properties
            };

            repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).ReturnsAsync(updatedUser);

            // Mock mapper behavior
            var expectedDto = new UserDto
            {
                Id = updatedUser.Id,
                Username = updatedUser.Username,
                // Set other properties
            };

            mapperMock.Setup(mapper => mapper.Map<IUserDto>(It.IsAny<User>())).Returns(expectedDto);

            // Act
            var result = await handler.Handle(changeUserRoleCommand);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserDto>(result);

            // Additional asserts for property matching
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Username, result.Username);

            // clean database
            _fixture.ClearData<User>();
        }
    }
}
