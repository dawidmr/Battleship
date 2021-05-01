using System.Collections.Generic;

namespace Battleship.Models
{
    public class Configuration
    {
        public int GridSize { get; set; }
        public IEnumerable<ShipPrototype> Ships { get; set; }
        public int SimulationSpeed { get; set; }
    }
}
