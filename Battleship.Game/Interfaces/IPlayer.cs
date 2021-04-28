using Battleship.Shared;
using Battleship.Models;

namespace Battleship.Game.Interfaces
{
    public interface IPlayer
    {
        IGrid MainGrid { get; set; }
        IGrid OpponentGrid { get; set; }
        Coordinates ChooseTarget();
        bool HasAnyShips();
        SquareStates Shot(Coordinates coordinates);
        void UpdateOpponentGrid(Coordinates coordinates, SquareStates newState);
    }
}