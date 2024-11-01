using Entities;

namespace Contracts;

public interface IBookingRepository
{
    IEnumerable<Booking> GetAllBookingsFiltered(Guid? clientId, Guid? serviceId, DateTime? sDate, DateTime? eDate, bool trackChanges);
    Booking GetById(Guid bookingId, bool trackChanges); 
    void CreateBooking(Booking booking);
    void DeleteBooking(Booking booking);
    void UpdateBooking(Booking booking); 

}
