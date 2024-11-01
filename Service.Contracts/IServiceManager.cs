namespace Service.Contracts;

public interface IServiceManager
{
    IClientService ClientService { get; }
    IBookingService BookingService { get; }
    IServiceService ServiceService { get; }
    IBookingServiceService BookingServiceService { get; }
}