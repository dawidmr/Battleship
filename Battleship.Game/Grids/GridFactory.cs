using Battleship.Game.Interfaces;
using Battleship.Models;
using System.Collections.Generic;

namespace Battleship.Game.Grids
{
    public abstract class GridFactory
    {
        public abstract IGrid Create(int size, IEnumerable<ShipPrototype> ships);
    }
}
