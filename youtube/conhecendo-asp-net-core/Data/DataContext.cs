using Microsoft.EntityFrameworkCore;
using asp_net_core_api.Models;

namespace asp_net_core_api.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
      : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
  }
}

