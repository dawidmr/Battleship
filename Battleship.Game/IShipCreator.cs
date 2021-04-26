using Battleship.Models;

namespace Battleship.Game
{
    public interface IShipCreator
    {
        Ship Create(int size);
    }
}