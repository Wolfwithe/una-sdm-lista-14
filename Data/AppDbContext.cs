using Microsoft.EntityFrameworkCore;
using CacauShowApi324123267.Models;
namespace CacauShowApi324123267.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Franquia> Franquias { get; set; }
    public DbSet<LoteProducao> Lotes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
}