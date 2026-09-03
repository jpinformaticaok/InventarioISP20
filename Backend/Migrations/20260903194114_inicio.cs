using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProvinciaId = table.Column<int>(type: "integer", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()"),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    Dni = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    LocalidadId = table.Column<int>(type: "integer", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Localidades_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Name", "isDeleted" },
                values: new object[,]
                {
                    { 1, "Argentina", false },
                    { 2, "Brasil", false },
                    { 3, "Chile", false }
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Name", "isDeleted" },
                values: new object[,]
                {
                    { 1, "Buenos Aires", false },
                    { 2, "Córdoba", false },
                    { 3, "Santa Fe", false }
                });

            migrationBuilder.InsertData(
                table: "Localidades",
                columns: new[] { "Id", "Name", "ProvinciaId", "isDeleted" },
                values: new object[,]
                {
                    { 1, "Buenos Aires", 1, false },
                    { 2, "Córdoba", 2, false },
                    { 3, "Santa Fe", 3, false },
                    { 4, "Rosario", 3, false },
                    { 5, "San Justo", 3, false }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Address", "Created_at", "Dni", "Firstname", "Lastname", "LocalidadId", "isDeleted" },
                values: new object[,]
                {
                    { 1, "Calle Falsa 123", new DateTimeOffset(new DateTime(2026, 9, 3, 16, 41, 13, 519, DateTimeKind.Unspecified).AddTicks(8846), new TimeSpan(0, -3, 0, 0, 0)), "12345678", "Juan", "Pérez", 4, false },
                    { 2, "Avenida Siempre Viva 456", new DateTimeOffset(new DateTime(2026, 9, 3, 16, 41, 13, 519, DateTimeKind.Unspecified).AddTicks(8887), new TimeSpan(0, -3, 0, 0, 0)), "87654321", "María", "González", 4, false },
                    { 3, "Callejón del Beso 789", new DateTimeOffset(new DateTime(2026, 9, 3, 16, 41, 13, 519, DateTimeKind.Unspecified).AddTicks(8889), new TimeSpan(0, -3, 0, 0, 0)), "11223344", "Pedro", "López", 4, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LocalidadId",
                table: "Clientes",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Provincias");
        }
    }
}
