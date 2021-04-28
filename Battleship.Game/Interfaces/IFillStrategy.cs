using Battleship.Models;

namespace Battleship.Game.Interfaces
{
    public interface IFillStrategy
    {
        void Fill(ref SquareStates[,] squares, int size);
    }
}