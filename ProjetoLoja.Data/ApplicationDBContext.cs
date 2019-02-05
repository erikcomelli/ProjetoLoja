using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Domain;
using System;

namespace ProjetoLoja.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
