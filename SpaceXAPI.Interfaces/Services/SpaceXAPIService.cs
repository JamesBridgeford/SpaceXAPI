using SpaceXAPI.Interfaces;
using SpaceXAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace SpaceXAPI.Core.Services
{
    public class SpaceXAPIService : ISpaceXAPIService
    {
        private readonly HttpClient _client;

        public SpaceXAPIService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ICollection<Launchpad>> GetLaunchpads()
        {
            var response = await _client.GetAsync("/v2/launchpads");

            response.EnsureSuccessStatusCode();

            var launchPadData = await response.Content.ReadAsStringAsync();
            
            var launchPads = JsonConvert.DeserializeObject<ICollection<Launchpad>>(launchPadData);

            return launchPads;
        }
    }
}
