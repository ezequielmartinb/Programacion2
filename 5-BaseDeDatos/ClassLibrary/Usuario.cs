using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Usuario
    {
        private int codigoUsuario;
        private string username;

        public Usuario(string username, int codigoUsuario)
        {
            this.codigoUsuario = codigoUsuario;
            this.username = username;
        }

        public int CodigoUsuario { get => codigoUsuario; }

        public override string ToString()
        {
            return this.username;
        }
    }
}
