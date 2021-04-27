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
            var grid = new Grid(size, new EmptyFiller(), new OpponentStateTransition());
            grid.Fill();

            return grid;
        }
    }
}
