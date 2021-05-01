using Battleship.Game.Exceptions;
using Battleship.Game.Interfaces;
using Battleship.Models;

namespace Battleship.Game.StateTransitions
{
    public class MainStateTransition : ISquareStateTransition
    {
        public SquareStates GetNewState(SquareStates currentState)
        {
            return GetState(currentState);
        }

        private static SquareStates GetState(SquareStates currentState) => currentState switch
        {
            SquareStates.Virgin => SquareStates.Virgin,
            SquareStates.HittedShip => SquareStates.SunkShip,
            SquareStates.Ship => SquareStates.HittedShip,
            SquareStates.SunkShip => SquareStates.SunkShip,
            _ => throw new UnexpectedSquareStateException($"{nameof(MainStateTransition)}: {nameof(currentState)})")
        };

        public bool IsValidTransition(SquareStates oldState, SquareStates newState)
        {
            var newValidState = GetNewState(oldState);

            return newState == newValidState;
        }

        public SquareStates GetNewState(SquareStates currentState, SquareStates suggestedState)
        {
            throw new System.NotImplementedException();
        }
    }
}