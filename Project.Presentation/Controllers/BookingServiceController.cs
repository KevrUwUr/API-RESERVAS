using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.BookingService;

namespace Project.Presentation.Controllers;

[Route("api/bookingsService")]
[ApiController]
public class BookingServiceController : ControllerBase
{
    private readonly IServiceManager _service;
    public BookingServiceController(IServiceManager service) => _service = service;
    
    [HttpPost]
    public IActionResult CreateBookingService([FromBody] BookingServiceForCreationDto bookingService)
    {
        if (bookingService is null)
            return BadRequest("BookingServiceForCreation object is null");
    
        var createdBookingService = _service.BookingServiceService.CreateBookingService(bookingService);
    
        return CreatedAtAction(nameof(CreateBookingService), new { id = createdBookingService.BookingServiceId }, createdBookingService);
    }

}