using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class EmptyFiller : IFillStrategy
    {
        public void Fill(ref SquareStates[,] squares)
        {
            // Do nothing.
        }
    }
}
