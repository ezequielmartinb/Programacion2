using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PersonaDAO
    {
        private SqlConnection sqlConnection;
        public PersonaDAO()
        {
            DBConnection singletonInstance = DBConnection.GetInstance();
            this.sqlConnection = singletonInstance.GetConnection();
        }

        public bool Guardar(Persona persona)
        {
            bool retorno = false;
            try
            {
                string command = "INSERT INTO Persona(NOMBRE, APELLIDO) " + $"VALUES(@nombre, @apellido)";
                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("nombre", persona.Nombre);
                sqlCommand.Parameters.AddWithValue("apellido", persona.Apellido);
                this.sqlConnection.Open();
                retorno = true;
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (this.sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();                    
                }
            }
            return retorno;
        }
        public List<Persona> Leer()
        {
            List<Persona> listaAux = new List<Persona>();
            string command = "SELECT * FROM Persona";
            this.sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["id"];
                string nombre = (string)reader["nombre"];
                string apellido = (string)reader["apellido"];
                Persona persona = new Persona(id, nombre, apellido);
                listaAux.Add(persona);
            }
            this.sqlConnection.Close();
            return listaAux;
        }
        public Persona LeerPorId(int id)
        {
            string command = "SELECT * FROM Persona WHERE id = @id";
            this.sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                string nombre = (string)reader["nombre"];
                string apellido = (string)reader["apellido"];
                Persona persona = new Persona(id, nombre, apellido);
                this.sqlConnection.Close();
                return persona;
            }
            this.sqlConnection.Close();

            return null;
        }
        public bool Modificar(Persona persona)
        {
            string command = "UPDATE Persona SET Persona.NOMBRE = @nombre, Persona.APELLIDO = @apellido WHERE Persona.ID = @id";
            this.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.Parameters.AddWithValue("id", persona.Id);
            sqlCommand.Parameters.AddWithValue("nombre", persona.Nombre);
            sqlCommand.Parameters.AddWithValue("apellido", persona.Apellido);
            int resultadoExecuteNonQuery = sqlCommand.ExecuteNonQuery();
            if (resultadoExecuteNonQuery > 0)
            {
                this.sqlConnection.Close();
                return true;
            }
            this.sqlConnection.Close();
            return false;
        }
        public bool Eliminar(Persona persona)
        {
            string command = "DELETE FROM Persona WHERE ID = @id";
            this.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.Parameters.AddWithValue("id", persona.Id);
            int resultadoExecuteNonQuery = sqlCommand.ExecuteNonQuery();
            if (resultadoExecuteNonQuery > 0)
            {
                this.sqlConnection.Close();
                return true;
            }
            this.sqlConnection.Close();
            return false;
        }

    }
}
