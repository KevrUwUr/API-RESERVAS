using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions.Booking;
using Entities.Exceptions.Client;
using Entities.Exceptions.Service;
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
    {
        var dto = _mapper.Map<BookingDto>(booking);
        return dto;
    }).ToList();
    
    return bookingDtos;
}
        public BookingDto CreateBooking(BookingForCreationDto booking)
        {
            // Validates that the ClientId exists
            var clientExists = _repository.Client.GetClient(booking.ClientId, trackChanges: true);
            if (clientExists is null)
                throw new ClientNotFoundException(booking.ClientId);

            // Creates a list to store missing service IDs
            var missingServiceIds = new List<Guid>();

            // Validates each ServiceId in BookingServices
            foreach (var bookingService in booking.BookingServices)
            {
                var serviceExists = _repository.Service.GetService(bookingService.ServiceId, trackChanges: true);
                if (serviceExists is null)
                    missingServiceIds.Add(bookingService.ServiceId);
            }

            // Throws an exception if any ServiceId is invalid
            if (missingServiceIds.Any())
                throw new ServiceCollectionNotFoundException($"The following Service IDs do not exist: {string.Join(", ", missingServiceIds)}");
            // Map and save the booking
            var bookingEntity = _mapper.Map<Entities.Booking>(booking);
            _repository.Booking.CreateBooking(bookingEntity);
            _repository.Save();

            // Adds each BookingService entity for the created booking
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
            return _mapper.Map<BookingDto>(createdBookingWithServices);
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
            // Obtener la entidad con tracking habilitado
            var bookingEntity = _repository.Booking.GetById(bookingId, trackChanges: true);
            if (bookingEntity is null)
                throw new BookingNotFoundException();

            // Mapear los datos de actualización
            _mapper.Map(bookingForUpdate, bookingEntity);

            // Guardar la actualización de la entidad principal antes de modificar las relaciones
            _repository.Save();

            // Filtrar los servicios a remover y a agregar
            var servicesToRemove = bookingEntity.BookingsServices
                .Where(bs => !bookingForUpdate.BookingServices.Any(dto => dto.ServiceId == bs.ServiceId))
                .ToList();

            var servicesToAdd = bookingForUpdate.BookingServices
                .Where(dto => !bookingEntity.BookingsServices.Any(bs => bs.ServiceId == dto.ServiceId))
                .Select(dto => new Entities.BookingService
                {
                    BookingId = bookingId,
                    ServiceId = dto.ServiceId,
                    BookingServiceId = Guid.NewGuid()
                }).ToList();

            // Eliminar los servicios que ya no son necesarios
            foreach (var service in servicesToRemove)
                bookingEntity.BookingsServices.Remove(service);

            // Agregar los nuevos servicios
            foreach (var service in servicesToAdd)
                bookingEntity.BookingsServices.Add(service);

            // Guardar los cambios finales
            _repository.Save();
        }
    }
}