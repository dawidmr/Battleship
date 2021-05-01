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
        [DataTestMethod]
        [DataRow(1, 1, 1)]
        [TestMethod]
        public void IsPlaceForVerticalShip_possitive(int gridSize, int shipSize, int shipsCount)
        {
            var result = IsPlaceForVerticalShip(gridSize, shipSize, shipsCount);

            Assert.IsTrue(result, $"There should be place for {shipsCount} ships (size:{shipSize}) on grid (size:{gridSize}).");
        }

        [DataTestMethod]
        [DataRow(2, 3, 1)]
        [TestMethod]
        public void IsPlaceForVerticalShip_negative(int gridSize, int shipSize, int shipsCount)
        {
            var result = IsPlaceForVerticalShip(gridSize, shipSize, shipsCount);

            Assert.IsFalse(result, $"There should not be place for {shipsCount} ships (size:{shipSize}) on grid (size:{gridSize}).");
        }

        private bool IsPlaceForVerticalShip(int gridSize, int shipSize, int shipsCount)
        {
            var ships = PrepareShips(new Dictionary<int, int>() { { shipSize, shipsCount } });
            var filler = new ShipsVerticalFiller(ships);
            var squares = new SquareStates[gridSize, gridSize];
            return filler.IsPlaceForVerticalShip(squares, gridSize - 1, 0, 0, shipSize);
        }

        private IEnumerable<Ship> PrepareShips(Dictionary<int, int> shipsSizeCount)
        {
            return shipsSizeCount.Select(s => new Ship() { Size = s.Key, Count = s.Value });
        }
    }
}
