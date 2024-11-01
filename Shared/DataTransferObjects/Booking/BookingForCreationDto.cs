using System;
using System.Collections.Generic;
using Shared.DataTransferObjects.BookingService;

namespace Shared.DataTransferObjects.Booking
{
    public record BookingForCreationDto(
        DateTime StartDate,
        DateTime EndDate,
        Guid ClientId,
        IEnumerable<BookingServiceForCreationDto> BookingServices
    );
}
