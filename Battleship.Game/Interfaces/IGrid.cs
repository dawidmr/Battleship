using Battleship.Models;

namespace Battleship.Game.Interfaces
{
    public interface IGrid
    {
        int Size { get; }
        SquareStates[,] GetSquares();
        SquareStates ChangeSquareState(Coordinates coordinates, SquareStates? newState = null);
        void Fill();
        bool IsAnyVirginSquare();
    }
}