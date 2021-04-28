using Battleship.Game.Interfaces;
using Battleship.Models;

namespace Battleship.Game
{
    public class EmptyFiller : IFillStrategy
    {
        public void Fill(ref SquareStates[,] squares, int size)
        {
            // Do nothing.
        }
    }
}
