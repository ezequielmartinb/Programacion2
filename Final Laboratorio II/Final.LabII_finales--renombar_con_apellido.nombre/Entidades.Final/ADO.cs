using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Entidades.Final
{
    public delegate void ApellidoUsuarioExistenteDelegado(object sender, EventArgs e);

    public class ADO
    {
        static string conexion;
        public static event ApellidoUsuarioExistenteDelegado ApellidoUsuarioExistente;

        static ADO()
        {
            conexion = @"Server = .; Database = laboratorio_2; Trusted_Connection = True;";
        }

        public static bool Agregar(Usuario user)
        {
            bool retorno = false;
            SqlCommand comando = new SqlCommand();
            SqlConnection conexionSql = new SqlConnection(conexion);
            try
            {
                comando.Parameters.Clear();
                conexionSql.Open();
                string command = "INSERT INTO DBO.USUARIOS (NOMBRE, APELLIDO, DNI, CORREO, CLAVE) VALUES(@nombre, @apellido, @dni, @correo, @clave)";
                SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
                sqlCommand.Parameters.AddWithValue("nombre", user.Nombre);
                sqlCommand.Parameters.AddWithValue("apellido", user.Apellido);
                sqlCommand.Parameters.AddWithValue("dni", user.Dni);
                sqlCommand.Parameters.AddWithValue("correo", user.Correo);
                sqlCommand.Parameters.AddWithValue("clave", user.Clave);
                sqlCommand.ExecuteNonQuery();
                List<Usuario> lista = ADO.ObtenerTodos(user.Apellido);
                if (lista != null && lista.Count > 1)
                {
                    UsuariosConApellidosRepetidosEventArgs usuariosConApellidosRepetidosEventArgs = new UsuariosConApellidosRepetidosEventArgs(lista);
                    ADO.ApellidoUsuarioExistente.Invoke(user, usuariosConApellidosRepetidosEventArgs);
                }

                retorno = true;
            }
            finally
            {
                if (conexion != null && conexionSql.State == System.Data.ConnectionState.Open)
                {
                    conexionSql.Close();
                }
            }
            return retorno;
        }
        public static bool Modificar(Usuario user)
        {
            bool retorno = false;
            SqlConnection conexionSql = new SqlConnection(conexion);
            try
            {
                conexionSql.Open();
                string comando = "UPDATE DBO.USUARIOS SET DBO.USUARIOS.NOMBRE = @nombre, DBO.USUARIOS.APELLIDO = @apellido, DBO.USUARIOS.CORREO = @correo, DBO.USUARIOS.CLAVE = @clave WHERE DBO.USUARIOS.DNI = @dni";
                SqlCommand sqlCommand = new SqlCommand(comando, conexionSql);
                sqlCommand.Parameters.AddWithValue("nombre", user.Nombre);
                sqlCommand.Parameters.AddWithValue("apellido", user.Apellido);
                sqlCommand.Parameters.AddWithValue("dni", user.Dni);
                sqlCommand.Parameters.AddWithValue("correo", user.Correo);
                sqlCommand.Parameters.AddWithValue("clave", user.Clave);
                sqlCommand.ExecuteNonQuery();
                retorno = true;
            }
            finally
            {
                conexionSql.Close();
            }
            return retorno;
        }
        public static bool Eliminar(Usuario user)
        {
            bool retorno = false;
            SqlConnection conexionSql = new SqlConnection(conexion);
            try
            {
                string comando = "DELETE FROM DBO.USUARIOS WHERE DBO.USUARIOS.DNI = @dni";
                SqlCommand sqlCommand = new SqlCommand(comando, conexionSql);
                conexionSql.Open();
                sqlCommand.Parameters.AddWithValue("dni", user.Dni);
                sqlCommand.ExecuteNonQuery();
                retorno = true;
            }
            finally
            {
                conexionSql.Close();
            }
            return retorno;
        }
        public static List<Usuario> ObtenerTodos()
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexionSql = new SqlConnection(conexion);
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                conexionSql.Open();
                string command = "SELECT * FROM DBO.USUARIOS";

                SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string nombre = (string)reader["NOMBRE"];
                    string apellido = (string)reader["APELLIDO"];
                    int dni = Convert.ToInt32(reader["DNI"]);
                    string correo = (string)reader["CORREO"];
                    string clave = (string)reader["CLAVE"];
                    Usuario usuario = new Usuario(nombre, apellido, dni, correo, clave);
                    usuarios.Add(usuario);
                }
            }
            finally
            {
                conexionSql.Close();
            }
            return usuarios;
        }
        public static List<Usuario> ObtenerTodos(string apellidoUsuario)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexionSql = new SqlConnection(conexion);
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                conexionSql.Open();
                string command = "SELECT * FROM DBO.USUARIOS WHERE APELLIDO = @apellido";

                SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
                sqlCommand.Parameters.AddWithValue("apellido", apellidoUsuario);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string nombre = (string)reader["NOMBRE"];
                    string apellido = (string)reader["APELLIDO"];
                    int dni = Convert.ToInt32(reader["DNI"]);
                    string correo = (string)reader["CORREO"];
                    string clave = (string)reader["CLAVE"];
                    Usuario usuario = new Usuario(nombre, apellido, dni, correo, clave);
                    usuarios.Add(usuario);
                }
            }
            finally
            {
                conexionSql.Close();
            }
            return usuarios;
        }
    }
}
