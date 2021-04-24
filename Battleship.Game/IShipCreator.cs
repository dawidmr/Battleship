using BattleShip.Models;

namespace Battleship.Game
{
    public interface IShipCreator
    {
        Ship Create(int size);
    }
}