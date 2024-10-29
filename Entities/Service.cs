using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Service
{
    [Column ("ServiceId")]
    public Guid ServiceId { get; set; }
    [Required (ErrorMessage = "Service Name is a required field")]
    public string? Name { get; set; }
    public ICollection<BookingService>? BookingsServices { get; set; }

}