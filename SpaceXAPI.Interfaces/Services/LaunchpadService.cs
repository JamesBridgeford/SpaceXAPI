using SpaceXAPI.Interfaces;
using SpaceXAPI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceXAPI.Core.Services
{
    public class LaunchpadService : ILaunchPadService
    {
        readonly ISpaceXRepository _launchpadRepo;
        
        public LaunchpadService(ISpaceXRepository launchpadRepo)
        {
            _launchpadRepo = launchpadRepo;
        }

        public Task<ICollection<Launchpad>> GetAllLaunchpadsAsync()
        {
            return _launchpadRepo.GetLaunchpadsAsync();
        }
    }
}
