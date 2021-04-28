using Battleship.Game.Interfaces;
using System.Threading.Tasks;

namespace Battleship.Client
{
    public interface IEngine
    {
        IPlayer CreatePlayer();
        Task<IPlayer> CreatePlayerAsync();
        bool Play(IPlayer attacker, IPlayer victim);
    }
}