using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ajustesDatosSemilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "Dni", "Firstname", "Lastname" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 8, 17, 59, 26, 992, DateTimeKind.Unspecified).AddTicks(4436), new TimeSpan(0, -3, 0, 0, 0)), "29720301", "Juan Pablo", "Aguero" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 8, 17, 59, 26, 992, DateTimeKind.Unspecified).AddTicks(4471), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 8, 17, 59, 26, 992, DateTimeKind.Unspecified).AddTicks(4474), new TimeSpan(0, -3, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "Dni", "Firstname", "Lastname" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 8, 17, 51, 33, 421, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, -3, 0, 0, 0)), "12345678", "Juan", "Pérez" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 8, 17, 51, 33, 421, DateTimeKind.Unspecified).AddTicks(1535), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 8, 17, 51, 33, 421, DateTimeKind.Unspecified).AddTicks(1539), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
