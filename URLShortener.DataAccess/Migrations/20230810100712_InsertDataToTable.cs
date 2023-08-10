using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace URLShortener.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InsertDataToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UrlItems",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ShortedUrl", "Url" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 8, 10, 13, 7, 12, 608, DateTimeKind.Local).AddTicks(9747), null, "https://www.youtube.com/watch?v=pQYr1LbVFaM&ab_channel=XGTVUA" },
                    { 2, null, new DateTime(2023, 8, 10, 13, 7, 12, 608, DateTimeKind.Local).AddTicks(9791), null, "https://open.spotify.com/queue" },
                    { 3, null, new DateTime(2023, 8, 10, 13, 7, 12, 608, DateTimeKind.Local).AddTicks(9793), null, "https://mail.google.com/mail/u/0/#inbox" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UrlItems",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
