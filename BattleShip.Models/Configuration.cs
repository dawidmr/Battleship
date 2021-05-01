using System.Collections.Generic;

namespace Battleship.Models
{
    public class Configuration
    {
        public int GridSize { get; }
        public IEnumerable<ShipPrototype> Ships { get; }
        public int SimulationSpeed { get; }
    }
}
