using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Excepciones
{
    public class UnaException : Exception
    {
        public UnaException()
        {
        }

        public UnaException(string? message) : base(message)
        {
        }

        public UnaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
