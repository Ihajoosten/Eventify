namespace Eventify.Application.Interfaces.Dto
{
    public interface IAddressDto
    {
        string Country { get; set; }
        string State { get; set; }
        string City { get; set; }
        string Street { get; set; }
        string ZipCode { get; set; }
    }
}
