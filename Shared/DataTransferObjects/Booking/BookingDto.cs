using Shared.DataTransferObjects.Service;

namespace Shared.DataTransferObjects.Booking
{
    public record BookingDto
    {
        public Guid BookingId { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public Guid ClientId { get; init; }
        public string ClientName { get; init; } 
        public List<ServiceDto> Services { get; init; }

        // Constructor sin parámetros
        public BookingDto() { }

        public BookingDto(Guid bookingId, DateTime startDate, DateTime endDate, Guid clientId, string clientName, List<ServiceDto> services)
        {
            BookingId = bookingId;
            StartDate = startDate;
            EndDate = endDate;
            ClientId = clientId;
            ClientName = clientName;
            Services = services;
        }
    }
}
