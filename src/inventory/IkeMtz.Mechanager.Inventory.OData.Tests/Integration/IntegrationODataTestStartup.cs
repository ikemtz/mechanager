using IkeMtz.Mechanager.Inventory.OData.Configuration;
using IkeMtz.NRSRx.Core.Unigration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace IkeMtz.Mechanager.Inventory.OData.Tests.Integration
{
  public class IntegrationODataTestStartup
        : CoreODataIntegrationTestStartup<Startup, ModelConfiguration>
    {
        public IntegrationODataTestStartup(IConfiguration configuration)
            : base(new Startup(configuration))
        {
        }
        public override void SetupAuthentication(AuthenticationBuilder builder)
        {
            builder.SetupTestAuthentication(Configuration, TestContext);
        }
    }
}
