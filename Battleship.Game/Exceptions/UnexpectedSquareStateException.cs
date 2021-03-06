using System;
using System.Runtime.Serialization;

namespace Battleship.Game.Exceptions
{
    [Serializable]
    public class UnexpectedSquareStateException : Exception
    {
        public UnexpectedSquareStateException()
        {
        }

        public UnexpectedSquareStateException(string message) : base(message)
        {
        }

        public UnexpectedSquareStateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnexpectedSquareStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}