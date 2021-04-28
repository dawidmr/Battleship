using Battleship.Game.Interfaces;
using System.Threading.Tasks;

namespace Battleship.Client
{
    public interface IEngine
    {
        IPlayer CreatePlayer(string name);
        Task<IPlayer> CreatePlayerAsync(string name);
        bool Play(IPlayer attacker, IPlayer victim);
    }
}