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
  public partial class PartsTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")]
    public async Task GetPartsTest()
    {
      var objA = new Part()
      {
        Id = Guid.NewGuid(),
        Description = $"Test- {Guid.NewGuid().ToString().Substring(29)}",
      };
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationODataTestStartup>()
          .ConfigureTestServices(x =>
          {
            ExecuteOnContext<DatabaseContext>(x, db =>
            {
              _ = db.Parts.Add(objA);
            });
          })
       );
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.GetStringAsync($"odata/v1/{nameof(Part)}s?$count=true");

      //Validate OData Result
      TestContext.WriteLine($"Server Reponse: {resp}");
      var envelope = JsonConvert.DeserializeObject<ODataEnvelope<Part>>(resp);
      Assert.AreEqual(objA.Description, envelope.Value.First().Description);
    }
  }
}
