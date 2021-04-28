using Battleship.Models;
using System.Threading.Tasks;

namespace Battleship.Client.Services
{
    public interface IConfigService
    {
        Task<Configuration> GetConfigurationAsync();

        Configuration GetConfiguration();
    }
}