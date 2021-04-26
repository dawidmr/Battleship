using Battleship.Shared;
using Battleship.Models;

namespace Battleship.Game
{
    public interface IPlayer
    {
        IGrid MainGrid { get; set; }
        IGrid OpponentGrid { get; set; }
        Coordinates ChooseTarget();
        bool HasAnyShips();
        SquareStates Shot(Coordinates coordinates);
    }
}