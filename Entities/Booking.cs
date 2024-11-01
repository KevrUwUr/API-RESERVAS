using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Validations;

namespace Entities;

public class Booking
{
    [Column("BookingId")]
    public Guid BookingId { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Start date is a required field.")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is a required field.")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    [DateGreaterThan(nameof(StartDate), ErrorMessage = "End date must be later than start date.")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Client ID is a required field.")]
    [ForeignKey(nameof(Client))]
    public Guid ClientId { get; set; }

    public Client? Client { get; set; }

    public ICollection<BookingService>? BookingsServices { get; set; }
}