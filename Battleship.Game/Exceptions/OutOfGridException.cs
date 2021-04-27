using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Models.Exceptions
{
    public class OutOfGridException : Exception
    {
        public OutOfGridException(string message) : base(message)
        {
        }
    }
}
