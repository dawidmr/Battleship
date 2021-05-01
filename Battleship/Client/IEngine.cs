using Battleship.Game.Interfaces;
using System.Threading.Tasks;

namespace Battleship.Client
{
    public interface IEngine
    {
        string ErrorMessage { get; }

        Task<IPlayer> CreatePlayerAsync(string name);
        int GetSize();
        int GetSpeed();
        bool? Play(IPlayer attacker, IPlayer victim);
    }
}