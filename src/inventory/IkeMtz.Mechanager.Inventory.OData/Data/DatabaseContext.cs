using IkeMtz.Mechanager.Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace IkeMtz.Mechanager.Inventory.OData.Data
{
  public class DatabaseContext : DbContext, IDatabaseContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Part> Parts { get; set; }
    public virtual DbSet<PartVendor> PartVendors { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<Vendor> Vendors { get; set; }
  }
}
