using Battleship.Models;
using System.Collections.Generic;

namespace Battleship.Game.Interfaces
{
    public interface IGridCreator
    {
        IGrid Create(GridType gridType, List<Ship> ships = default);
    }
}