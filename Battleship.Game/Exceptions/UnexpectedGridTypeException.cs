using System;
using System.Runtime.Serialization;

namespace Battleship.Game
{
    [Serializable]
    internal class UnexpectedGridTypeException : Exception
    {
        public UnexpectedGridTypeException()
        {
        }

        public UnexpectedGridTypeException(string message) : base(message)
        {
        }

        public UnexpectedGridTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnexpectedGridTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}