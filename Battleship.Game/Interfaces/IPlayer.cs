
using Battleship.Models;

namespace Battleship.Game.Interfaces
{
    public interface IPlayer
    {
        IGrid PlayerGrid { get; }
        IGrid OpponentGrid { get; }
        string Name { get; }
        Coordinates ChooseTarget();
        bool HasAnyShips();
        SquareStates Shot(Coordinates coordinates);
        void UpdateOpponentGrid(Coordinates coordinates, SquareStates newState);
    }
}