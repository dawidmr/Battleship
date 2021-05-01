using Battleship.Game.Grids.Fillers;
using Battleship.Game.Interfaces;
using Battleship.Game.StateTransitions;
using Battleship.Models;
using System.Collections.Generic;

namespace Battleship.Game.Grids
{
    public class OpponentGridFactory : GridFactory
    {
        public override IGrid Create(int size, IEnumerable<ShipPrototype> ships)
        {
            var grid = new Grid(size, new EmptyFiller(), new OpponentStateTransition());
            grid.Fill();

            return grid;
        }
    }
}
