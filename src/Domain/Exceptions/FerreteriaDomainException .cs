using System;

namespace Domain.Exceptions
{
    public class FeterriaDomainException : Exception
    {
        public FeterriaDomainException()
        { }

        public FeterriaDomainException(string message)
            : base(message)
        { }

        public FeterriaDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
