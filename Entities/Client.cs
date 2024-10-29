using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Client
{
    [Column("ClientId")] public Guid ClientId { get; set; }
    [Required(ErrorMessage = "Client name is a required field.")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Client contact is a required field.")]
    public string? Contact { get; set; }
    [Required(ErrorMessage = "Client email is a required field.")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Client password is a required field.")]
    public string? Password { get; set; }
    
    public ICollection<Booking>? Bookings { get; set; }
}