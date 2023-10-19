using Eventify.Application.Interfaces.Dto;

namespace Eventify.Application.Dto
{
    public class AddressDto : IAddressDto
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
    }
}
