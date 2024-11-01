using Shared.DataTransferObjects.BookingService;

namespace Service.Contracts;

public interface IBookingServiceService
{
    BookingServiceDto CreateBookingService(BookingServiceForCreationDto bookingService);
}