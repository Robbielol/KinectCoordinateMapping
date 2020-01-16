using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace KinectCoordinateMapping.DOAs
{
    public class DatabaseController
    {
        private MySqlConnection conn = new MySqlConnection("server = localhost; user=root;database=personaltrainer;port=3306;password=;");
        private MySqlCommand cmd;
        private MySqlDataReader reader;
        private int rowsAffected;
        public DatabaseController()
        {
            if(conn.State != ConnectionState.Open)
            {
                MakeConnection();
            }
            else
            {
                Console.WriteLine("Connecton already Open!!");
            }
        }


        public void MakeConnection()
        {  
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("Connected");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Disconnected");
                Console.WriteLine(ex.ToString());
            }
        }

        public MySqlDataReader ExecuteQuery(String sqlStatement)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = sqlStatement;
            reader = cmd.ExecuteReader();
            
                return reader;       
        }

        public MySqlDataReader ExecuteNonQuery(String sqlStatement)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = sqlStatement;
            using (reader)
            {
                rowsAffected = cmd.ExecuteNonQuery();
                return reader;
            }
        }

        public int GetRowsAffected()
        {
            return rowsAffected;
        }
    }
}
