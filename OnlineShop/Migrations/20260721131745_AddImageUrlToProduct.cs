using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1043), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1058), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1059) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1060), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1062), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1186), null, new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1187) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1195), null, new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1196) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1199), null, new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1202), null, new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1203) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1205), null, new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1205) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1208), null, new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1208) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1210), null, new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1211) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1213), null, new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1214) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8470), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8486), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8487) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8489), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8492), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8493) });

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8628), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8629) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8631), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8632) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8635), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8636) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8638), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8639) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8641), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8642) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8644), new DateTime(2026, 7, 13, 23, 22, 28, 248, DateTimeKind.Local).AddTicks(8645) });
        }
    }
}
