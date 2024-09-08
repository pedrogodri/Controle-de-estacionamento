using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class DadosInjetados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TabelaPrecos",
                columns: new[] { "Id", "DataFim", "DataInicio", "ValorHoraAdicional", "ValorHoraInicial" },
                values: new object[,]
                {
                    { 7, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.00m, 10.00m },
                    { 8, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.00m, 8.00m }
                });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "DataEntrada", "DataSaida", "Duracao", "Placa", "PrecoHora", "TempoCobrado", "ValorTotal" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0), "ABC1234", 10.00m, 2m, 20.00m },
                    { 4, new DateTime(2024, 9, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, "XYZ5678", null, null, null },
                    { 5, new DateTime(2024, 8, 31, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 31, 9, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 45, 0, 0), "LMN9101", 10.00m, 0.5m, 5.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TabelaPrecos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TabelaPrecos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
