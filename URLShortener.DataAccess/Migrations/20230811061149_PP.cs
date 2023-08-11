using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortener.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 11, 9, 11, 49, 54, DateTimeKind.Local).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 11, 9, 11, 49, 54, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 11, 9, 11, 49, 54, DateTimeKind.Local).AddTicks(2239));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 19, 22, 55, 854, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 19, 22, 55, 854, DateTimeKind.Local).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 19, 22, 55, 854, DateTimeKind.Local).AddTicks(3884));
        }
    }
}
