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
                ClientId = new Guid("ee0e166f-501a-4a8e-a2c5-a1b508c2bd55")
            },
            new Booking
            {
                BookingId = new Guid("b27f97c6-3af8-4f15-8414-7e3cb3e4ff15"),
                StartDate = new DateTime(2024, 12, 1),
                EndDate = new DateTime(2024, 12, 7),
                ClientId = new Guid("c2132a7f-fc83-4c61-ab45-1214950ac542")
            },
            new Booking
            {
                BookingId = new Guid("8f3f7af9-345b-4a1f-9e4d-d68b2a81267f"),
                StartDate = new DateTime(2025, 1, 5),
                EndDate = new DateTime(2025, 1, 12),
                ClientId = new Guid("16e058cf-35a2-44bf-8512-4657406404a2")
            },
            new Booking
            {
                BookingId = new Guid("e3db7602-54d4-42f3-93c8-d4f3de5cfb0d"),
                StartDate = new DateTime(2025, 2, 14),
                EndDate = new DateTime(2025, 2, 21),
                ClientId = new Guid("5cabe610-a9eb-4cc4-b82a-95fecdad0d34")
            },
            new Booking
            {
                BookingId = new Guid("4a9f1b42-1c9c-497d-97f7-7a1741a7c287"),
                StartDate = new DateTime(2025, 3, 10),
                EndDate = new DateTime(2025, 3, 17),
                ClientId = new Guid("fef7720a-a4df-4c07-85a3-42c1e19ceda6")
            }
        );
    }
}