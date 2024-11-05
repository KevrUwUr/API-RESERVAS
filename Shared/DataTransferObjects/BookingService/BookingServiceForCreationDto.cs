using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.BookingService
{
    public record BookingServiceForCreationDto(
        
        [Required(ErrorMessage = "Service ID is a required field.")]
        Guid ServiceId
    );
}