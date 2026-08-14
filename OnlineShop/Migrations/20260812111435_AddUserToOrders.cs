using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(6651), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(6666) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(6670), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(6670) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(6671), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(6672) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(6673), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7097), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7097) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7105), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7106) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7108), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7108) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7110), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7111) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7112), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7113) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7115), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7115) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7117), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7117) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7119), new DateTime(2026, 8, 12, 14, 44, 34, 965, DateTimeKind.Local).AddTicks(7119) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(1989), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2001) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2004), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2005) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2006), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2007) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2009), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2009) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2127), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2127) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2134), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2134) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2137), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2137) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2139), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2139) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2141), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2142) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2143), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2146), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2146) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2148), new DateTime(2026, 8, 12, 14, 20, 30, 238, DateTimeKind.Local).AddTicks(2148) });
        }
    }
}
