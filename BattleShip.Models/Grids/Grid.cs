using Battleship.Shared;
using System;
using System.Collections.Generic;

namespace BattleShip.Models
{
    public class Grid : IGrid
    {
        private int Size { get; }
        protected SquareStates[,] Squares;
        protected GridType Type { get; }
        protected List<SquareStates> AvailableStates = new List<SquareStates>();
        protected List<SquareStateTransition> AvailableTransitions = new List<SquareStateTransition>();
        protected IFillStrategy FillStrategy;

        public Grid()
        {
            // TODO: to remove
        }

        public Grid(int size, IFillStrategy _fillStrategy)
        {
            Size = size;
            FillStrategy = _fillStrategy;
            Squares = new SquareStates[size, size];
            Fill();
        }

        public void Fill()
        {
            // TODO: use fillstrategy
            // TODO: Merge FillStrategy with Type?

            if (Type == GridType.Main)
            {
                Squares[5, 2] = SquareStates.Ship;
                Squares[5, 3] = SquareStates.Ship;

                Squares[7, 7] = SquareStates.Ship;
            }
        }

        public void ChangeSquareState(Coordinates coordinates, SquareStates newState)
        {

        }
    }
}
