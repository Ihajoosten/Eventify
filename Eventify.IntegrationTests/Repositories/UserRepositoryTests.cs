using Eventify.Domain.Entities;
using Eventify.IntegrationTests.Config.Fixtures;
using System.Security.Cryptography.Xml;

namespace Eventify.IntegrationTests.Repositories
{
    [Collection("InfraLayerCollection")]
    public class UserRepositoryTests : IClassFixture<InfraLayerFixture>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserRepository> _logger;
        private readonly IUserRepository _userRepository;
        private readonly InfraLayerFixture _fixture;

        public UserRepositoryTests(InfraLayerFixture fixture)
        {
            _fixture = fixture;

            _unitOfWork = new TestUnitOfWork(_fixture.Context);
            _logger = new Mock<ILogger<UserRepository>>().Object;
            _userRepository = new UserRepository(_unitOfWork, _logger);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 1)]
        public async Task GetUsersByGender_ReturnsUsersForGender(int enumIndex, int expectedAmount)
        {
            var users = await _userRepository.GetUsersByGenderAsync(Enum.GetValues<Gender>()[enumIndex]);

            if (users!.Any())
            {
                Assert.Equal(expectedAmount, users.Count());
            }
            else { Assert.Empty(users); }
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(0, 2)]
        public async Task GetUsersByRole_ReturnsUsersForRole(int enumIndex, int expectedAmount)
        {
            var users = await _userRepository.GetUsersByRoleAsync(Enum.GetValues<UserRole>()[enumIndex]);

            if (users!.Any())
            {
                Assert.Equal(expectedAmount, users.Count());
            }
            else { Assert.Empty(users); }
        }

        [Theory]
        [InlineData("UserState3", 0)]
        [InlineData("State2", 2)]
        [InlineData("State1", 1)]
        public async Task GetUsersByState_ReturnsUsersForState(string state, int expectedAmount)
        {
            var users = await _userRepository.GetUsersByState(state);

            if (users!.Any())
            {
                Assert.Equal(expectedAmount, users.Count());
            }
            else { Assert.Empty(users); }
        }

        [Theory]
        [InlineData("UserCountry3", 0)]
        [InlineData("Country2", 2)]
        [InlineData("Country1", 1)]
        public async Task GetUsersByCountry_ReturnsUsersForCountry(string country, int expectedAmount)
        {
            var users = await _userRepository.GetUsersByCountry(country);

            if (users!.Any())
            {
                Assert.Equal(expectedAmount, users.Count());
            }
            else { Assert.Empty(users); }
        }

        [Theory]
        [InlineData("InvalidUsername3" , null)] // invalid username
        [InlineData("ValidUsername1", "user1@example.com")]  
        [InlineData("ValidUsername2", "user2@example.com")]  
        public async Task GetUserByUsername_ReturnsUserForUsername(string username, string? expectedEmail)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user != null)
            {
                Assert.Equal(expectedEmail, user.Email);
            }
            else { Assert.Null(user); }
        }

        [Theory]
        [InlineData("InvalidEmail1", null)] // invalid username
        [InlineData("user1@example.com", "ValidUsername1")]
        [InlineData("user2@example.com", "ValidUsername2")]
        public async Task GetUserByEmail_ReturnsUserForEmail(string email, string? expectedUsername)
        {
            var user = await _userRepository.GetUserByUsernameAsync(email);

            if (user != null)
            {
                Assert.Equal(expectedUsername, user.Username);
            }
            else { Assert.Null(user); }
        }
    }
}
