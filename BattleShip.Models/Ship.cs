using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Models
{
    public class Ship
    {
        public List<Square> Coordinates = new List<Square>();

        public int ShipSize => Coordinates.Count;
    }
}
