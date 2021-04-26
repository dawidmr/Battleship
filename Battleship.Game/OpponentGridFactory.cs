using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class OpponentGridFactory : GridFactory
    {
        public override IGrid Create(int size)
        {
            // TODO: create fill strategy
            return new Grid(size, null);
        }
    }
}
