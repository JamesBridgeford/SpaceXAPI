using SpaceXAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceXAPI.Interfaces
{
    public interface ISpaceXAPIService
    {
        Task<ICollection<Launchpad>> GetLaunchpads();
    }
}
