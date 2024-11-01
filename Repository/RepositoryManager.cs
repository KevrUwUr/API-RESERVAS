using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IClientRepository> _clientRepository;
    private readonly Lazy<IBookingRepository> _bookingRepository;
    private readonly Lazy<IServiceRepository> _serviceRepository;
    private readonly Lazy<IBookingServiceRepository> _bookingServiceRepository;
    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _clientRepository = new Lazy<IClientRepository>(() => new
            ClientRepository(repositoryContext));
        _bookingRepository = new Lazy<IBookingRepository>(() => new
            BookingRepository(repositoryContext));
        _serviceRepository = new Lazy<IServiceRepository>(() => new
            ServiceRepository(repositoryContext));
        _bookingServiceRepository = new Lazy<IBookingServiceRepository>(() => new
            BookingServiceRepository(repositoryContext));
        
    }
    public IClientRepository Client => _clientRepository.Value;
    public IBookingRepository Booking => _bookingRepository.Value;
    public IServiceRepository Service => _serviceRepository.Value;
    public IBookingServiceRepository BookingService => _bookingServiceRepository.Value;
    public void Save() => _repositoryContext.SaveChanges();
}