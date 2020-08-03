using System;
using System.Linq;
using System.Threading.Tasks;
using IkeMtz.Mechanager.Inventory.Models;
using IkeMtz.NRSRx.Core.Models;
using IkeMtz.NRSRx.Core.Unigration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace IkeMtz.Mechanager.Inventory.OData.Tests.Integration
{
  [TestClass]
    public partial class PartsTests : BaseUnigrationTests
    {
        [TestMethod]
        [TestCategory("Integration")]
        public async Task GetPartsTest()
        {
            using var srv = new TestServer(TestHostBuilder<Startup, IntegrationODataTestStartup>());
            var client = srv.CreateClient();
            GenerateAuthHeader(client, GenerateTestToken());

            var resp = await client.GetStringAsync($"odata/v1/{nameof(Part)}s?$count=true");
            TestContext.WriteLine($"Server Reponse: {resp}");
            var envelope = JsonConvert.DeserializeObject<ODataEnvelope<Part>>(resp);
            Assert.AreEqual(envelope.Count, envelope.Value.Count());
            envelope.Value.ToList().ForEach(t =>
            {
                Assert.IsNotNull(t.Description);
                Assert.AreNotEqual(Guid.Empty, t.Id);
            });
        }
    }
}
