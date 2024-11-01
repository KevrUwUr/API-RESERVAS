using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BookingServiceConfiguration : IEntityTypeConfiguration<BookingService>
{
    public void Configure(EntityTypeBuilder<BookingService> builder)
    {
        builder.HasData(
            // Reservación 1 con 3 servicios
            new BookingService
            {
                BookingServiceId = new Guid("0a1a0c8f-bb54-4f1a-9338-f5d1c1e5a601"),
                BookingId = new Guid("d9388df8-4c1e-4d8f-85d8-742bb3d3befe"),
                ServiceId = new Guid("98dc7f61-96b1-489f-8500-6101870b0549") // Habitación Deluxe
            },
            new BookingService
            {
                BookingServiceId = new Guid("0b2b0d8e-bc44-4f1a-9448-f6e2d2e6b702"),
                BookingId = new Guid("d9388df8-4c1e-4d8f-85d8-742bb3d3befe"),
                ServiceId = new Guid("70144abe-40a7-46cc-bfab-fa062b660168") // Servicio de Transporte al Aeropuerto
            },
            new BookingService
            {
                BookingServiceId = new Guid("0c3c0e7d-ca34-4f1a-9558-f7f3e3e7c803"),
                BookingId = new Guid("d9388df8-4c1e-4d8f-85d8-742bb3d3befe"),
                ServiceId = new Guid("ea349c4f-694e-4a0c-b05e-cb90e23824cf") // Gimnasio y Piscina
            },

            // Reservación 2 con 2 servicios
            new BookingService
            {
                BookingServiceId = new Guid("1a2a0f8d-db24-4f1a-9668-f8e4e4e8d904"),
                BookingId = new Guid("b27f97c6-3af8-4f15-8414-7e3cb3e4ff15"),
                ServiceId = new Guid("98dc7f61-96b1-489f-8500-6101870b0549") // Habitación Deluxe
            },
            new BookingService
            {
                BookingServiceId = new Guid("1b3b1e7c-ec14-4f1a-9778-f9f5f5f9ea05"),
                BookingId = new Guid("b27f97c6-3af8-4f15-8414-7e3cb3e4ff15"),
                ServiceId = new Guid("70144abe-40a7-46cc-bfab-fa062b660168") // Servicio de Transporte al Aeropuerto
            },

            // Reservación 3 con 3 servicios
            new BookingService
            {
                BookingServiceId = new Guid("2a3a1f8b-fc04-4f1a-9888-fa0606faeb06"),
                BookingId = new Guid("8f3f7af9-345b-4a1f-9e4d-d68b2a81267f"),
                ServiceId = new Guid("96e0c514-7682-4bfe-afb2-766354ef5fbd") // Habitación Mediana
            },
            new BookingService
            {
                BookingServiceId = new Guid("2b4b2e7a-0c14-4f1a-9998-fb1717fbfb07"),
                BookingId = new Guid("8f3f7af9-345b-4a1f-9e4d-d68b2a81267f"),
                ServiceId = new Guid("70144abe-40a7-46cc-bfab-fa062b660168") // Servicio de Transporte al Aeropuerto
            },
            new BookingService
            {
                BookingServiceId = new Guid("2c5c3e79-1d24-4f1a-aaa8-fc2828fcfc08"),
                BookingId = new Guid("8f3f7af9-345b-4a1f-9e4d-d68b2a81267f"),
                ServiceId = new Guid("70144abe-40a7-46cc-bfab-fa062b660168") // Servicio de Transporte al Aeropuerto
            },

            // Reservación 4 con 2 servicios
            new BookingService
            {
                BookingServiceId = new Guid("3a4a2f7a-2e34-4f1a-bbb8-fd3939fdfd09"),
                BookingId = new Guid("e3db7602-54d4-42f3-93c8-d4f3de5cfb0d"),
                ServiceId = new Guid("96e0c514-7682-4bfe-afb2-766354ef5fbd") // Habitación Mediana
            },
            new BookingService
            {
                BookingServiceId = new Guid("3b5b3e6a-3f44-4f1a-ccc8-fe4a4afe0a10"),
                BookingId = new Guid("e3db7602-54d4-42f3-93c8-d4f3de5cfb0d"),
                ServiceId = new Guid("ea349c4f-694e-4a0c-b05e-cb90e23824cf") // Gimnasio y Piscina
            },

            // Reservación 5 con 3 servicios
            new BookingService
            {
                BookingServiceId = new Guid("4a5a3f69-4f54-4f1a-ddd8-ff5b5bff1b11"),
                BookingId = new Guid("4a9f1b42-1c9c-497d-97f7-7a1741a7c287"),
                ServiceId = new Guid("245f42aa-dea2-4001-bf4e-d0ad2712068a") // Habitación Pequeña
            },
            new BookingService
            {
                BookingServiceId = new Guid("4b6b4e58-5664-4f1a-eee8-005c5c0c2c12"),
                BookingId = new Guid("4a9f1b42-1c9c-497d-97f7-7a1741a7c287"),
                ServiceId = new Guid("70144abe-40a7-46cc-bfab-fa062b660168") // Servicio de Transporte al Aeropuerto
            },
            new BookingService
            {
                BookingServiceId = new Guid("4c7c5e47-6674-4f1a-fff8-116d6d1d3d13"),
                BookingId = new Guid("4a9f1b42-1c9c-497d-97f7-7a1741a7c287"),
                ServiceId = new Guid("ea349c4f-694e-4a0c-b05e-cb90e23824cf") // Gimnasio y Piscina
            }
        );
    }
}
