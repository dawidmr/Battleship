using Battleship.Game.Interfaces;
using Battleship.Models;
using System.Collections.Generic;

namespace Battleship.Game.Grids.Fillers
{
    public class EmptyFiller : IFillStrategy
    {
        public List<List<Coordinates>> Fill(ref SquareStates[,] squares, int size)
        {
            return default;
        }
    }
}
