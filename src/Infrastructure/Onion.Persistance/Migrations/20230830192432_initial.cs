using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Onion.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreationDate", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("87b35ef7-725a-40d3-bdba-0d083f3bf211"), new DateTime(2023, 8, 30, 19, 24, 32, 608, DateTimeKind.Utc).AddTicks(8673), "Mask", 19.99m, 50 },
                    { new Guid("8fa52cc9-4891-499e-8d28-2066d380b037"), new DateTime(2023, 8, 30, 19, 24, 32, 608, DateTimeKind.Utc).AddTicks(8688), "Knife", 250.99m, 10 },
                    { new Guid("d5e89339-114e-40c4-ba58-3259ec466256"), new DateTime(2023, 8, 30, 19, 24, 32, 608, DateTimeKind.Utc).AddTicks(8690), "Glove", 350.99m, 85 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
