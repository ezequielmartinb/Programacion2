using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace ClassLibrary
{
    public static class JuegoDAO
    {
        private static string cadenaConexion;
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static JuegoDAO()
        {
            cadenaConexion = @"Server = .; Database = EJERCICIOS_UTN; Trusted_Connection = True;";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }
        public static void Guardar(Juego juego)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                string command = "INSERT INTO Juegos(NOMBRE, PRECIO, GENERO, CODIGO_USUARIO) "
                + $"VALUES(@nombre, @precio, @genero, @codigo_usuario)";
                SqlCommand sqlCommand = new SqlCommand(command, conexion);
                sqlCommand.Parameters.AddWithValue("nombre", juego.Nombre);
                sqlCommand.Parameters.AddWithValue("precio", juego.Precio);
                sqlCommand.Parameters.AddWithValue("genero", juego.Genero);
                sqlCommand.Parameters.AddWithValue("codigo_usuario", juego.CodigoUsuario);
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
        public static Juego LeerPorId(int codigoJuego)
        {
            Juego juego = null;
            try
            {
                string command = "SELECT * FROM Juegos WHERE CODIGO_JUEGO = @codigo_usuario";
                conexion.Open();

                SqlCommand sqlCommand = new SqlCommand(command, conexion);
                sqlCommand.Parameters.AddWithValue("codigo_usuario", codigoJuego);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string nombre = (string)reader["NOMBRE"];
                    double precio = Convert.ToDouble(reader["PRECIO"]);
                    string genero = (string)reader["GENERO"];
                    int codigoUsuario = Convert.ToInt32(reader["CODIGO_USUARIO"]);

                    juego = new Juego(nombre, precio, genero, codigoUsuario, codigoJuego);
                }
            }
            finally
            {
                conexion.Close();
            }
            return juego;
        }
        public static void Modificar(Juego juego)
        {
            try
            {

                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "UPDATE Juegos SET Juegos.NOMBRE = @nombre, Juegos.PRECIO = @precio, Juegos.GENERO = @genero " +
                    "WHERE Juegos.CODIGO_JUEGO = @codigo_juego";
                comando.Parameters.AddWithValue("nombre", juego.Nombre);
                comando.Parameters.AddWithValue("precio", juego.Precio);
                comando.Parameters.AddWithValue("genero", juego.Genero);
                comando.Parameters.AddWithValue("codigo_juego", juego.CodigoJuego);
                comando.ExecuteNonQuery();
            }
            finally
            {
                conexion.Close();
            }
        }
        public static void Eliminar(Juego juego)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "DELETE FROM Juegos WHERE CODIGO_JUEGO = @codigo_usuario";
                comando.Parameters.AddWithValue("codigo_usuario", juego.CodigoUsuario);
                comando.ExecuteNonQuery();
            }
            finally
            {
                conexion.Close();
            }
        }
        public static List<Biblioteca> Leer()
        {
            List<Biblioteca> bibliotecas = new List<Biblioteca>();

            try
            {
                conexion.Open();
                comando.CommandText = $"SELECT JUEGOS.NOMBRE as juego, JUEGOS.GENERO as genero, JUEGOS.CODIGO_JUEGO as codigoJuego, USUARIOS.USERNAME as usuario " +
                    $"FROM JUEGOS JOIN USUARIOS ON JUEGOS.CODIGO_USUARIO = USUARIOS.CODIGO_USUARIO";

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        bibliotecas.Add(new Biblioteca(dataReader["usuario"].ToString(), dataReader["genero"].ToString(),
                            dataReader["juego"].ToString(),
                          Convert.ToInt32(dataReader["codigoJuego"])));
                    }
                }
            }
            finally
            {
                conexion.Close();
            }

            return bibliotecas;
        }
    }
}
