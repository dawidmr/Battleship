using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class ShipsVerticalFiller : IFillStrategy
    {
        Dictionary<int, int> ships;

        public ShipsVerticalFiller(Dictionary<int, int> _ships)
        {
            ships = _ships;
        }

        public void Fill(ref SquareStates[,] squares)
        {
            var random = new Random();
            int maxValue = squares.Length - 1;

            foreach (var ship in ships)
            {
                var length = ship.Key;

                while (true)
                {
                    int x = random.Next(maxValue);
                    int y = random.Next(maxValue);

                    bool isPlace = IsPlaceForVerticalShip(squares, x, y, length);

                    if (isPlace)
                    {
                        PlaceShipVertical(ref squares, x, y, length);
                        break;
                    }
                }
            }
        }

        private void PlaceShipVertical(ref SquareStates[,] squares, int x, int y, int length)
        {
            for (int i = y; i <= length; i++)
            {
                squares[x, y] = SquareStates.Ship;
            }
        }

        private bool IsPlaceForVerticalShip(SquareStates[,] squares, int x, int y, int length)
        {
            for (int i = y; i <= length; i++)
            {
                if (!IsEmptyNeighbourhood(squares, x, y))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// * * * * *
        /// * x x x *
        /// * x o x *
        /// * x x x *
        /// * * * * *
        /// 
        /// o - point
        /// x - Neighbourhood (checked)
        /// * - Not checked
        /// </summary>
        private bool IsEmptyNeighbourhood(SquareStates[,] squares, int x, int y)
        {
            for (int checkedY = y - 1; checkedY <= y + 1; checkedY++)
            {
                if (!IsEmptyRow(squares, x, checkedY))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsEmptyRow(SquareStates[,] squares, int x, int y)
        {
            var size = squares.Length;

            // row above or below the grid
            if (y < 0 || y >= size)
            {
                return true;
            }

            if (x - 1 >= 0)
            {
               if (squares[x-1, y] != SquareStates.Virgin)
                    return false;
            }

            if (squares[x, y] != SquareStates.Virgin)
            {
                return false;
            }

            if (x + 1 < size)
            {
                if (squares[x+1, y] != SquareStates.Virgin)
                    return false;
            }

            return true;
        }

        public void TestFill(ref SquareStates[,] squares)
        {
            squares[5, 2] = SquareStates.Ship;
            squares[5, 3] = SquareStates.Ship;
            
            squares[7, 7] = SquareStates.Ship;
        }
    }
}
