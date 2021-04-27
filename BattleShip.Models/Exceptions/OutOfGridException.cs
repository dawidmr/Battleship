using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game.Exceptions
{
    public class OutOfGridException : Exception
    {
        public OutOfGridException(string message) : base(message)
        {
        }
    }
}
