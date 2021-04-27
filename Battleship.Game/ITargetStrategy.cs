using Battleship.Models;

namespace Battleship.Game
{
    public interface ITargetStrategy
    {
        Coordinates ChooseTarget(IGrid opponentGrid);
    }
}