using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        private const string message = "The Request was malformed or contains unsupported elements.";

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException()
            : base()
        {
        }
    }
}
