using Battleship.Models;
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

        public IGrid Create(GridType gridType)
        {
            var factory = ChooseFactory(gridType);
            return factory.Create(Size);
        }

        public static GridFactory ChooseFactory(GridType gridType) => gridType switch
        {
            GridType.Main => new MainGridFactory(),
            GridType.Opponent => new OpponentGridFactory(),
            _ => throw new UnexpectedGridTypeException(nameof(gridType))
        };
    }
}
