using Microsoft.EntityFrameworkCore;
using ProyectoNetApi.Models;

namespace ProyectoNetApi.Data
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
  {
    public DbSet<Product> Product => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Product>().HasData(
        new Product
        {
          Id = 1,
          Name = "Coca Cola",
          Description = "Bebida gaseosa",
          Price = 3000,
          Stock = 20
        },
        new Product
        {
          Id = 2,
          Name = "Speed",
          Description = "Bebida energetica",
          Price = 1500,
          Stock = 10
        }
      );
    }
  };
}