using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingServices",
                columns: table => new
                {
                    BookingServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingServices", x => x.BookingServiceId);
                    table.ForeignKey(
                        name: "FK_BookingServices_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Contact", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("16e058cf-35a2-44bf-8512-4657406404a2"), "3123006578", "luis.perez@gmail.com", "Luis Fernando Pérez", "PasswordLuis456" },
                    { new Guid("5cabe610-a9eb-4cc4-b82a-95fecdad0d34"), "3205004897", "caro.rodriguez@gmail.com", "Carolina Rodríguez", "PasswordCaro789" },
                    { new Guid("c2132a7f-fc83-4c61-ab45-1214950ac542"), "3114044909", "test1@gmail.com", "Usuario test 1", "PasswordTest23" },
                    { new Guid("ee0e166f-501a-4a8e-a2c5-a1b508c2bd55"), "3024173538", "kevin@gmail.com", "Kevin Alejandro Marin Hoyos", "PasswordKevin123" },
                    { new Guid("fef7720a-a4df-4c07-85a3-42c1e19ceda6"), "3196001234", "javier.m@gmail.com", "Javier Mendoza", "PasswordJavier321" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Name" },
                values: new object[,]
                {
                    { new Guid("245f42aa-dea2-4001-bf4e-d0ad2712068a"), "Habitación Pequeña" },
                    { new Guid("70144abe-40a7-46cc-bfab-fa062b660168"), "Servicio de Transporte al Aeropuerto" },
                    { new Guid("96e0c514-7682-4bfe-afb2-766354ef5fbd"), "Habitación Mediana" },
                    { new Guid("98dc7f61-96b1-489f-8500-6101870b0549"), "Habitación Deluxe" },
                    { new Guid("ea349c4f-694e-4a0c-b05e-cb90e23824cf"), "Gimnasio y Piscina" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "ClientId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { new Guid("4a9f1b42-1c9c-497d-97f7-7a1741a7c287"), new Guid("fef7720a-a4df-4c07-85a3-42c1e19ceda6"), new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8f3f7af9-345b-4a1f-9e4d-d68b2a81267f"), new Guid("16e058cf-35a2-44bf-8512-4657406404a2"), new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b27f97c6-3af8-4f15-8414-7e3cb3e4ff15"), new Guid("c2132a7f-fc83-4c61-ab45-1214950ac542"), new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9388df8-4c1e-4d8f-85d8-742bb3d3befe"), new Guid("ee0e166f-501a-4a8e-a2c5-a1b508c2bd55"), new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3db7602-54d4-42f3-93c8-d4f3de5cfb0d"), new Guid("5cabe610-a9eb-4cc4-b82a-95fecdad0d34"), new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "BookingServices",
                columns: new[] { "BookingServiceId", "BookingId", "ServiceId" },
                values: new object[,]
                {
                    { new Guid("0a1a0c8f-bb54-4f1a-9338-f5d1c1e5a601"), new Guid("d9388df8-4c1e-4d8f-85d8-742bb3d3befe"), new Guid("98dc7f61-96b1-489f-8500-6101870b0549") },
                    { new Guid("0b2b0d8e-bc44-4f1a-9448-f6e2d2e6b702"), new Guid("d9388df8-4c1e-4d8f-85d8-742bb3d3befe"), new Guid("70144abe-40a7-46cc-bfab-fa062b660168") },
                    { new Guid("0c3c0e7d-ca34-4f1a-9558-f7f3e3e7c803"), new Guid("d9388df8-4c1e-4d8f-85d8-742bb3d3befe"), new Guid("ea349c4f-694e-4a0c-b05e-cb90e23824cf") },
                    { new Guid("1a2a0f8d-db24-4f1a-9668-f8e4e4e8d904"), new Guid("b27f97c6-3af8-4f15-8414-7e3cb3e4ff15"), new Guid("98dc7f61-96b1-489f-8500-6101870b0549") },
                    { new Guid("1b3b1e7c-ec14-4f1a-9778-f9f5f5f9ea05"), new Guid("b27f97c6-3af8-4f15-8414-7e3cb3e4ff15"), new Guid("70144abe-40a7-46cc-bfab-fa062b660168") },
                    { new Guid("2a3a1f8b-fc04-4f1a-9888-fa0606faeb06"), new Guid("8f3f7af9-345b-4a1f-9e4d-d68b2a81267f"), new Guid("96e0c514-7682-4bfe-afb2-766354ef5fbd") },
                    { new Guid("2b4b2e7a-0c14-4f1a-9998-fb1717fbfb07"), new Guid("8f3f7af9-345b-4a1f-9e4d-d68b2a81267f"), new Guid("70144abe-40a7-46cc-bfab-fa062b660168") },
                    { new Guid("2c5c3e79-1d24-4f1a-aaa8-fc2828fcfc08"), new Guid("8f3f7af9-345b-4a1f-9e4d-d68b2a81267f"), new Guid("70144abe-40a7-46cc-bfab-fa062b660168") },
                    { new Guid("3a4a2f7a-2e34-4f1a-bbb8-fd3939fdfd09"), new Guid("e3db7602-54d4-42f3-93c8-d4f3de5cfb0d"), new Guid("96e0c514-7682-4bfe-afb2-766354ef5fbd") },
                    { new Guid("3b5b3e6a-3f44-4f1a-ccc8-fe4a4afe0a10"), new Guid("e3db7602-54d4-42f3-93c8-d4f3de5cfb0d"), new Guid("ea349c4f-694e-4a0c-b05e-cb90e23824cf") },
                    { new Guid("4a5a3f69-4f54-4f1a-ddd8-ff5b5bff1b11"), new Guid("4a9f1b42-1c9c-497d-97f7-7a1741a7c287"), new Guid("245f42aa-dea2-4001-bf4e-d0ad2712068a") },
                    { new Guid("4b6b4e58-5664-4f1a-eee8-005c5c0c2c12"), new Guid("4a9f1b42-1c9c-497d-97f7-7a1741a7c287"), new Guid("70144abe-40a7-46cc-bfab-fa062b660168") },
                    { new Guid("4c7c5e47-6674-4f1a-fff8-116d6d1d3d13"), new Guid("4a9f1b42-1c9c-497d-97f7-7a1741a7c287"), new Guid("ea349c4f-694e-4a0c-b05e-cb90e23824cf") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientId",
                table: "Bookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_BookingId",
                table: "BookingServices",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_ServiceId",
                table: "BookingServices",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingServices");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
