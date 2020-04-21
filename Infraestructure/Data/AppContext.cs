using Microsoft.EntityFrameworkCore;
using uow.Domain.Models;

namespace uow.Infraestructure.Data
{
  public class AppContext : DbContext
  {
    public AppContext(DbContextOptions<AppContext> options)
      : base(options)
    {
    }

    public static DbContextOptions<AppContext> GetOptions() => new DbContextOptionsBuilder<AppContext>()
      .UseInMemoryDatabase(databaseName: "Database")
      .Options;
      
    public DbSet<CustomerModel> Clients { get; set; }

    public DbSet<ProductModel> Products { get; set; }
  }
}