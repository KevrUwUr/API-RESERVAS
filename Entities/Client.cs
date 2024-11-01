using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Client
{
    [Column("ClientId")]
    public Guid ClientId { get; set; }

    [Required(ErrorMessage = "Client name is a required field.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Client contact is a required field.")]
    [StringLength(15, ErrorMessage = "Contact cannot exceed 15 characters.")]
    public string? Contact { get; set; }

    [Required(ErrorMessage = "Client email is a required field.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Client password is a required field.")]
    [StringLength(50, ErrorMessage = "Password cannot exceed 50 characters.")]
    public string? Password { get; set; }

    public ICollection<Booking>? Bookings { get; set; }
}