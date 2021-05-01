using Battleship.Models;
using System.Collections.Generic;

namespace Battleship.Game.Interfaces
{
    public interface IFillStrategy
    {
        List<Ship> Fill(ref SquareStates[,] squares, int size);
    }
}