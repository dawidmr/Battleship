using Battleship.Models;

namespace Battleship.Game.Interfaces
{
    public interface ISquareStateTransition
    {
        SquareStates GetNewState(SquareStates currentState);
        SquareStates GetNewState(SquareStates currentState, SquareStates suggestedState);
        bool IsValidTransition(SquareStates oldState, SquareStates newState);
    }
}