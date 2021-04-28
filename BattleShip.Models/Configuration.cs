using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Models
{
    public class Configuration
    {
        public int GridSize { get; set; }
        public List<Ship> Ships { get; set; }
    }
}
