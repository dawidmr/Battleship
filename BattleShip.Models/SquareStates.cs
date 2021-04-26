using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Models
{
    public enum SquareStates
    {
        Virgin,
        Ship,
        HittedShip,
        SunkShip,
        MissedShot
    }
}
