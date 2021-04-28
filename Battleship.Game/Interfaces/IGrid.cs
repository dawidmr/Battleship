using Battleship.Models;

namespace Battleship.Game.Interfaces
{
    public interface IGrid
    {
        int Size { get; }
        void ChangeSquareState(Coordinates coordinates, SquareStates newState);
        void Fill();
        SquareStates[,] GetSquares();
        SquareStates Shot(Coordinates coordinates);
    }
}