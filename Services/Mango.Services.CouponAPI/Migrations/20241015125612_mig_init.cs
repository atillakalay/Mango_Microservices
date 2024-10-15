using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig_init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    MinAmount = table.Column<int>(type: "int", nullable: false),
                    CraetedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.CouponId);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CouponCode", "CraetedDate", "DiscountAmount", "LastUpdated", "MinAmount" },
                values: new object[,]
                {
                    { 1, "10OFF", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 10.0, null, 20 },
                    { 2, "20OFF", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 20.0, null, 40 },
                    { 3, "30OFF", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 30.0, null, 60 },
                    { 4, "40OFF", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 40.0, null, 80 },
                    { 5, "50OFF", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 50.0, null, 100 },
                    { 6, "60OFF", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 60.0, null, 120 },
                    { 7, "70OFF", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 70.0, null, 140 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
