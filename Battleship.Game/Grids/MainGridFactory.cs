using Battleship.Game.Grids.Fillers;
using Battleship.Game.Interfaces;
using Battleship.Game.StateTransitions;
using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game.Grids
{
    public class MainGridFactory : GridFactory
    {
        public override IGrid Create(int size, List<Ship> ships)
        {
            var grid = new Grid(size, new ShipsVerticalFiller(ships), new SquareStateTransition());
            grid.Fill();

            return grid;
        }
    }
}
