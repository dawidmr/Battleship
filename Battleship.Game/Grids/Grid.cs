using Battleship.Game.Exceptions;
using Battleship.Game.Interfaces;
using Battleship.Models;

using System;
using System.Collections.Generic;

namespace Battleship.Game.Grids
{
    public class Grid : IGrid
    {
        public int Size { get; }
        protected SquareStates[,] Squares;
        private ISquareStateTransition squareStateTransitions;
        private IFillStrategy fillStrategy;

        public Grid()
        {
            // TODO: to remove
        }

        public Grid(int size, IFillStrategy _fillStrategy, ISquareStateTransition _sqareStateTransitions)
        {
            Size = size;
            Squares = new SquareStates[size, size];
            fillStrategy = _fillStrategy;
            squareStateTransitions = _sqareStateTransitions;
        }

        public void Fill()
        {
            // TODO: Merge FillStrategy with Type
            fillStrategy.Fill(ref Squares, Size);
        }

        public SquareStates[,] GetSquares() => Squares;

        public void ChangeSquareState(Coordinates coordinates, SquareStates newState)
        {
            ValidateCoordinates(coordinates);

            var currentState = Squares[coordinates.X, coordinates.Y];

            if (squareStateTransitions.IsValidTransition(currentState, newState))
            {
                Squares[coordinates.X, coordinates.Y] = newState;
            }
            else
            {
                throw new InvalidStateTransitionException($"Old state: {currentState}, new state: {newState}");
            }
        }

        public SquareStates Shot(Coordinates coordinates)
        {
            ValidateCoordinates(coordinates);

            var square = Squares[coordinates.X, coordinates.Y];
            var newState = squareStateTransitions.GetNewState(square);

            if (newState == SquareStates.HittedShip)
            {
                if (IsSunkShip(coordinates))
                {
                    MarkShipAsSunk(coordinates);
                    return SquareStates.SunkShip;
                }

                Squares[coordinates.X, coordinates.Y] = newState;
            }
            else
            {
                if (newState != SquareStates.MissedShot)
                {
                    // TODO: handle it in state transition
                    Squares[coordinates.X, coordinates.Y] = newState;
                }
            }

            return newState;
        }

        private void ValidateCoordinates(Coordinates coordinates)
        {
            if (coordinates.X > Size || coordinates.Y > Size)
            {
                throw new OutOfGridException($"X: {coordinates.X}, Y: {coordinates.Y}, size: {Size}.");
            }
        }

        private void MarkShipAsSunk(Coordinates coordinates)
        {
            throw new NotImplementedException();
        }

        private bool IsSunkShip(Coordinates coordinates)
        {
            // TODO: implement 
            return false;
        }
    }
}
