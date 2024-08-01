using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ClassLibrary1.DBO
{
    public class CamionDAO
    {
        private SqlConnection conexionSql;

        public CamionDAO()
        {
            DBConnection instanciaSingleton = DBConnection.GetInstance();
            conexionSql = instanciaSingleton.GetConnection();
        }
        public bool Guardar(Camion camion)
        {
            bool retorno = false;
            try
            {
                string command = "INSERT INTO Camion(ID, PATENTE, MARCA, HORA_INGRESO, HORA_EGRESO, VALOR_HORA, ETIPO) "
                + $"VALUES(@id, @patente, @marca, @hora_ingreso, @hora_egreso, @valor_hora, @etipo)";
                SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
                sqlCommand.Parameters.AddWithValue("id", camion.Id);
                sqlCommand.Parameters.AddWithValue("patente", camion.Patente);
                sqlCommand.Parameters.AddWithValue("marca", camion.Marca);
                sqlCommand.Parameters.AddWithValue("hora_ingreso", camion.HoraIngreso);
                sqlCommand.Parameters.AddWithValue("hora_egreso", camion.HoraEgreso);
                sqlCommand.Parameters.AddWithValue("valor_hora", camion.ValorHora);
                sqlCommand.Parameters.AddWithValue("etipo", camion.Tipo);
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
        public List<Camion> Leer()
        {
            List<Camion> listaDeCamiones = new List<Camion>();
            string command = "SELECT * FROM Camion";
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
                ETipoCamion tipo = (ETipoCamion)reader["ETIPO"];
                Camion camion = new Camion(patente, marca, horaIngreso, valorHora, tipo);

                listaDeCamiones.Add(camion);
            }
            conexionSql.Close();
            return listaDeCamiones;
        }
        public Camion LeerPorId(int id)
        {
            string command = "SELECT * FROM Camion WHERE ID = @id";
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
                ETipoCamion tipo = (ETipoCamion)reader["ETIPO"];
                Camion camion = new Camion(patente, marca, horaIngreso, valorHora, tipo);
                conexionSql.Close();
                return camion;

            }
            conexionSql.Close();
            return null;
        }
        public bool Modificar(Camion camion)
        {
            string command = "UPDATE Camion SET Camion.PATENTE = @patente, Camion.MARCA = @marca, Camion.VALOR_HORA = @valor_hora, Camion.ETIPO = @etipo" +
                " WHERE Camion.ID = @id";
            conexionSql.Open();
            SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
            sqlCommand.Parameters.AddWithValue("id", camion.Id);
            sqlCommand.Parameters.AddWithValue("patente", camion.Patente);
            sqlCommand.Parameters.AddWithValue("marca", camion.Marca);
            sqlCommand.Parameters.AddWithValue("valor_hora", camion.ValorHora);
            sqlCommand.Parameters.AddWithValue("etipo", camion.Tipo);
            int resultadoExecuteNonQuery = sqlCommand.ExecuteNonQuery();

            if (resultadoExecuteNonQuery > 0)
            {
                conexionSql.Close();
                return true;
            }
            conexionSql.Close();
            return false;
        }
        public bool Eliminar(Camion camion)
        {
            string command = "DELETE FROM Camion WHERE ID = @id";
            conexionSql.Open();
            SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
            sqlCommand.Parameters.AddWithValue("id", camion.Id);
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
