using System.Data.SqlTypes;
using Entities;
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
    public IActionResult GetBookingsFiltered(Guid? clientId, Guid? serviceId, DateTime? sDate, DateTime? eDate)
    {
        var bookings = _service.BookingService.GetBookingsFiltered(clientId, serviceId, sDate, eDate, trackChanges: false);
        return Ok(bookings);
    }
    
    [HttpPost]
    public IActionResult CreateBooking([FromBody] BookingForCreationDto booking)
    {
        if (booking is null)
            return BadRequest("BookingForCreation object is null");
        ModelState.ClearValidationState(nameof(Booking));
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdBooking = _service.BookingService.CreateBooking(booking);
        return Ok(createdBooking); 
    }
    [HttpDelete("{bookingId:guid}")]
    public IActionResult DeleteBooking(Guid bookingId)
    {
        _service.BookingService.DeleteBooking(bookingId, trackChanges: 
            false);
        return NoContent();
    }
    
    [HttpPut("{bookingId:guid}")]
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