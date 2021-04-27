using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class OpponentGridFactory : GridFactory
    {
        public override IGrid Create(int size, List<Ship> ships)
        {
            // TODO: new square transition implementation
            var grid = new Grid(size, new EmptyFiller(), new SquareStateTransition());
            grid.Fill();

            return grid;
        }
    }
}
