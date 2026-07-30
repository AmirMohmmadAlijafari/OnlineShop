using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7717), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7732) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7734), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7735) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7736), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7736) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7737), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7738) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7838), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7839) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7845), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7848), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7849) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7851), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7851) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7853), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7853) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7855), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7856) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7857), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7858) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7859), new DateTime(2026, 7, 30, 15, 37, 4, 536, DateTimeKind.Local).AddTicks(7860) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1186), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1187) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1195), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1196) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1199), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1202), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1203) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1205), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1205) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1208), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1208) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1210), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1211) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1213), new DateTime(2026, 7, 21, 16, 47, 45, 418, DateTimeKind.Local).AddTicks(1214) });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
