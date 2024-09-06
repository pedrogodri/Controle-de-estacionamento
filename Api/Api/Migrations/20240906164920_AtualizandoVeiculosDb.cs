using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoVeiculosDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duracao",
                table: "Veiculos",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoHora",
                table: "Veiculos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TempoCobrado",
                table: "Veiculos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Veiculos",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracao",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "PrecoHora",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "TempoCobrado",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Veiculos");
        }
    }
}
