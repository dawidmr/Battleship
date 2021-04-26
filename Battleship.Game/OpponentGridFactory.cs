﻿using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class OpponentGridFactory : GridFactory
    {
        public override IGrid Create(int size)
        {
            var grid = new Grid(size, new EmptyFiller());
            grid.Fill();

            return grid;
        }
    }
}
