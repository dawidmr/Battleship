using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.Game
{
    public class ShipsVerticalFiller : IFillStrategy
    {
        List<Ship> ships;

        public ShipsVerticalFiller(List<Ship> _ships)
        {
            ships = _ships;
        }

        public void Fill(ref SquareStates[,] squares, int size)
        {

            // TODO: last line not filled
            var random = new Random();
            int maxValue = size - 1;

            foreach (var ship in ships.OrderByDescending(x => x.Size))
            {
                for (int i = 0; i < ship.Count; i++)
                {
                    while (true)
                    {
                        int x = random.Next(maxValue);
                        int y = random.Next(maxValue);

                        bool isPlace = IsPlaceForVerticalShip(squares, maxValue, x, y, ship.Size);

                        if (isPlace)
                        {
                            PlaceShipVertical(ref squares, x, y, ship.Size);
                            break;
                        }
                    }
                }
            }
        }

        public void PlaceShipVertical(ref SquareStates[,] squares, int x, int y, int length)
        {
            for (int i = y; i < y + length; i++)
            {
                squares[x, i] = SquareStates.Ship;
            }
        }

        public bool IsPlaceForVerticalShip(SquareStates[,] squares, int size, int x, int y, int length)
        {
            if (y + length - 1 > size)
            {
                return false;
            }

            for (int i = y; i < y + length; i++)
            {
                if (!IsEmptyNeighbourhood(squares, size, x, i))
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
        public bool IsEmptyNeighbourhood(SquareStates[,] squares, int size, int x, int y)
        {
            for (int checkedY = y - 1; checkedY <= y + 1; checkedY++)
            {
                if (!IsEmptyRow(squares, size, x, checkedY))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsEmptyRow(SquareStates[,] squares, int size, int x, int y)
        {
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
