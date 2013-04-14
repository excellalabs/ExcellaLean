namespace Excella.Lean.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class LeanException : Exception
    {
        public LeanException()
        {
        }

        public LeanException(string message)
            : base(message)
        {
        }

        public LeanException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected LeanException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
