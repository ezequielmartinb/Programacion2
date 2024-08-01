using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ClassLibrary1.DBO
{
    public class AutoDAO
    {
        private SqlConnection conexionSql;

        public AutoDAO()
        {
            DBConnection instanciaSingleton = DBConnection.GetInstance();
            conexionSql = instanciaSingleton.GetConnection();
        }
        public bool Guardar(Auto auto)
        {
            bool retorno = false;
            try
            {
                string command = "INSERT INTO Auto(ID, PATENTE, MARCA, HORA_INGRESO, HORA_EGRESO, VALOR_HORA, ETIPO) "
                + $"VALUES(@id, @patente, @marca, @hora_ingreso, @hora_egreso, @valor_hora, @etipo)";
                SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
                sqlCommand.Parameters.AddWithValue("id", auto.Id);
                sqlCommand.Parameters.AddWithValue("patente", auto.Patente);
                sqlCommand.Parameters.AddWithValue("marca", auto.Marca);
                sqlCommand.Parameters.AddWithValue("hora_ingreso", auto.HoraIngreso);
                sqlCommand.Parameters.AddWithValue("hora_egreso", auto.HoraEgreso);
                sqlCommand.Parameters.AddWithValue("valor_hora", auto.ValorHora);
                sqlCommand.Parameters.AddWithValue("etipo", auto.Tipo);
                conexionSql.Open();
                retorno = true;
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (conexionSql != null && conexionSql.State == System.Data.ConnectionState.Open)
                {
                    conexionSql.Close();
                }
            }
            return retorno;
        }
        public List<Auto> Leer()
        {
            List<Auto> listaDeAutos = new List<Auto>();
            string command = "SELECT * FROM Auto";
            conexionSql.Open();

            SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string patente = (string)reader["PATENTE"];
                string marca = (string)reader["MARCA"];
                DateTime horaIngreso = (DateTime)reader["HORA_INGRESO"];
                DateTime horaEgreso = (DateTime)reader["HORA_EGRESO"];
                float valorHora = (float)(double)reader["VALOR_HORA"];
                ETipoAuto tipo = (ETipoAuto)reader["ETIPO"];
                Auto auto = new Auto(patente, marca, horaIngreso, valorHora, tipo);

                listaDeAutos.Add(auto);
            }
            conexionSql.Close();
            return listaDeAutos;
        }
        public Auto LeerPorId(int id)
        {
            string command = "SELECT * FROM Auto WHERE ID = @id";
            conexionSql.Open();

            SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
            sqlCommand.Parameters.AddWithValue("id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                string patente = (string)reader["PATENTE"];
                string marca = (string)reader["MARCA"];
                DateTime horaIngreso = (DateTime)reader["HORA_INGRESO"];
                DateTime horaEgreso = (DateTime)reader["HORA_EGRESO"];
                float valorHora = (float)(double)reader["VALOR_HORA"];
                ETipoAuto tipo = (ETipoAuto)reader["ETIPO"];
                Auto auto = new Auto(patente, marca, horaIngreso, valorHora, tipo);
                conexionSql.Close();
                return auto;

            }
            conexionSql.Close();
            return null;
        }
        public bool Modificar(Auto auto)
        {
            string command = "UPDATE Auto SET Auto.PATENTE = @patente, Auto.MARCA = @marca, Auto.VALOR_HORA = @valor_hora, Auto.ETIPO = @etipo" +
                " WHERE Auto.ID = @id";
            conexionSql.Open();
            SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
            sqlCommand.Parameters.AddWithValue("id", auto.Id);
            sqlCommand.Parameters.AddWithValue("patente", auto.Patente);
            sqlCommand.Parameters.AddWithValue("marca", auto.Marca);
            sqlCommand.Parameters.AddWithValue("valor_hora", auto.ValorHora);
            sqlCommand.Parameters.AddWithValue("etipo", auto.Tipo);
            int resultadoExecuteNonQuery = sqlCommand.ExecuteNonQuery();

            if (resultadoExecuteNonQuery > 0)
            {
                conexionSql.Close();
                return true;
            }
            conexionSql.Close();
            return false;
        }
        public bool Eliminar(Auto auto)
        {
            string command = "DELETE FROM Auto WHERE ID = @id";
            conexionSql.Open();
            SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
            sqlCommand.Parameters.AddWithValue("id", auto.Id);
            int resultadoExecuteNonQuery = sqlCommand.ExecuteNonQuery();
            if (resultadoExecuteNonQuery > 0)
            {
                conexionSql.Close();
                return true;
            }
            conexionSql.Close();
            return false;
        }
    }
}
