using Battleship.Shared;
using System;
using System.Collections.Generic;

namespace Battleship.Models
{
    public class Grid : IGrid
    {
        private int Size { get; }
        protected SquareStates[,] Squares;
        protected GridType Type { get; }
        protected List<SquareStates> AvailableStates = new List<SquareStates>();
        protected List<SquareStateTransition> AvailableTransitions = new List<SquareStateTransition>();
        protected IFillStrategy fillStrategy;

        public Grid()
        {
            // TODO: to remove
        }

        public Grid(int size, IFillStrategy _fillStrategy)
        {
            Size = size;
            Squares = new SquareStates[size, size];
            fillStrategy = _fillStrategy;
        }

        public void Fill()
        {
            // TODO: Merge FillStrategy with Type
            fillStrategy.Fill(ref Squares, Size);
        }

        public SquareStates[,] GetSquares() => Squares;

        public void ChangeSquareState(Coordinates coordinates, SquareStates newState)
        {

        }
    }
}
