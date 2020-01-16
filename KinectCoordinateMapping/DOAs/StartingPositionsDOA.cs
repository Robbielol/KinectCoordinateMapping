using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KinectCoordinateMapping.DOAs
{
    class StartingPositionsDOA : DatabaseController, DOA
    {
        private readonly DatabaseController conn;
        private readonly String table = "start_exercise_position";

        public StartingPositionsDOA(DatabaseController conn)
        {
            this.conn = conn;
        }

        public MySqlDataReader ExecuteQuery(String sqlStatment)
        {
            return base.ExecuteQuery(sqlStatment);
        }

        public String CreateSQLQuery(int ExerciseID)
        {
            return "SELECT * FROM " + table + " WHERE exercise_ID = " + ExerciseID + ";";  
        }
    }
}
