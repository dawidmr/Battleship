using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class MainGridFactory : GridFactory
    {
        public override IGrid Create()
        {
            return new Grid();
        }
    }
}
