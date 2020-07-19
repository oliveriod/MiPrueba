using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ByblosMiPH.API.Migrations
{
    public partial class LaPrimera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreación = table.Column<DateTime>(nullable: false),
                    FechaActualización = table.Column<DateTime>(nullable: false),
                    Código = table.Column<string>(maxLength: 10, nullable: true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    BancoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreación = table.Column<DateTime>(nullable: false),
                    FechaActualización = table.Column<DateTime>(nullable: false),
                    Código = table.Column<string>(maxLength: 50, nullable: true),
                    Nombre = table.Column<string>(maxLength: 150, nullable: true),
                    EstadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.BancoId);
                    table.ForeignKey(
                        name: "FK_Bancos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "EstadoId", "Código", "FechaActualización", "FechaCreación", "Nombre" },
                values: new object[] { -1, "INAC", new DateTime(2020, 7, 19, 10, 57, 39, 680, DateTimeKind.Local).AddTicks(5692), new DateTime(2020, 7, 19, 10, 57, 39, 680, DateTimeKind.Local).AddTicks(5432), "Inactivo" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "EstadoId", "Código", "FechaActualización", "FechaCreación", "Nombre" },
                values: new object[] { 1, "ACTI", new DateTime(2020, 7, 19, 10, 57, 39, 680, DateTimeKind.Local).AddTicks(5951), new DateTime(2020, 7, 19, 10, 57, 39, 680, DateTimeKind.Local).AddTicks(5942), "Activo" });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "BancoId", "Código", "EstadoId", "FechaActualización", "FechaCreación", "Nombre" },
                values: new object[] { 1, "BG", 1, new DateTime(2020, 7, 19, 10, 57, 39, 681, DateTimeKind.Local).AddTicks(7298), new DateTime(2020, 7, 19, 10, 57, 39, 681, DateTimeKind.Local).AddTicks(7290), "Banco General" });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "BancoId", "Código", "EstadoId", "FechaActualización", "FechaCreación", "Nombre" },
                values: new object[] { 2, "BNP", 1, new DateTime(2020, 7, 19, 10, 57, 39, 681, DateTimeKind.Local).AddTicks(8017), new DateTime(2020, 7, 19, 10, 57, 39, 681, DateTimeKind.Local).AddTicks(8013), "Banco Nacional de Panamá" });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "BancoId", "Código", "EstadoId", "FechaActualización", "FechaCreación", "Nombre" },
                values: new object[] { 3, "CA", 1, new DateTime(2020, 7, 19, 10, 57, 39, 681, DateTimeKind.Local).AddTicks(8031), new DateTime(2020, 7, 19, 10, 57, 39, 681, DateTimeKind.Local).AddTicks(8031), "Caja de Ahorros" });

            migrationBuilder.CreateIndex(
                name: "IX_Bancos_EstadoId",
                table: "Bancos",
                column: "EstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bancos");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
