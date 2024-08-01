using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DBO
{
    public class DBConnection
    {
        private static DBConnection instance; //singleton - Data Access Object

        private SqlConnection connection;

        private DBConnection()
        {
            connection = new SqlConnection(@"Server = .; Database = ESTACIONAMIENTO_DB; Trusted_Connection = True;");
        }

        public static DBConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
