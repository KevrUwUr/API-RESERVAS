using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions.Booking;
using Service.Contracts;
using Shared.DataTransferObjects.Booking;

namespace Service
{
    internal sealed class BookingService : IBookingService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BookingService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        
        public IEnumerable<BookingDto> GetBookingsFiltered(Guid? clientId, Guid? serviceId, DateTime? sDate, DateTime? eDate, bool trackChanges)
        {
            var bookings = _repository.Booking.GetAllBookingsFiltered(clientId, serviceId, sDate, eDate, trackChanges);
            
            if (!bookings.Any())
                throw new BookingNotFoundException();

            var bookingDtos = bookings.Select(booking => 
                _mapper.Map<BookingDto>(booking)).ToList();
                
            return bookingDtos;
        }
        
        public BookingDto CreateBooking(BookingForCreationDto booking)
        {
            var bookingEntity = _mapper.Map<Entities.Booking>(booking);
    
            _repository.Booking.CreateBooking(bookingEntity);
            _repository.Save();

            
            foreach (var bookingServiceDto in booking.BookingServices)
            {
                var bookingServiceEntity = new Entities.BookingService
                {
                    BookingId = bookingEntity.BookingId,
                    ServiceId = bookingServiceDto.ServiceId,
                    BookingServiceId = Guid.NewGuid() 
                };
        
                _repository.BookingService.CreateBookingService(bookingServiceEntity);
            }

            _repository.Save();

            
            var createdBookingWithServices = _repository.Booking.GetById(bookingEntity.BookingId, trackChanges: false);
    
            
            var bookingToReturn = _mapper.Map<BookingDto>(createdBookingWithServices);
            return bookingToReturn;
        }
        public void DeleteBooking(Guid bookingId, bool trackChanges)
        {
            var booking = _repository.Booking.GetById(bookingId, trackChanges);
            if (booking is null)
                throw new BookingNotFoundException();
            
            _repository.Booking.DeleteBooking(booking);
            _repository.Save();
        }

        public void UpdateBooking(Guid bookingId, BookingForUpdateDto bookingForUpdate, bool trackChanges)
        {
            var bookingEntity = _repository.Booking.GetById(bookingId, trackChanges);
            if (bookingEntity is null)
                throw new BookingNotFoundException();

            _mapper.Map(bookingForUpdate, bookingEntity);
    
            
            var servicesToRemove = bookingEntity.BookingsServices
                .Where(bs => !bookingForUpdate.BookingServices.Any(dto => dto.ServiceId == bs.ServiceId))
                .ToList();

            foreach (var service in servicesToRemove)
                bookingEntity.BookingsServices.Remove(service);

            
            var servicesToAdd = bookingForUpdate.BookingServices
                .Where(dto => !bookingEntity.BookingsServices.Any(bs => bs.ServiceId == dto.ServiceId))
                .Select(dto => new Entities.BookingService
                {
                    BookingId = bookingId,
                    ServiceId = dto.ServiceId,
                    BookingServiceId = Guid.NewGuid()
                }).ToList();

            foreach (var service in servicesToAdd)
                bookingEntity.BookingsServices.Add(service);

            _repository.Save();
        }




    }
}