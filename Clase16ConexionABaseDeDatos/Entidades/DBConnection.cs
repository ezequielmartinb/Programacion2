using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DBConnection
    {
        private static DBConnection instance; //singleton - Data Access Object

        private SqlConnection connection;

        private DBConnection()
        {
            this.connection = new SqlConnection(@"Server = .; Database = Persona; Trusted_Connection = True;");
        }

        public static DBConnection GetInstance()
        {
            if (DBConnection.instance == null)
            {
                DBConnection.instance = new DBConnection();
            }
            return instance;
        }

        public SqlConnection GetConnection()
        {
            return this.connection;
        }
    }
}
