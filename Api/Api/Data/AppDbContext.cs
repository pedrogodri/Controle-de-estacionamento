using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<VeiculoModel> Veiculos { get; set; }
        public DbSet<TabelaPrecoModel> TabelaPrecos { get; set; }
    }
}
