using Battleship.Shared;
using BattleShip.Models;

namespace Battleship.Game
{
    public interface IPlayer
    {
        Coordinates ChooseTarget();
        bool HasAnyShips();
        SquareStates Shot(Coordinates coordinates);
    }
}