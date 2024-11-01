using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class BookingService
{
    [Column("BookingServiceId")]
    public Guid BookingServiceId { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Booking ID is a required field.")]
    [ForeignKey(nameof(Booking))]
    public Guid BookingId { get; set; }
    
    public Booking? Booking { get; set; }

    [Required(ErrorMessage = "Service ID is a required field.")]
    [ForeignKey(nameof(Service))]
    public Guid ServiceId { get; set; }
    
    public Service? Service { get; set; }
}