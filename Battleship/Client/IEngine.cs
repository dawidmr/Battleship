using Battleship.Game.Interfaces;
using System.Threading.Tasks;

namespace Battleship.Client
{
    public interface IEngine
    {
        Task<IPlayer> CreatePlayerAsync(string name);
        bool Play(IPlayer attacker, IPlayer victim);
    }
}