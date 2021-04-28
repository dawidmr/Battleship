using Battleship.Models;

namespace Battleship.Game.Interfaces
{
    public interface IGrid
    {
        int Size { get; }
        SquareStates ChangeSquareState(Coordinates coordinates, SquareStates? newState = null);
        void Fill();
        SquareStates[,] GetSquares();
        bool IsAnyVirginSquare();
    }
}