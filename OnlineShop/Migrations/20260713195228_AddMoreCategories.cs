using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8470), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8482) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsActive", "IsDeleted", "Name", "ParentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8486), true, false, "موبایل", null, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8487) },
                    { 3, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8489), true, false, "مانیتور", null, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8490) },
                    { 4, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8492), true, false, "تبلت", null, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8493) }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8614), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8616) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8624), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8625) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsActive", "IsDeleted", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, 2, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8628), null, true, false, "Samsung S25", 58000000m, 12, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8629) },
                    { 4, 2, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8631), null, true, false, "iPhone 17", 98000000m, 4, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8632) },
                    { 5, 3, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8635), null, true, false, "LG 27 Inch", 15000000m, 10, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8636) },
                    { 6, 3, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8638), null, true, false, "Samsung Odyssey", 23000000m, 6, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8639) },
                    { 7, 4, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8641), null, true, false, "iPad Air", 47000000m, 8, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8642) },
                    { 8, 4, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8644), null, true, false, "Galaxy Tab S10", 36000000m, 9, new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8645) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9767), new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9781) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9895), new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9904), new DateTime(2026, 7, 2, 16, 25, 57, 574, DateTimeKind.Local).AddTicks(9905) });
        }
    }
}
