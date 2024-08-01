using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Excepciones
{
    public class ParseoException : Exception
    {
        public ParseoException()
        {
        }

        public ParseoException(string? message) : base(message)
        {
        }
    }
}
