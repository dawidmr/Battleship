using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class MainGridFactory : GridFactory
    {
        public override IGrid Create(int size)
        {
            var grid = new Grid(size, new ShipsFiller());
            grid.Fill();

            return grid;
        }
    }
}
