using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new BookingServiceConfiguration());
        }

        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<BookingService>? BookingServices { get; set; }
    }
