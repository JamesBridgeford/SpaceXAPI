using SpaceXAPI.Interfaces;
using SpaceXAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Options;
using SpaceXAPI.Core.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace SpaceXAPI.Core.Services
{
    public class SpaceXAPIService : ISpaceXAPIService
    {
        private readonly HttpClient _client;
        private readonly SpaceXAPIData clientData;

        public SpaceXAPIService(IOptions<SpaceXAPIData> options)
        {
            clientData = options.Value;
            _client = new HttpClient();
        }

        public async Task<ICollection<Launchpad>> GetLaunchpads()
        {
            var response = await _client.GetAsync(new Uri(clientData.URL));

            response.EnsureSuccessStatusCode();

            var launchPadData = await response.Content.ReadAsStringAsync();
            
            var launchPads = JsonConvert.DeserializeObject<ICollection<Launchpad>>(launchPadData);

            return launchPads;
        }
    }
}
