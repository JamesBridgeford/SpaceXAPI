using SpaceXAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceXAPI.Interfaces
{
    public interface ISpaceXRepository
    {
        Task<ICollection<Launchpad>> GetLaunchpadsAsync();
    }
}
