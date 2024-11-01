using Shared.DataTransferObjects.BookingService;

namespace Shared.DataTransferObjects.Booking{
    public record BookingForUpdateDto(
        DateTime StartDate,
        DateTime EndDate,
        Guid ClientId,
        IEnumerable<BookingServiceForUpdateDto> BookingServices
    );
}