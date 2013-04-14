namespace Excella.Lean.Tests.Ui
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class AatException : Exception
    {
        public AatException()
        {
        }

        public AatException(string message)
            : base(message)
        {
        }

        public AatException(string message, Exception innerException) :
            base(message, innerException)
        {
        }

        protected AatException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
