using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<BookingService>? BookingServices { get; set; }
    }
