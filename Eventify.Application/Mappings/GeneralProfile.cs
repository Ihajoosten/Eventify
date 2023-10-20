using AutoMapper;
using Eventify.Application.Dto;
using Eventify.Domain.Entities;

namespace Eventify.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Venue, VenueDto>();
            CreateMap<Event, EventDto>();
            CreateMap<Speaker, SpeakerDto>();
            CreateMap<Session, SessionDto>();
            CreateMap<Sponsor, SponsorDto>();
            CreateMap<Registration, RegistrationDto>();
            CreateMap<AttendeeFeedback, AttendeeFeedbackDto>();
        }
    }
}
