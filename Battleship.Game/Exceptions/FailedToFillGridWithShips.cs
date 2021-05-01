using System;
using System.Runtime.Serialization;

namespace Battleship.Game.Exceptions
{
    [Serializable]
    internal class FailedToFillGridWithShips : Exception
    {
        public FailedToFillGridWithShips()
        {
        }

        public FailedToFillGridWithShips(string message) : base(message)
        {
        }

        public FailedToFillGridWithShips(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailedToFillGridWithShips(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}