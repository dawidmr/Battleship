using Battleship.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests
{
    [TestClass]
    public class GridTests
    {
        private SquareStates[,] GetSquares(int size) => new SquareStates[size, size];

        [TestMethod]
        public void IsAnyVirginSquareTest_Negative()
        {
            var grid = PrepareTestGridWithShip(1);
            var result = grid.IsAnyVirginSquare();

            Assert.IsFalse(result, $"There shouldn't be any square with state {SquareStates.Virgin}.");
        }

        [TestMethod]
        public void IsAnyVirginSquareTest_Positive()
        {
            var grid = PrepareTestGridWithShip(2);
            var result = grid.IsAnyVirginSquare();

            Assert.IsTrue(result, $"There should be at least one square with state {SquareStates.Virgin}.");
        }

        private TestGrid PrepareTestGridWithShip(int size)
        {
            var grid = new TestGrid(size, null, null);
            grid.SetSquareState(0, 0, SquareStates.Ship);

            return grid;
        }
    }
}
