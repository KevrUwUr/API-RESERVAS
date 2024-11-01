using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasData(
            new Client
            {
                ClientId = new Guid("ee0e166f-501a-4a8e-a2c5-a1b508c2bd55"),
                Name = "Kevin Alejandro Marin Hoyos",
                Contact = "3024173538",
                Email = "kevin@gmail.com",
                Password = "PasswordKevin123"
            },
            new Client
            {
                ClientId = new Guid("c2132a7f-fc83-4c61-ab45-1214950ac542"),
                Name = "Usuario test 1",
                Contact = "3114044909",
                Email = "test1@gmail.com",
                Password = "PasswordTest23"
            },
            new Client
            {
                ClientId = new Guid("16e058cf-35a2-44bf-8512-4657406404a2"),
                Name = "Luis Fernando Pérez",
                Contact = "3123006578",
                Email = "luis.perez@gmail.com",
                Password = "PasswordLuis456"
            },
            new Client
            {
                ClientId = new Guid("5cabe610-a9eb-4cc4-b82a-95fecdad0d34"),
                Name = "Carolina Rodríguez",
                Contact = "3205004897",
                Email = "caro.rodriguez@gmail.com",
                Password = "PasswordCaro789"
            },
            new Client
            {
                ClientId = new Guid("fef7720a-a4df-4c07-85a3-42c1e19ceda6"),
                Name = "Javier Mendoza",
                Contact = "3196001234",
                Email = "javier.m@gmail.com",
                Password = "PasswordJavier321"
            }
        );
    }
}