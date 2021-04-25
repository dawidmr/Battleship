using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BattleShip.Models
{
    public class Square
    {
        public Coordinates Location { get; }
        public SquareStates State { get; set; }

    }
}
