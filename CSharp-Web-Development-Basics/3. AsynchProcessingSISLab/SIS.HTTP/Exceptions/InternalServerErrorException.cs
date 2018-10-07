using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private const string message = "The Server has encountered an error.";

        public InternalServerErrorException(string message)
            : base(message)
        {
        }

        public InternalServerErrorException()
            : base()
        {
        }
    }
}
