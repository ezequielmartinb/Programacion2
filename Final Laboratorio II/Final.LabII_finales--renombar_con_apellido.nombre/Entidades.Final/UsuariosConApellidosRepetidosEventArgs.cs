using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Final
{
    public class UsuariosConApellidosRepetidosEventArgs : EventArgs
    {
        public UsuariosConApellidosRepetidosEventArgs()
        {
        }

        public UsuariosConApellidosRepetidosEventArgs(List<Usuario> usuarios)
        {

        }
    }
}
