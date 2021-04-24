using BattleShip.Models;

namespace Battleship.Game
{
    public interface IGridCreator
    {
        Grid Create(GridType gridType);
    }
}