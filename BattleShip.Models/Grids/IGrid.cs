using Battleship.Shared;

namespace Battleship.Models
{
    public interface IGrid
    {
        void ChangeSquareState(Coordinates coordinates, SquareStates newState);
        void Fill();
        SquareStates[,] GetSquares();
    }
}