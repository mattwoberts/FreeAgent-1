using System;

namespace FreeAgent
{
    public class FreeAgentException : Exception
    {    
        public FreeAgentException(string message) :base(message)
        {

        }

        public FreeAgentException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
