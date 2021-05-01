using Battleship.Game.Exceptions;
using Battleship.Game.Interfaces;
using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Game.Grids.Fillers
{
    public class ShipsVerticalFiller : IFillStrategy
    {
        protected IEnumerable<Ship> _ships;
        protected const int maxAttempts = 100;

        public ShipsVerticalFiller(IEnumerable<Ship> ships)
        {
            _ships = ships;
        }

        public List<List<Coordinates>> Fill(ref SquareStates[,] squares, int size)
        {
            int attemptCount = 0;
            var random = new Random();
            int maxValue = size;
            var ships = new List<List<Coordinates>>();

            foreach (var ship in _ships.OrderByDescending(x => x.Size))
            {
                for (int i = 0; i < ship.Count; i++)
                {
                    while (attemptCount++ < maxAttempts)
                    {
                        int x = random.Next(maxValue);
                        int y = random.Next(maxValue);

                        bool isPlace = IsPlaceForVerticalShip(squares, maxValue - 1, x, y, ship.Size);

                        if (isPlace)
                        {
                            var placedShip = PlaceShipVertical(ref squares, x, y, ship.Size);
                            ships.Add(placedShip);

                            break;
                        }
                    }

                    if (attemptCount > maxAttempts)
                    {
                        throw new FailedToFillGridWithShips($"{nameof(ShipsVerticalFiller)} max attempts: {maxAttempts} reached");
                    }
                    else
                    {
                        attemptCount = 0;
                    }

                }
            }

            return ships;
        }

        public List<Coordinates> PlaceShipVertical(ref SquareStates[,] squares, int x, int y, int length)
        {
            var coordinates = new List<Coordinates>();

            for (int i = y; i < y + length; i++)
            {
                squares[x, i] = SquareStates.Ship;
                coordinates.Add(new Coordinates(x, i));
            }

            return coordinates;
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
        /// * n n n *
        /// * n o n *
        /// * n n n *
        /// * * * * *
        /// 
        /// o - point [x,y]
        /// n - Neighbourhood (checked)
        /// * - Not checked
        /// </summary>
        public bool IsEmptyNeighbourhood(SquareStates[,] squares, int size, int x, int y)
        {
            for (int checkedY = y - 1; checkedY <= y + 1; checkedY++)
            {
                if (!AreEmpty3SquaresInRow(squares, size, x, checkedY))
                {
                    return false;
                }
            }

            return true;
        }

        public bool AreEmpty3SquaresInRow(SquareStates[,] squares, int size, int x, int y)
        {
            if (y < 0 || y > size)
            {
                // row above or below the grid
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

            if (x + 1 <= size)
            {
                if (squares[x+1, y] != SquareStates.Virgin)
                    return false;
            }

            return true;
        }
    }
}
