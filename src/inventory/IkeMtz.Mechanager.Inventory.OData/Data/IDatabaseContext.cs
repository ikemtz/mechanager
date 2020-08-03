using IkeMtz.Mechanager.Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace IkeMtz.Mechanager.Inventory.OData.Data
{
  public interface IDatabaseContext
  {
    DbSet<Part> Parts { get; set; }
    DbSet<PartVendor> PartVendors { get; set; }
    DbSet<Transaction> Transactions { get; set; }
    DbSet<Vendor> Vendors { get; set; }
  }
}

