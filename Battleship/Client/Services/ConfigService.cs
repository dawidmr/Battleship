using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Battleship.Client.Services
{
    public class ConfigService : IConfigService
    {
        private HttpClient client;

        public ConfigService(HttpClient _client)
        {
            client = _client;
        }

        public Task<Configuration> GetConfigurationAsync()
        {
            var result = client.GetFromJsonAsync<Configuration>("api/Battleship");
            return result;
        }

        public Configuration GetConfiguration()
        {
            var result = client.GetFromJsonAsync<Configuration>("api/Battleship").GetAwaiter().GetResult();

            return result;
        }
    }
}
