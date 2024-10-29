using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasData(
            new Service
            {
                ServiceId = new Guid("d9388df8-4c1e-4d8f-85d8-742bb3d3befe"),
                Name = "Habitación Deluxe"
            },
            new Service
            {
                ServiceId = new Guid("b27f97c6-3af8-4f15-8414-7e3cb3e4ff15"),
                Name = "Desayuno Buffet"
            },
            new Service
            {
                ServiceId = new Guid("8f3f7af9-345b-4a1f-9e4d-d68b2a81267f"),
                Name = "Acceso al Spa"
            },
            new Service
            {
                ServiceId = new Guid("e3db7602-54d4-42f3-93c8-d4f3de5cfb0d"),
                Name = "Servicio de Transporte al Aeropuerto"
            },
            new Service
            {
                ServiceId = new Guid("4a9f1b42-1c9c-497d-97f7-7a1741a7c287"),
                Name = "Gimnasio y Piscina"
            }
        );
    }
}