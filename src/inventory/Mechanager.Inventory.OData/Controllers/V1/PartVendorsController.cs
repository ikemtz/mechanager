using System;
using System.Collections.Generic;
using Mechanager.Inventory.Models;
using Mechanager.Inventory.OData.Data;
using IkeMtz.NRSRx.Core.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNet.OData.Query.AllowedQueryOptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Mechanager.Inventory.OData.Controllers.V1
{
  [ApiVersion(VersionDefinitions.v1_0)]
  [Authorize]
  [ODataRoutePrefix("PartVendors")]
  [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 6000)]
  public class PartVendorsController : ODataController
  {
    private readonly IDatabaseContext _databaseContext;

    public PartVendorsController(IDatabaseContext databaseContext)
    {
      _databaseContext = databaseContext;
    }

    [ODataRoute]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ODataEnvelope<PartVendor, Guid>), Status200OK)]
    [EnableQuery(MaxTop = 100, AllowedQueryOptions = All)]
    public IEnumerable<PartVendor> Get()
    {
      return _databaseContext.PartVendors
        .AsNoTracking();
    }
  }
}
