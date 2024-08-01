using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Excepciones
{
    public class MiException : Exception
    {
        public MiException()
        {
        }

        public MiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
