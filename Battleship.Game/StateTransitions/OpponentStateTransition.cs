using Battleship.Game.Exceptions;
using Battleship.Game.Interfaces;
using Battleship.Models;

namespace Battleship.Game.StateTransitions
{
    public class OpponentStateTransition : ISquareStateTransition
    {
        public SquareStates GetNewState(SquareStates currentState)
        {
            return GetState(currentState);
        }

        private static SquareStates GetState(SquareStates currentState) => currentState switch
        {
            SquareStates.HittedShip => SquareStates.HittedShip,
            SquareStates.MissedShot => SquareStates.MissedShot,
            SquareStates.Ship => SquareStates.HittedShip,
            SquareStates.SunkShip => SquareStates.SunkShip,
            SquareStates.Virgin => SquareStates.MissedShot,
            _ => throw new UnexpectedSquareStateException(nameof(currentState))
        };

        public bool IsValidTransition(SquareStates oldState, SquareStates newState)
        {
            // TODO: rethink
            return true;
        }
    }
}
