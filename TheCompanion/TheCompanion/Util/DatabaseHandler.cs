using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TheCompanion.Util
{
    public class DatabaseHandler
    {
        private MySqlConnection conn;

        public DatabaseHandler()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "Server=studmysql01.fhict.local;Uid=dbi408831;Database=dbi408831;Pwd=Thanos;";
        }

        public void OpenConnection()
        {
            conn.Open();
        }

        public void CloseConnection()
        {
            conn.Close();
        }

        public bool Login()
        {
            bool result;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM user";
            cmd.Connection = conn;

            result = (int)cmd.ExecuteScalar() > 0;

            return result;
        }
    }
}
