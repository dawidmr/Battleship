using Battleship.Game.Interfaces;
using Battleship.Models;
using System;
using System.Collections.Generic;

namespace Battleship.Game
{
    public class Player : IPlayer
    {
        public IGrid MainGrid { get; set; }
        public IGrid OpponentGrid { get; set; }
        private ITargetStrategy targetStrategy { get; }

        // TODO: inject ships
        public List<Ship> ships = new List<Ship>()
        {
            new Ship() {Size = 1, Count = 4 },
            new Ship() {Size = 2, Count = 3 },
            new Ship() {Size = 3, Count = 2 },
            new Ship() {Size = 4, Count = 1 }
        };

        public Player(IGridCreator gridCreator, ITargetStrategy _targetStrategy)
        {
            targetStrategy = _targetStrategy;
            MainGrid = gridCreator.Create(GridType.Main, ships);
            OpponentGrid = gridCreator.Create(GridType.Opponent);
        }

        public Coordinates ChooseTarget()
        {
            return targetStrategy.ChooseTarget(OpponentGrid);
        }

        public bool HasAnyShips()
        {
            var squares = MainGrid.GetSquares();

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
            try
            {
                return MainGrid.ChangeSquareState(coordinates);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void UpdateOpponentGrid(Coordinates coordinates, SquareStates newState)
        {
            try
            {
                OpponentGrid.ChangeSquareState(coordinates, newState);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
