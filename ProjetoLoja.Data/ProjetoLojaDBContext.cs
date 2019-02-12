using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Domain;

namespace ProjetoLoja.Data
{
    public class ProjetoLojaDBContext : DbContext
    {
        public ProjetoLojaDBContext(DbContextOptions<ProjetoLojaDBContext> options): base(options){}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}