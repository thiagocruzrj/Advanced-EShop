using System;

namespace AES.Core.DomainObjects
{
    public class DomainException : Exception
    {
        public DomainException() { }
        public DomainException(string message) : base(message) { }
        public DomainException(string message, Exception innerExcecption) : base(message, innerExcecption) { }
    }
}