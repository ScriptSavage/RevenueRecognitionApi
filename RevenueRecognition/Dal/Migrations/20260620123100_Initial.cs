using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Krs = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Krs",
                table: "Customers",
                column: "Krs",
                unique: true,
                filter: "[Krs] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Pesel",
                table: "Customers",
                column: "Pesel",
                unique: true,
                filter: "[Pesel] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PhoneNumber",
                table: "Customers",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
