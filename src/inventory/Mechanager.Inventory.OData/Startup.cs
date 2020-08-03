using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Mechanager.Inventory.Models;
using Mechanager.Inventory.OData.Data;
using IkeMtz.NRSRx.Core.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mechanager.Inventory.OData
{
  public class Startup : CoreODataStartup
    {
        public override string MicroServiceTitle => $"{nameof(Part)} OData Microservice";
        public override Assembly StartupAssembly => typeof(Startup).Assembly;

        public Startup(IConfiguration configuration) : base(configuration)
        {
        }
        [ExcludeFromCodeCoverage]
        public override void SetupDatabase(IServiceCollection services, string connectionString)
        {
            _ = services
             .AddDbContextPool<DatabaseContext>(x => x.UseSqlServer(connectionString))
             .AddEntityFrameworkSqlServer();
        }

        public override void SetupMiscDependencies(IServiceCollection services)
        {
            _ = services.AddScoped<IDatabaseContext, DatabaseContext>();
        }
    }
}
