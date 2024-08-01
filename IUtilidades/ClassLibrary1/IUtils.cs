using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IUtils<T>
    {
        public bool Serializar(string path, T datos);
        public bool Deserializar(string path, out T datos);
    }
}
