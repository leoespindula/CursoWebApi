using APICatalogo.Data.Map;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){  
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
