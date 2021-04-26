using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public abstract class GridFactory
    {
        public abstract IGrid Create(int size);
    }
}
