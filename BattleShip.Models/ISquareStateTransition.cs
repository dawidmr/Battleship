namespace Battleship.Models
{
    public interface ISquareStateTransition
    {
        SquareStates GetNewState(SquareStates currentState);
        bool IsValidTransition(SquareStates oldState, SquareStates newState);
    }
}