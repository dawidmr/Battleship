using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class GridCreator : IGridCreator
    {
        private readonly GridFactory Factory;

        public GridCreator(GridType gridType)
        {
            Factory = ChooseFactory(gridType);
        }

        public Grid Create(GridType gridType)
        {
            return Factory.Create();
        }

        public static GridFactory ChooseFactory(GridType gridType) => gridType switch
        {
            GridType.Main => new MainGridFactory(),
            GridType.Opponent => new OpponentGridFactory(),
            _ => throw new UnexpectedGridTypeException(nameof(gridType))
        };
    }
}
