using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopSolutionV1.Data.Migrations
{
    public partial class AddNameProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "501eecb2-2311-4a37-95ad-fa7649abc910");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "59333c35-71c8-4978-96f5-50fdfa4d1845", "AQAAAAEAACcQAAAAEOqzKUJraxvqovuF6XFIrhogezIO5iwCuSHCnhsPDbgmATWRDKB6rirWZS/S2ZDTZg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Name" },
                values: new object[] { new DateTime(2023, 2, 21, 23, 24, 51, 462, DateTimeKind.Local).AddTicks(7670), "Demo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ba200a7d-154a-4ebf-9e31-2fa989c23c66");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b83035e3-c8da-406a-ac7f-bd27b8cf0e5f", "AQAAAAEAACcQAAAAECNTpC5HFqXKfIxWHiy88rJ8p8eEQZoKyFUguvhY3RQ27RUZwCuBNLFCsuELumVSOg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 21, 20, 34, 6, 138, DateTimeKind.Local).AddTicks(8202));
        }
    }
}
