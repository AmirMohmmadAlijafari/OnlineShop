using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace OnlineShop.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsActive", "IsDeleted", "Name", "ParentId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9767), true, false, "لپ تاپ", null, new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9781) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsActive", "IsDeleted", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9895), null, true, false, "Laptop Dell", 35000000m, 5, new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9896) },
                    { 2, 1, new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9904), null, true, false, "HP Laptop", 42000000m, 7, new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9905) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
