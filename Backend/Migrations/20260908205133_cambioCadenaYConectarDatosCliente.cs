using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class cambioCadenaYConectarDatosCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 8, 17, 51, 33, 421, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, -3, 0, 0, 0)));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 5, 14, 26, 39, 885, DateTimeKind.Unspecified).AddTicks(9054), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 5, 14, 26, 39, 885, DateTimeKind.Unspecified).AddTicks(9090), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 5, 14, 26, 39, 885, DateTimeKind.Unspecified).AddTicks(9093), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
