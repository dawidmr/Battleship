using System;
using System.Collections.Generic;

namespace BattleShip.Models
{
    public class Grid : IGrid
    {
        public int Size { get; }
        public List<Square> Squares = new List<Square>();
        public GridType Type { get; }
        public List<SquareStates> AvailableStates = new List<SquareStates>();
        public List<SquareStateTransition> AvailableTransitions = new List<SquareStateTransition>();

        public Grid()
        {
            // TODO: to remove
        }

        public Grid(int size)
        {
            Size = size;
        }

        public void Fill(IFillStrategy fillStrategy)
        {

        }

        public void ChangeSquareState(Coordinates coordinates, SquareStates newState)
        {

        }
    }
}
