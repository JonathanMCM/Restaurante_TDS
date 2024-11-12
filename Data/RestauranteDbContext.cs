using Microsoft.EntityFrameworkCore;
using SistemaGerenciamentoRestaurante.Models;

namespace SistemaGerenciamentoRestaurante.Data
{
    public class RestauranteDbContext : DbContext
    {
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<ItemCardapio> ItensCardapio { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Usando SQLite com o caminho para o arquivo de banco de dados
            optionsBuilder.UseSqlite("Data Source=restaurante.db");
        }
    }
}