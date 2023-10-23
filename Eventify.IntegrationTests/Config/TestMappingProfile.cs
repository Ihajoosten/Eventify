using Eventify.Application.Dto;

namespace Eventify.IntegrationTests.Config
{
    public class TestMappingProfile : Profile
    {
        public TestMappingProfile()
        {
            // Define mapping from Entity to DTO
            CreateMap<Event, EventDto>();
            CreateMap<User, UserDto>();
            CreateMap<Venue, VenueDto>();
            CreateMap<Session, SessionDto>();
            CreateMap<Speaker, SpeakerDto>();
            CreateMap<Sponsor, SponsorDto>();
            CreateMap<Registration, RegistrationDto>();
            CreateMap<AttendeeFeedback, AttendeeFeedbackDto>();
            CreateMap<Address, AddressDto>();


            // Define mapping from DTO to Entity
            CreateMap<EventDto, Event>();
            CreateMap<UserDto, User>();
            CreateMap<VenueDto, Venue>();
            CreateMap<SessionDto, Session>();
            CreateMap<SpeakerDto, Speaker>();
            CreateMap<SponsorDto, Sponsor>();
            CreateMap<RegistrationDto, Registration>();
            CreateMap<AttendeeFeedbackDto, AttendeeFeedback>();
            CreateMap<AddressDto, Address>();
        }
    }
}
