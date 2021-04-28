using Battleship.Game.Exceptions;
using Battleship.Game.Interfaces;
using Battleship.Models;
using System;

namespace Battleship.Game.StateTransitions
{
    public class OpponentStateTransition : ISquareStateTransition
    {
        public SquareStates GetNewState(SquareStates currentState)
        {
            return UpdateState(currentState);
        }

        public SquareStates GetNewState(SquareStates currentState, SquareStates suggestedState)
        {
            return UpdateState(new Tuple<SquareStates, SquareStates>(currentState, suggestedState));
        }

        private static SquareStates UpdateState(Tuple<SquareStates, SquareStates> states) => states switch
        {
            { Item1: SquareStates.Virgin, Item2: SquareStates.Virgin } => SquareStates.MissedShot,
            { Item1: SquareStates.Virgin, Item2: SquareStates.HittedShip } => SquareStates.HittedShip,
            _ => throw new InvalidStateTransitionException($"Old state: {states.Item1}, new state: {states.Item2}")
        };

        private static SquareStates UpdateState(SquareStates currentState) => currentState switch
        {
            SquareStates.HittedShip => SquareStates.HittedShip,
            SquareStates.MissedShot => SquareStates.MissedShot,
            SquareStates.SunkShip => SquareStates.SunkShip,
            SquareStates.Virgin => SquareStates.MissedShot,
            _ => throw new UnexpectedSquareStateException(nameof(currentState))
        };

        public bool IsValidTransition(SquareStates oldState, SquareStates newState)
        {
            return (oldState == SquareStates.Virgin && newState == SquareStates.MissedShot ||
                oldState == SquareStates.Virgin && newState == SquareStates.HittedShip ||
                oldState == SquareStates.HittedShip && newState == SquareStates.SunkShip);
        }
    }
}
