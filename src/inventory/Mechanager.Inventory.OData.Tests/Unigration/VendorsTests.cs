using System;
using System.Linq;
using System.Threading.Tasks;
using Mechanager.Inventory.Models;
using Mechanager.Inventory.OData.Data;
using IkeMtz.NRSRx.Core.Models;
using IkeMtz.NRSRx.Core.Unigration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Mechanager.Inventory.OData.Tests.Unigration
{
  [TestClass]
  public partial class VendorsTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")]
    public async Task GetPartsTest()
    {
      var objA = new Vendor()
      {
        Id = Guid.NewGuid(),
        Name = $"Test- {Guid.NewGuid().ToString().Substring(29)}",
      };
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationODataTestStartup>()
          .ConfigureTestServices(x =>
          {
            ExecuteOnContext<DatabaseContext>(x, db =>
            {
          _ = db.Vendors.Add(objA);
        });
          })
       );
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.GetStringAsync($"odata/v1/{nameof(Vendor)}s?$count=true");

      //Validate OData Result
      TestContext.WriteLine($"Server Reponse: {resp}");
      var envelope = JsonConvert.DeserializeObject<ODataEnvelope<Vendor>>(resp);
      Assert.AreEqual(objA.Name, envelope.Value.First().Name);
    }
  }
}
