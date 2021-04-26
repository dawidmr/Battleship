using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class GridCreator : IGridCreator
    {
        private readonly GridFactory Factory;
        private int Size;

        public GridCreator(GridType gridType, int size)
        {
            Factory = ChooseFactory(gridType);
            Size = size;
        }

        public IGrid Create(GridType gridType)
        {
            return Factory.Create(Size);
        }

        public static GridFactory ChooseFactory(GridType gridType) => gridType switch
        {
            GridType.Main => new MainGridFactory(),
            GridType.Opponent => new OpponentGridFactory(),
            _ => throw new UnexpectedGridTypeException(nameof(gridType))
        };
    }
}
