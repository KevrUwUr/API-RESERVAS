using System.Data.SqlTypes;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Booking;

namespace Project.Presentation.Controllers;

[Route("api/bookings")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IServiceManager _service;
    public BookingController(IServiceManager service) => _service = service;

    [HttpGet ( Name = "BookingsFiltered")]
    [Authorize]
    public IActionResult GetBookingsFiltered(Guid? clientId, Guid? serviceId, DateTime? sDate, DateTime? eDate)
    {
        var bookings = _service.BookingService.GetBookingsFiltered(clientId, serviceId, sDate, eDate, trackChanges: false);
        return Ok(bookings);
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult CreateBooking([FromBody] BookingForCreationDto booking)
    {
        if (booking is null)
            return BadRequest("El objeto BookingForCreationDto es nulo.");

        ModelState.ClearValidationState(nameof(BookingForCreationDto));
        if (!TryValidateModel(booking))
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return UnprocessableEntity(new { Mensaje = "Datos inválidos", Errores = errors });
        }

        var createdBooking = _service.BookingService.CreateBooking(booking);
        return Ok(createdBooking); 
    }
    
    [HttpDelete("{bookingId:guid}")]
    [Authorize]
    public IActionResult DeleteBooking(Guid bookingId)
    {
        _service.BookingService.DeleteBooking(bookingId, trackChanges: 
            false);
        return NoContent();
    }
    
    [HttpPut("{bookingId:guid}")]
    // [Authorize]
    public IActionResult UpdateBooking(Guid bookingId, [FromBody] BookingForUpdateDto booking)
    {
        if (booking is null)
            return BadRequest("BookingForUpdateDto object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.BookingService.UpdateBooking(bookingId, booking, trackChanges: true);
        return NoContent();
    }

}