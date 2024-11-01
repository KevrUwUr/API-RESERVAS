namespace Entities.Exceptions.Booking;

public sealed class BookingNotFoundException : NotFoundException
{
    public BookingNotFoundException()
        : base("No bookings matching the specified parameters were found in the database.")
    {
    }
}