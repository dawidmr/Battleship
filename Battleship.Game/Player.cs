using Battleship.Game.Interfaces;
using Battleship.Models;
using System;
using System.Collections.Generic;

namespace Battleship.Game
{
    public class Player : IPlayer
    {
        public IGrid PlayerGrid { get; }
        public IGrid OpponentGrid { get; }
        private ITargetStrategy targetStrategy { get; }

        public string Name { get; }

        public Player(IGridCreator gridCreator, ITargetStrategy _targetStrategy, int gridSize, IEnumerable<ShipPrototype> ships, string playerName)
        {
            targetStrategy = _targetStrategy;
            PlayerGrid = gridCreator.Create(GridType.Main, gridSize, ships);
            OpponentGrid = gridCreator.Create(GridType.Opponent, gridSize);
            Name = playerName;
        }

        public Coordinates ChooseTarget()
        {
            return targetStrategy.ChooseTarget(OpponentGrid);
        }

        public bool HasAnyShips()
        {
            var squares = PlayerGrid.GetSquares();

            foreach (var square in squares)
            {
                if (square == SquareStates.Ship)
                {
                    return true;
                }
            }

            return false;
        }

        public SquareStates Shot(Coordinates coordinates)
        {
            return PlayerGrid.ChangeSquareState(coordinates);
        }

        public void UpdateOpponentGrid(Coordinates coordinates, SquareStates newState)
        {
            OpponentGrid.ChangeSquareState(coordinates, newState);
        }
    }
}
