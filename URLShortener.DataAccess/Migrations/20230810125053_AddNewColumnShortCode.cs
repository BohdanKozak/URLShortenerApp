using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortener.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnShortCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortCode",
                table: "UrlItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ShortCode" },
                values: new object[] { new DateTime(2023, 8, 10, 15, 50, 53, 421, DateTimeKind.Local).AddTicks(2037), null });

            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ShortCode" },
                values: new object[] { new DateTime(2023, 8, 10, 15, 50, 53, 421, DateTimeKind.Local).AddTicks(2041), null });

            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ShortCode" },
                values: new object[] { new DateTime(2023, 8, 10, 15, 50, 53, 421, DateTimeKind.Local).AddTicks(2045), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortCode",
                table: "UrlItems");

            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 13, 7, 12, 608, DateTimeKind.Local).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 13, 7, 12, 608, DateTimeKind.Local).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 13, 7, 12, 608, DateTimeKind.Local).AddTicks(9793));
        }
    }
}
