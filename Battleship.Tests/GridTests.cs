using Battleship.Game.Grids;
using Battleship.Game.Interfaces;
using Battleship.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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

        [TestMethod]
        public void ChangeSquareState_Test()
        {
            int size = 3;
            int x = 1;
            int y = 1;
            SquareStates shipState = SquareStates.Ship;

            var grid = PrepareEmptyGridWithTransition(size, shipState);

            var returnedState = grid.ChangeSquareState(new Coordinates(x, y), null);

            ValidateChangeSquareState(shipState, returnedState, x, y, grid);
        }

        [TestMethod]
        public void ChangeSquareState_SuggestedStateTest()
        {
            int size = 3;
            int x = 1;
            int y = 1;
            var shipState = SquareStates.Ship;

            var grid = PrepareEmptyGridWithTransition(size, shipState);

            var returnedState = grid.ChangeSquareState(new Coordinates(x, y), shipState);

            ValidateChangeSquareState(shipState, returnedState, x, y, grid);
        }

        private IGrid PrepareEmptyGridWithTransition(int size, SquareStates stateToReturn)
        {
            var returnShipTransitionMoq = new Mock<ISquareStateTransition>();

            returnShipTransitionMoq
                .Setup(stm => stm.GetNewState(It.IsAny<SquareStates>()))
                .Returns(stateToReturn);

            returnShipTransitionMoq
                .Setup(stm => stm.GetNewState(It.IsAny<SquareStates>(), It.IsAny<SquareStates>()))
                .Returns(stateToReturn);

            return new Grid(size, null, returnShipTransitionMoq.Object);
        }

        private void ValidateChangeSquareState(SquareStates expectedState, SquareStates returnedState, int x, int y, IGrid grid)
        {
            Assert.AreEqual(expectedState, returnedState);

            var squareState = grid.GetSquares()[x, y];

            Assert.AreEqual(expectedState, squareState);
        }

        private TestGrid PrepareTestGridWithShip(int size)
        {
            var grid = new TestGrid(size, null, null);
            grid.SetSquareState(0, 0, SquareStates.Ship);

            return grid;
        }
    }
}
