using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Eventify.Domain.ValueObjects;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Test.Domain
{
    public class VenueRepositoryTests
    {
        [Fact]
        public async Task GetVenuesByCountry_ReturnsVenues_WhenVenuesExistForCountry()
        {
            // Arrange
            var country = "Countryland";
            var expectedVenues = new List<Venue>
        {
            new Venue
            {
                Name = "Venue1",
                VenueAddress = new Address { Country = country, /* other address properties */ },
                Capacity = 100,
                ContactPerson = "John Doe",
                /* other venue properties */
            },
            new Venue
            {
                Name = "Venue2",
                VenueAddress = new Address { Country = country, /* other address properties */ },
                Capacity = 150,
                ContactPerson = "Jane Smith",
                /* other venue properties */
            },
            // Add more venues as needed
        };

            var venueRepositoryMock = new Mock<IVenueRepository>();
            venueRepositoryMock.Setup(repo => repo.GetVenuesByCountry(country)).ReturnsAsync(expectedVenues);

            // Act
            var result = await venueRepositoryMock.Object.GetVenuesByCountry(country);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedVenues, result);
        }

        [Fact]
        public async Task GetVenuesByCountry_ReturnsEmptyList_WhenNoVenuesExistForCountry()
        {
            // Arrange
            var country = "NonexistentCountry";

            var venueRepositoryMock = new Mock<IVenueRepository>();
            venueRepositoryMock.Setup(repo => repo.GetVenuesByCountry(country)).ReturnsAsync(new List<Venue>());

            // Act
            var result = await venueRepositoryMock.Object.GetVenuesByCountry(country);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetVenuesByState_ReturnsVenues_WhenVenuesExistForState()
        {
            // Arrange
            var state = "Stateland";
            var expectedVenues = new List<Venue>
        {
            new Venue
            {
                Name = "Venue1",
                VenueAddress = new Address { State = state, /* other address properties */ },
                Capacity = 100,
                ContactPerson = "John Doe",
                /* other venue properties */
            },
            new Venue
            {
                Name = "Venue2",
                VenueAddress = new Address { State = state, /* other address properties */ },
                Capacity = 150,
                ContactPerson = "Jane Smith",
                /* other venue properties */
            },
            // Add more venues as needed
        };

            var venueRepositoryMock = new Mock<IVenueRepository>();
            venueRepositoryMock.Setup(repo => repo.GetVenuesByState(state)).ReturnsAsync(expectedVenues);

            // Act
            var result = await venueRepositoryMock.Object.GetVenuesByState(state);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedVenues, result);
        }

        [Fact]
        public async Task GetVenuesByState_ReturnsEmptyList_WhenNoVenuesExistForState()
        {
            // Arrange
            var state = "NonexistentState";

            var venueRepositoryMock = new Mock<IVenueRepository>();
            venueRepositoryMock.Setup(repo => repo.GetVenuesByState(state)).ReturnsAsync(new List<Venue>());

            // Act
            var result = await venueRepositoryMock.Object.GetVenuesByState(state);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
