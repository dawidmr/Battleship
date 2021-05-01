using Battleship.Game;
using Battleship.Game.Grids.Fillers;
using Battleship.Models;
using Battleship.Game.Exceptions;
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
        [DataRow(4, 1, 4)]
        [DataRow(6, 6, 3)]
        [TestMethod]
        public void Fill_Positive(int gridSize, int shipSize, int shipCount)
        {
            var ships = PrepareShips(new Dictionary<int, int>() { { shipSize, shipCount } });
            var filler = new ShipsVerticalFiller(ships);
            var squares = new SquareStates[gridSize, gridSize];

            var shipsOnGrid = filler.Fill(ref squares, gridSize);

            Assert.AreEqual(shipCount, shipsOnGrid.Count, $"There should be {shipCount} ships placed on grid ({gridSize}).");
        }

        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(3, 1, 5)]
        [TestMethod]
        [ExpectedException(typeof(FailedToFillGridWithShipsException))]
        public void Fill_Negative(int gridSize, int shipSize, int shipCount)
        {
            var ships = PrepareShips(new Dictionary<int, int>() { { shipSize, shipCount } });
            var filler = new ShipsVerticalFiller(ships);
            var squares = new SquareStates[gridSize, gridSize];

            filler.Fill(ref squares, gridSize);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(5, 5)]
        [DataRow(10, 6)]
        [TestMethod]
        public void IsPlaceForVerticalShip_Possitive(int gridSize, int shipSize)
        {
            var result = IsPlaceForVerticalShipTest(gridSize, shipSize);

            Assert.IsTrue(result, $"There should be place for ship (size:{shipSize}) on grid (size:{gridSize}).");
        }

        [DataTestMethod]
        [DataRow(1, 2)]
        [DataRow(2, 10)]
        [TestMethod]
        public void IsPlaceForVerticalShip_Negative(int gridSize, int shipSize)
        {
            var result = IsPlaceForVerticalShipTest(gridSize, shipSize);

            Assert.IsFalse(result, $"There should not be place for ship (size:{shipSize}) on grid (size:{gridSize}).");
        }

        private bool IsPlaceForVerticalShipTest(int gridSize, int shipSize)
        {
            var filler = new ShipsVerticalFiller(null);
            var squares = new SquareStates[gridSize, gridSize];
            return filler.IsPlaceForVerticalShip(squares, gridSize - 1, 0, 0, shipSize);
        }

        private IEnumerable<ShipPrototype> PrepareShips(Dictionary<int, int> shipsSizeCount)
        {
            return shipsSizeCount.Select(s => new ShipPrototype(name: null, size: s.Key, count: s.Value));
        }
    }
}
