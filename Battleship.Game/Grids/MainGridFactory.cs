using Battleship.Game.Grids.Fillers;
using Battleship.Game.Interfaces;
using Battleship.Game.StateTransitions;
using Battleship.Models;
using System.Collections.Generic;

namespace Battleship.Game.Grids
{
    public class MainGridFactory : GridFactory
    {
        public override IGrid Create(int size, IEnumerable<ShipPrototype> ships)
        {
            var grid = new Grid(size, new ShipsVerticalFiller(ships), new MainStateTransition());
            grid.Fill();

            return grid;
        }
    }
}
