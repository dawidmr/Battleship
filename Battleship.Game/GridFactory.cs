﻿using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public abstract class GridFactory
    {
        public abstract Grid Create();
    }
}