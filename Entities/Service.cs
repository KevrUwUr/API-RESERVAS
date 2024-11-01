using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Service
{
    [Column("ServiceId")]
    public Guid ServiceId { get; set; }

    [Required(ErrorMessage = "Service name is a required field.")]
    [StringLength(100, ErrorMessage = "Service name cannot exceed 100 characters.")]
    public string? Name { get; set; }

    public ICollection<BookingService>? BookingsServices { get; set; }
}