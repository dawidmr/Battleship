using System;
using System.Runtime.Serialization;

namespace Battleship.Game.Exceptions
{
    [Serializable]
    public class FailedToFillGridWithShipsException : Exception
    {
        public FailedToFillGridWithShipsException()
        {
        }

        public FailedToFillGridWithShipsException(string message) : base(message)
        {
        }

        public FailedToFillGridWithShipsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailedToFillGridWithShipsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}