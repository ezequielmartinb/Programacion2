using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Final
{
    public class Login
    {
        private string email;
        private string pass;

        public string Email { get => email; }
        public string Pass { get => pass; }

        public Login(string correo, string clave)
        {
            this.email = correo;
            this.pass = clave;
        }
        public bool Loguear()
        {
            List<Usuario> usuarios = ADO.ObtenerTodos();
            foreach (Usuario user in usuarios)
            {
                if(this.email == user.Correo && this.pass == this.pass)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
