using Microsoft.EntityFrameworkCore;

namespace appesk.Data
{
  public class DatabaseContext : DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<CustomerModel> Customers { get; set; }
  }
}
