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
                ClientId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Kevin Alejandro Marin Hoyos",
                Contact = "3024173538",
                Email = "kevin@gmail.com",
                Password = "PasswordKevin123"
            },
            new Client
            {
                ClientId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "Usuario test 1",
                Contact = "3114044909",
                Email = "test1@gmail.com",
                Password = "PasswordTest23"
            },
            new Client
            {
                ClientId = new Guid("1eec8d12-16e4-42b5-9fc1-74d13d3ec77e"),
                Name = "Luis Fernando Pérez",
                Contact = "3123006578",
                Email = "luis.perez@gmail.com",
                Password = "PasswordLuis456"
            },
            new Client
            {
                ClientId = new Guid("4cb28e90-9c1f-4b9a-816d-f4b9c8f9a7d1"),
                Name = "Carolina Rodríguez",
                Contact = "3205004897",
                Email = "caro.rodriguez@gmail.com",
                Password = "PasswordCaro789"
            },
            new Client
            {
                ClientId = new Guid("9e8a2b94-d84f-4a73-9f6d-8f9e0c0d6b14"),
                Name = "Javier Mendoza",
                Contact = "3196001234",
                Email = "javier.m@gmail.com",
                Password = "PasswordJavier321"
            }
        );
    }
}