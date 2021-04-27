using Battleship.Game;
using Battleship.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            List<Ship> ships = new List<Ship>()
            {
                new Ship()
                {
                    Count = 1,
                    Size = shipSize
                }
            };

            ShipsVerticalFiller filler = new ShipsVerticalFiller(ships);

            var squares = new SquareStates[size, size];

            var result = filler.IsPlaceForVerticalShip(squares, size, 0, 6, shipSize);
        }
    }
}
