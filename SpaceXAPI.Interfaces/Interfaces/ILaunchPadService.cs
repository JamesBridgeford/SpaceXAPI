using SpaceXAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceXAPI.Interfaces
{
    public interface ILaunchPadService
    {
        Task<ICollection<Launchpad>> GetAllLaunchpadsAsync();
    }
}
