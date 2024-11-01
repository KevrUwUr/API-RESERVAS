namespace Contracts;

public interface IRepositoryManager
{
    IClientRepository Client { get; }
    IServiceRepository Service { get; } 
    IBookingRepository Booking { get; } 
    IBookingServiceRepository BookingService { get; } 
    void Save();
}
