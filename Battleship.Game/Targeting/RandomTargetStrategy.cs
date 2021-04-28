using Battleship.Game.Exceptions;
using Battleship.Game.Interfaces;
using Battleship.Models;
using System;

namespace Battleship.Game.Targeting
{
    public class RandomTargetStrategy : ITargetStrategy
    {
        private const int maxAttempts = 1000;

        public Coordinates ChooseTarget(IGrid opponentGrid)
        {
            int maxValue = opponentGrid.Size;
            var random = new Random();
            var squares = opponentGrid.GetSquares();

            if (!opponentGrid.IsAnyVirginSquare())
            {
                throw new FailedToChooseTargetException("No available coordinates");
            }

            int x, y, attempts = 0;

            do
            {
                if (attempts++ > maxAttempts)
                {
                    throw new FailedToChooseTargetException($"Max attempts: {maxAttempts} reached.");
                }

                x = random.Next(maxValue);
                y = random.Next(maxValue);
            } 
            while (squares[x, y] != SquareStates.Virgin);

            return new Coordinates(x, y);
        }
    }
}
