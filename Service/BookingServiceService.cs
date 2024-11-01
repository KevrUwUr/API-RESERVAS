using AutoMapper;
using Contracts;
using Entities;
using Service.Contracts;
using Shared.DataTransferObjects.BookingService;

internal sealed class BookingServiceService : IBookingServiceService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public BookingServiceService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    
    public BookingServiceDto CreateBookingService(BookingServiceForCreationDto bookingService)
    {
        var bookingServiceEntity = _mapper.Map<BookingService>(bookingService); 
        _repository.BookingService.CreateBookingService(bookingServiceEntity);
        _repository.Save();
        
        var bookingServiceToReturn = _mapper.Map<BookingServiceDto>(bookingServiceEntity);
        return bookingServiceToReturn;
    }
    
}