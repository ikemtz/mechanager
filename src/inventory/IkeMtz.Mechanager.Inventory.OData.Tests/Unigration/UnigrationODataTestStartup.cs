using IkeMtz.Mechanager.Inventory.OData.Configuration;
using IkeMtz.Mechanager.Inventory.OData.Data;
using IkeMtz.NRSRx.Core.Unigration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IkeMtz.Mechanager.Inventory.OData.Tests.Unigration
{
  public class UnigrationODataTestStartup
        : CoreODataUnigrationTestStartup<Startup, ModelConfiguration>
  {
    public UnigrationODataTestStartup(IConfiguration configuration) : base(new Startup(configuration))
    {
    }

    public override void SetupDatabase(IServiceCollection services, string connectionString)
    {
      services.SetupTestDbContext<DatabaseContext>();
    }
  }
}
