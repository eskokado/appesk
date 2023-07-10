using Microsoft.EntityFrameworkCore;

namespace appesk.Data
{
  public class DatabaseContext : DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
      Customers = Set<CustomerModel>();
    }

    public DbSet<CustomerModel> Customers { get; set; }
  }
}
