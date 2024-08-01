using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary.Login
{
    public class Usuario
    {
        private string nombre;
        private string apellido;
        private string mail;
        private string password;
        private ERol rol;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }
        public ERol Rol { get => rol; set => rol = value; }

        public Usuario(string nombre, string apellido, string mail, string password, ERol rol)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.password = password;
            this.rol = rol;
        }
        public bool ValidarUsuarioYPass(string mail, string pass)
        {
            return this.mail == mail && password == pass;
        }
        public static bool ValidarEmail(string email)
        {
            return email != null && Regex.IsMatch(email, "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$");
        }

    }
}
