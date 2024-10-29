
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Booking
{
    [Column("BookingId")]
    public Guid BookingId {
        get;
        set;
    }
    [Required(ErrorMessage = "Start date is a required field.")]
    public DateTime? StartDate { get; set; }
    [Required(ErrorMessage = "End date is a required field.")]
    public DateTime? EndDate { get; set; }
    [ForeignKey(nameof(Client))]
    public Guid ClientId { get; set; }
    public Client? Client { get; set; }
    
    public ICollection<BookingService>? BookingsServices { get; set; }

}