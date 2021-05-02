using Battleship.Game.Grids;
using Battleship.Game.Interfaces;
using Battleship.Models;

namespace Battleship.Tests
{
    public class TestGrid : Grid
    {
        public TestGrid(int size, IFillStrategy fillStrategy, ISquareStateTransition squareStateTransitions) : base(size, fillStrategy, squareStateTransitions)
        {
        }

        public void SetSquareState(int x, int y, SquareStates newState)
        {
            Squares[x, y] = newState;
        }
    }
}
