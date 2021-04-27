﻿using Battleship.Models;

namespace Battleship.Game
{
    public class SquareStateTransition : ISquareStateTransition
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
            var newValidState = GetNewState(oldState);

            return newState == newValidState;
        }
    }
}