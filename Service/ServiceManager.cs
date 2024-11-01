using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IClientService> _clientService;
    private readonly Lazy<IBookingService> _bookingService;
    private readonly Lazy<IServiceService> _serviceService;
    private readonly Lazy<IBookingServiceService> _bookingServiceService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper)
    {
        _clientService = new Lazy<IClientService>(() => new
            ClientService(repositoryManager, logger, mapper));
        _bookingService = new Lazy<IBookingService>(() => new
            BookingService(repositoryManager, logger, mapper));
        _serviceService = new Lazy<IServiceService>(() => new
            ServiceService(repositoryManager, logger, mapper));
        _bookingServiceService = new Lazy<IBookingServiceService>(() => new
            BookingServiceService(repositoryManager, logger, mapper));
    }

    public IClientService ClientService => _clientService.Value;
    public IBookingService BookingService => _bookingService.Value;
    public IServiceService ServiceService => _serviceService.Value;
    public IBookingServiceService BookingServiceService => _bookingServiceService.Value;
}