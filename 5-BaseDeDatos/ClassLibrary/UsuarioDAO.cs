using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class UsuarioDAO
    {
        private static string cadenaConexion;
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static UsuarioDAO()
        {
            cadenaConexion = @"Server = .; Database = EJERCICIOS_UTN; Trusted_Connection = True;";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }
        public static List<Usuario> Leer()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                conexion.Open();
                comando.CommandText = $"SELECT CODIGO_USUARIO, USERNAME FROM USUARIOS";

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        usuarios.Add(new Usuario(dataReader["USERNAME"].ToString(), Convert.ToInt32(dataReader["CODIGO_USUARIO"])));
                    }
                }
            }
            finally
            {
                conexion.Close();
            }

            return usuarios;
        }
    }
}
