using BattleShip.Models;

namespace Battleship.Game
{
    public interface IGridCreator
    {
        IGrid Create(GridType gridType);
    }
}