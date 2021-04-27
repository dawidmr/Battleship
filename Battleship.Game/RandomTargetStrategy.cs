using Battleship.Models;
using System;

namespace Battleship.Game
{
    public class RandomTargetStrategy : ITargetStrategy
    {
        public Coordinates ChooseTarget(IGrid opponentGrid)
        {
            int maxValue = opponentGrid.Size;
            Random random = new Random();

            return new Coordinates(random.Next(maxValue), random.Next(maxValue));
        }
    }
}
