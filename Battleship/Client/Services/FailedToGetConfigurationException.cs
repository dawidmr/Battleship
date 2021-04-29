using System;
using System.Runtime.Serialization;

namespace Battleship.Client.Services
{
    [Serializable]
    internal class FailedToGetConfigurationException : Exception
    {
        private Exception ex;

        public FailedToGetConfigurationException()
        {
        }

        public FailedToGetConfigurationException(Exception ex)
        {
            this.ex = ex;
        }

        public FailedToGetConfigurationException(string message) : base(message)
        {
        }

        public FailedToGetConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailedToGetConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}