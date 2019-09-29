using SpaceXAPI.Interfaces;
using SpaceXAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceXAPI.Data
{
    public class SpaceXAPIRepository : ISpaceXRepository
    {
        private readonly ISpaceXAPIService _service;

        public SpaceXAPIRepository(ISpaceXAPIService service)
        {
            _service = service;
        }

        public Task<ICollection<Launchpad>> GetLaunchpadsAsync()
        {
            return _service.GetLaunchpads();
        }
    }
}
