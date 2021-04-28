using Battleship.Models;

namespace Battleship.Game.Interfaces
{
    public interface ITargetStrategy
    {
        Coordinates ChooseTarget(IGrid opponentGrid);
    }
}