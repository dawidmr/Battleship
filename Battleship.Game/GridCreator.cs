﻿using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class GridCreator : IGridCreator
    {
        private int Size;

        public GridCreator(int size)
        {
            Size = size;
        }

        public static GridFactory ChooseFactory(GridType gridType) => gridType switch
        {
            GridType.Main => new MainGridFactory(),
            GridType.Opponent => new OpponentGridFactory(),
            _ => throw new UnexpectedGridTypeException(nameof(gridType))
        };

        public IGrid Create(GridType gridType, List<Ship> ships)
        {
            var factory = ChooseFactory(gridType);
            return factory.Create(Size, ships);
        }
    }
}
