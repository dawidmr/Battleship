using Battleship.Game;
using Battleship.Game.Grids.Fillers;
using Battleship.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Tests
{
    [TestClass]
    public class ShipsVerticalFillerTests
    {
        [TestMethod]
        public void FillTest()
        {
            int size = 10;
            int shipSize = 4;
            IEnumerable<Ship> ships = new List<Ship>()
            {
                new Ship()
                {
                    Count = 1,
                    Size = shipSize
                }
            };

            var filler = new ShipsVerticalFiller(ships);

            var squares = new SquareStates[size, size];

            var result = filler.IsPlaceForVerticalShip(squares, size, 0, 6, shipSize);
        }

        [TestMethod]
        public void IsEmptyRowTest()
        {
            var ships = PrepareShips(new Dictionary<int, int>() { { 1, 1 } });
            var filler = new ShipsVerticalFiller(ships);

        }

        private IEnumerable<Ship> PrepareShips(Dictionary<int, int> shipsSizeCount)
        {
            return shipsSizeCount.Select(s => new Ship() { Size = s.Key, Count = s.Value });
        }
    }
}
