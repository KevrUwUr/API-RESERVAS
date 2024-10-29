using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class BookingService
{
    [Column("BookingServiceId")]
    public Guid BookingServiceId { get; set; }
    [ForeignKey(nameof(Booking))]
    public Guid BookingId { get; set; }
    public Booking? Booking { get; set; }
    [ForeignKey(nameof(Service))]
    public Guid ServiceId { get; set; }
    public Service? Service { get; set; }
}