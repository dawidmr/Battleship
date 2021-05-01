using System.Collections.Generic;

namespace Battleship.Models
{
    public class Ship
    {
        public Ship(List<Coordinates> coordinates)
        {
            this.Parts = coordinates;
        }

        public List<Coordinates> Parts { get; }
    }
}
