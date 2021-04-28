using Battleship.Game.Exceptions;
using Battleship.Game.Interfaces;
using Battleship.Models;
using System;

namespace Battleship.Game.Grids
{
    public class Grid : IGrid
    {
        public int Size { get; }
        protected SquareStates[,] Squares;
        private ISquareStateTransition squareStateTransitions;
        private IFillStrategy fillStrategy;

        public Grid(int size, IFillStrategy _fillStrategy, ISquareStateTransition _sqareStateTransitions)
        {
            Size = size;
            Squares = new SquareStates[size, size];
            fillStrategy = _fillStrategy;
            squareStateTransitions = _sqareStateTransitions;
        }

        public void Fill()
        {
            fillStrategy.Fill(ref Squares, Size);
        }

        public SquareStates[,] GetSquares() => Squares;

        public SquareStates ChangeSquareState(Coordinates coordinates, SquareStates? suggestedState)
        {
            ValidateCoordinates(coordinates);

            var currentState = Squares[coordinates.X, coordinates.Y];
            SquareStates newState;

            if (suggestedState.HasValue)
            {
                newState = squareStateTransitions.GetNewState(currentState, suggestedState.Value);
            }
            else
            {
                newState = squareStateTransitions.GetNewState(currentState);

                if (newState == SquareStates.HittedShip &&
                    IsSunkShip(coordinates))
                {
                    ValidateTransition(newState, SquareStates.SunkShip);
                    newState = SquareStates.SunkShip;
                    SetStateForWholeShip(coordinates, newState);
                }                
            }

            Squares[coordinates.X, coordinates.Y] = newState;

            return newState;
        }

        public bool IsAnyVirginSquare()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Squares[i, j] == SquareStates.Virgin)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void ValidateTransition(SquareStates oldState, SquareStates newState)
        {
            if (squareStateTransitions.IsValidTransition(oldState, newState) == false)
            {
                throw new InvalidStateTransitionException($"Old state: {oldState}, new state: {newState}");
            }
        }

        private void ValidateCoordinates(Coordinates coordinates)
        {
            if (coordinates.X > Size || coordinates.Y > Size)
            {
                throw new OutOfGridException($"X: {coordinates.X}, Y: {coordinates.Y}, size: {Size}.");
            }
        }

        private void SetStateForWholeShip(Coordinates coordinates, SquareStates newState)
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
