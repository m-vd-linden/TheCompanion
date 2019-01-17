using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TheCompanion.Classes;

namespace TheCompanion.Util
{
    public class DatabaseHandler
    {
        private MySqlConnection conn;

        public DatabaseHandler()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "Server=localhost;Uid=root;Pwd=root;Database=dbi408831;";
        }

        public void OpenConnection()
        {
            conn.Open();
        }

        public void CloseConnection()
        {
            conn.Close();
        }

        public Tuple<bool, int, string> Login(string username, string password)
        {
            bool result;
            MySqlCommand cmd = new MySqlCommand();
            Tuple<bool, int, string> tuple;
            int userID;
            string userName;

            cmd.CommandText = "SELECT COUNT(*) FROM user WHERE BINARY Username = @username && BINARY Password = @password";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);

            try
            {
                result = Convert.ToInt32(cmd.ExecuteScalar()) > 0;

                if (result)
                {
                    userID = GetUserID(username, password);
                    userName = GetUserName(userID);

                    tuple = Tuple.Create<bool, int, string>(result, userID, userName);
                }
                else
                {
                    tuple = Tuple.Create<bool, int, string>(false, 0, "");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                tuple = Tuple.Create<bool, int, string>(false, 0, "");
                result = false;
            }

            return tuple;
        }

        public int GetUserID(string username, string password)
        {
            int userID;

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"SELECT ID FROM user WHERE Username = @username AND Password = @password";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);

            userID = (int)cmd.ExecuteScalar();

            return userID;
        }

        public string GetUserName(int userID)
        {
            string userName;

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"SELECT Name FROM user WHERE ID = @id";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("id", userID);

            userName = cmd.ExecuteScalar().ToString();

            return userName;
        }

        public int GetNumOfRobots(string userID)
        {
            int result;
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM robot_user WHERE UserID = @id";
            cmd.Parameters.AddWithValue("id", userID);

            try
            {
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = 0;
            }

            return result;
        }

        public List<Robot> GetAllRobotsPerUser(int userID)
        {
            List<Robot> robots = new List<Robot>();
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = @"SELECT CONCAT_WS('^', robot.ID, Name) FROM robot INNER JOIN robot_user ON robot.ID = robot_user.ID WHERE robot_user.UserID = @id";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("id", userID);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string result = reader[i].ToString();
                    Robot robot = new Robot(Convert.ToInt32(result.Split('^')[0]), result.Split('^')[1]);

                    robots.Add(robot);
                }
            }
            return robots;
        }

        public List<Module> GetAllModulesForRobot(int robotID)
        {
            List<Module> modules = new List<Module>();
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = @"SELECT CONCAT_WS('^', module.Name, module.ScriptLocation) FROM module INNER JOIN robot_module ON module.ID = robot_module.ModuleID WHERE robot_module.RobotID = @id";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("id", robotID);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string result = reader[i].ToString();
                    Module module = new Module(result.Split('^')[0], result.Split('^')[1]);

                    modules.Add(module);
                }
            }

            return modules;
        }
    }
}
