using Shared.DataTransferObjects.Booking;

namespace Service.Contracts;

public interface IBookingService
{
    IEnumerable<BookingDto> GetBookingsFiltered(Guid? clientId, Guid? serviceId, DateTime? sDate, DateTime? eDate, bool trackChanges);
    BookingDto CreateBooking(BookingForCreationDto booking);
    
    void DeleteBooking(Guid bookingId, bool trackChanges);
    void UpdateBooking(Guid bookingId, 
        BookingForUpdateDto bookingForUpdate, bool trackChanges);

}