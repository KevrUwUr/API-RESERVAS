using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Repository.Configuration;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasData(
            new Booking
            {
                BookingId = new Guid("d9388df8-4c1e-4d8f-85d8-742bb3d3befe"),
                StartDate = new DateTime(2024, 11, 1),
                EndDate = new DateTime(2024, 11, 8),
                ClientId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            },
            new Booking
            {
                BookingId = new Guid("b27f97c6-3af8-4f15-8414-7e3cb3e4ff15"),
                StartDate = new DateTime(2024, 12, 1),
                EndDate = new DateTime(2024, 12, 7),
                ClientId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
            },
            new Booking
            {
                BookingId = new Guid("8f3f7af9-345b-4a1f-9e4d-d68b2a81267f"),
                StartDate = new DateTime(2025, 1, 5),
                EndDate = new DateTime(2025, 1, 12),
                ClientId = new Guid("1eec8d12-16e4-42b5-9fc1-74d13d3ec77e")
            },
            new Booking
            {
                BookingId = new Guid("e3db7602-54d4-42f3-93c8-d4f3de5cfb0d"),
                StartDate = new DateTime(2025, 2, 14),
                EndDate = new DateTime(2025, 2, 21),
                ClientId = new Guid("4cb28e90-9c1f-4b9a-816d-f4b9c8f9a7d1")
            },
            new Booking
            {
                BookingId = new Guid("4a9f1b42-1c9c-497d-97f7-7a1741a7c287"),
                StartDate = new DateTime(2025, 3, 10),
                EndDate = new DateTime(2025, 3, 17),
                ClientId = new Guid("9e8a2b94-d84f-4a73-9f6d-8f9e0c0d6b14")
            }
        );
    }
}