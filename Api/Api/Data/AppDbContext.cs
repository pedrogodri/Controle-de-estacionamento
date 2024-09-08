using Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabelaPrecoModel>()
            .HasData(
                new TabelaPrecoModel
                {
                    Id = 1,
                    DataInicio = new DateTime(2024, 1, 1),
                    DataFim = new DateTime(2024, 12, 31),
                    ValorHoraInicial = 10.00m,
                    ValorHoraAdicional = 5.00m
                },
                new TabelaPrecoModel
                {
                    Id = 2,
                    DataInicio = new DateTime(2023, 1, 1),
                    DataFim = new DateTime(2023, 12, 31),
                    ValorHoraInicial = 8.00m,
                    ValorHoraAdicional = 4.00m
                }
            );

            // Seed data for Veiculos
            modelBuilder.Entity<VeiculoModel>()
                .HasData(
                    new VeiculoModel
                    {
                        Id = 1,
                        Placa = "ABC1234",
                        DataEntrada = new DateTime(2024, 9, 1, 8, 0, 0),
                        DataSaida = new DateTime(2024, 9, 1, 10, 0, 0),
                        Duracao = TimeSpan.FromHours(2),
                        TempoCobrado = 2,
                        PrecoHora = 10.00m,
                        ValorTotal = 20.00m
                    },
                    new VeiculoModel
                    {
                        Id = 2,
                        Placa = "XYZ5678",
                        DataEntrada = new DateTime(2024, 9, 2, 14, 30, 0),
                        DataSaida = null, // Indica que ainda não saiu
                        Duracao = null,
                        TempoCobrado = null,
                        PrecoHora = null,
                        ValorTotal = null
                    },
                    new VeiculoModel
                    {
                        Id = 3,
                        Placa = "LMN9101",
                        DataEntrada = new DateTime(2024, 8, 31, 9, 0, 0),
                        DataSaida = new DateTime(2024, 8, 31, 9, 45, 0),
                        Duracao = TimeSpan.FromMinutes(45),
                        TempoCobrado = 0.5m,
                        PrecoHora = 10.00m,
                        ValorTotal = 5.00m
                    }
                );
        }

        public DbSet<VeiculoModel> Veiculos { get; set; }
        public DbSet<TabelaPrecoModel> TabelaPrecos { get; set; }
    }
}
