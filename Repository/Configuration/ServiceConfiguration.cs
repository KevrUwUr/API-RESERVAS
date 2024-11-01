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
                ServiceId = new Guid("98dc7f61-96b1-489f-8500-6101870b0549"),
                Name = "Habitación Deluxe"
            },
            new Service
            {
                ServiceId = new Guid("96e0c514-7682-4bfe-afb2-766354ef5fbd"),
                Name = "Habitación Mediana"
            },
            new Service
            {
                ServiceId = new Guid("245f42aa-dea2-4001-bf4e-d0ad2712068a"),
                Name = "Habitación Pequeña"
            },
            new Service
            {
                ServiceId = new Guid("70144abe-40a7-46cc-bfab-fa062b660168"),
                Name = "Servicio de Transporte al Aeropuerto"
            },
            new Service
            {
                ServiceId = new Guid("ea349c4f-694e-4a0c-b05e-cb90e23824cf"),
                Name = "Gimnasio y Piscina"
            }
        );
    }
}