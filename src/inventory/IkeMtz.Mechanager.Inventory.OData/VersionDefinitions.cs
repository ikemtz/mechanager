using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using IkeMtz.NRSRx.Core.Web;

namespace IkeMtz.Mechanager.Inventory.OData
{
    public class VersionDefinitions : IApiVersionDefinitions
    {
        public const string v1_0 = "1.0";

        [ExcludeFromCodeCoverage]
        public IEnumerable<string> Versions => new[] { v1_0 };
    }
}
