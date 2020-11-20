using crud_based_baltaio.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_based_baltaio.Data
{
  public class AppDataContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=127.0.0.1,1433;Database=crud_based_baltaio;User ID=SA;Password=DockerMsSql127!");
    }
  }
}
