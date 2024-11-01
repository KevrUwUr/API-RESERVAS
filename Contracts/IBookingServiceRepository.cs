using Entities;

namespace Contracts;

public interface IBookingServiceRepository
{
    void CreateBookingService (BookingService bookingService);
    void DeleteBookingServicesByBookingId(Guid bookingId);

}