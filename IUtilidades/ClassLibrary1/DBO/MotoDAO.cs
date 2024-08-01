using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1.DBO
{
    public class MotoDAO
    {
        private SqlConnection conexionSql;

        public MotoDAO()
        {
            DBConnection instanciaSingleton = DBConnection.GetInstance();
            conexionSql = instanciaSingleton.GetConnection();
        }
        public bool Guardar(Moto moto)
        {
            bool retorno = false;
            try
            {
                string command = "INSERT INTO Moto(ID, PATENTE, MARCA, HORA_INGRESO, HORA_EGRESO, VALOR_HORA, ETIPO) "
                + $"VALUES(@id, @patente, @marca, @hora_ingreso, @hora_egreso, @valor_hora, @etipo)";
                SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
                sqlCommand.Parameters.AddWithValue("id", moto.Id);
                sqlCommand.Parameters.AddWithValue("patente", moto.Patente);
                sqlCommand.Parameters.AddWithValue("marca", moto.Marca);
                sqlCommand.Parameters.AddWithValue("hora_ingreso", moto.HoraIngreso);
                sqlCommand.Parameters.AddWithValue("hora_egreso", moto.HoraEgreso);
                sqlCommand.Parameters.AddWithValue("valor_hora", moto.ValorHora);
                sqlCommand.Parameters.AddWithValue("etipo", moto.Tipo);
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
        public List<Moto> Leer()
        {
            List<Moto> listaDeMotos = new List<Moto>();
            string command = "SELECT * FROM Moto";
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
                ETipoMoto tipo = (ETipoMoto)reader["ETIPO"];
                Moto moto = new Moto(patente, marca, horaIngreso, valorHora, tipo);

                listaDeMotos.Add(moto);
            }
            conexionSql.Close();
            return listaDeMotos;
        }
        public Moto LeerPorId(int id)
        {
            string command = "SELECT * FROM Moto WHERE ID = @id";
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
                ETipoMoto tipo = (ETipoMoto)reader["ETIPO"];
                Moto moto = new Moto(patente, marca, horaIngreso, valorHora, tipo);
                conexionSql.Close();
                return moto;

            }
            conexionSql.Close();
            return null;
        }
        public bool Modificar(Moto moto)
        {
            string command = "UPDATE Moto SET Moto.PATENTE = @patente, Moto.MARCA = @marca, Moto.VALOR_HORA = @valor_hora, Moto.ETIPO = @etipo" +
                " WHERE Moto.ID = @id";
            conexionSql.Open();
            SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
            sqlCommand.Parameters.AddWithValue("id", moto.Id);
            sqlCommand.Parameters.AddWithValue("patente", moto.Patente);
            sqlCommand.Parameters.AddWithValue("marca", moto.Marca);
            sqlCommand.Parameters.AddWithValue("valor_hora", moto.ValorHora);
            sqlCommand.Parameters.AddWithValue("etipo", moto.Tipo);
            int resultadoExecuteNonQuery = sqlCommand.ExecuteNonQuery();

            if (resultadoExecuteNonQuery > 0)
            {
                conexionSql.Close();
                return true;
            }
            conexionSql.Close();
            return false;
        }
        public bool Eliminar(Moto moto)
        {
            string command = "DELETE FROM Moto WHERE ID = @id";
            conexionSql.Open();
            SqlCommand sqlCommand = new SqlCommand(command, conexionSql);
            sqlCommand.Parameters.AddWithValue("id", moto.Id);
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
