using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using SpaceXAPI.Interfaces;

namespace SpaceXAPI.Launchpad.Controllers
{
    [Route("api/Launchpad")]
    [ApiController]
    public class LaunchpadAPIController : ControllerBase
    {
        readonly ILaunchPadService _launchPadService;

        public LaunchpadAPIController(ILaunchPadService launchPadService) 
        {
            _launchPadService = launchPadService;
        }

        [HttpGet(), Route("GetLaunchPads")]
        [EnableQuery()]
        public async Task<PageResult<Models.Launchpad>> GetLaunchPads(ODataQueryOptions<Models.Launchpad> options)
        {
            ODataQuerySettings settings = new ODataQuerySettings()
            {
                PageSize = 1000
            };

            var returnedData = (await _launchPadService.GetAllLaunchpadsAsync());

            var data = options.ApplyTo(returnedData.AsQueryable(), settings);
           
            return new PageResult<Models.Launchpad>(
                data as IEnumerable<Models.Launchpad>,
                Request.GetNextPageLink(settings.PageSize.GetValueOrDefault(1000)),
                returnedData.Count
            );
        }

    }
}