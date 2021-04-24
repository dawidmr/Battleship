using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Models
{
    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; }
        public SquareStates State { get; set; } = SquareStates.Virgin;
    }
}
