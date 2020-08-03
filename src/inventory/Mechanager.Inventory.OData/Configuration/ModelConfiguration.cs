using Mechanager.Inventory.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Mechanager.Inventory.OData.Configuration
{
  public class ModelConfiguration : IModelConfiguration
  {
    public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
    {
      _ = builder.EntitySet<Part>($"{nameof(Part)}s");
      _ = builder.EntitySet<PartVendor>($"{nameof(PartVendor)}s");
      _ = builder.EntitySet<Transaction>($"{nameof(Transaction)}s");
      _ = builder.EntitySet<Vendor>($"{nameof(Vendor)}s");
    }
  }
}
