using System;
using System.Runtime.Serialization;

namespace Battleship.Game.Exceptions
{
    [Serializable]
    internal class FailedToChooseTargetException : Exception
    {
        public FailedToChooseTargetException()
        {
        }

        public FailedToChooseTargetException(string message) : base(message)
        {
        }

        public FailedToChooseTargetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailedToChooseTargetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}