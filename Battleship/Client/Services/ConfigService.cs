using Battleship.Models;
using System;
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
            try
            {
                var result = client.GetFromJsonAsync<Configuration>("api/Battleship");
                return result;
            }
            catch (Exception ex)
            {
                throw new FailedToGetConfigurationException(ex);
            }
        }

        public Configuration GetConfiguration()
        {
            try
            {
                var result = client.GetFromJsonAsync<Configuration>("api/Battleship").GetAwaiter().GetResult();
                return result;
            }
            catch (Exception ex)
            {
                throw new FailedToGetConfigurationException(ex);
            }
        }
    }
}
