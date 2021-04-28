using Battleship.Models;

namespace Battleship.Game.Interfaces
{
    public interface ISquareStateTransition
    {
        SquareStates GetNewState(SquareStates currentState);
        bool IsValidTransition(SquareStates oldState, SquareStates newState);
    }
}