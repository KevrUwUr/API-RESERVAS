using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities.Validations;
using Shared.DataTransferObjects.BookingService;

namespace Shared.DataTransferObjects.Booking
{
    public record BookingForCreationDto(
        
        [Required(ErrorMessage = "Start date is a required field.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        DateTime StartDate,

        [Required(ErrorMessage = "End date is a required field.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        [DateGreaterThan(nameof(StartDate), ErrorMessage = "End date must be later than start date.")]
        DateTime EndDate,

        [Required(ErrorMessage = "Client ID is a required field.")]
        Guid ClientId,

        [Required(ErrorMessage = "At least one service is required in the booking.")]
        IEnumerable<BookingServiceForCreationDto> BookingServices
    );
}