using System;
using System.Linq;
using System.Threading.Tasks;
using IkeMtz.Mechanager.Inventory.Models;
using IkeMtz.Mechanager.Inventory.OData.Data;
using IkeMtz.NRSRx.Core.Models;
using IkeMtz.NRSRx.Core.Unigration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace IkeMtz.Mechanager.Inventory.OData.Tests.Unigration
{
  [TestClass]
  public partial class PartVendorsTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")]
    public async Task GetPartVendorsTest()
    {
      var objA = new PartVendor()
      {
        Id = Guid.NewGuid(),
        Barcode = $"Test- {Guid.NewGuid().ToString().Substring(29)}",
      };
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationODataTestStartup>()
          .ConfigureTestServices(x =>
          {
            ExecuteOnContext<DatabaseContext>(x, db =>
            {
              _ = db.PartVendors.Add(objA);
            });
          })
       );
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.GetStringAsync($"odata/v1/{nameof(PartVendor)}s?$count=true");

      //Validate OData Result
      TestContext.WriteLine($"Server Reponse: {resp}");
      var envelope = JsonConvert.DeserializeObject<ODataEnvelope<PartVendor>>(resp);
      Assert.AreEqual(objA.Barcode, envelope.Value.First().Barcode);
    }
  }
}
