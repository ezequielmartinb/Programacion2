using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClassLibrary.DAO
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
