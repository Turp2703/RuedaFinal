using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuedaFinal
{
    public class Conexion
    {
        static string server = "datasource=127.0.0.1";
        static string port = "port=3306";
        static string user = "username=root";
        static string pass = "pass=";
        static string db = "database=ruedafinal";

        public static MySqlConnection getConexion()
        {
            string conString = server + ";" + port + ";" + user + ";" + pass + ";" + db;
            return new MySqlConnection(conString);
        }
    }
}
