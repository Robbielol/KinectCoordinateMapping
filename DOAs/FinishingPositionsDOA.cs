using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KinectCoordinateMapping.DOAs
{
    class FinishingPositionsDOA : DatabaseController, DOA
    {
        private readonly DatabaseController conn;
        private readonly String table = "finish_exercise_position";

        public FinishingPositionsDOA(DatabaseController conn)
        {
            this.conn = conn;
        }

        public new MySqlDataReader ExecuteQuery(String sqlStatment) => base.ExecuteQuery(sqlStatment);

        public String CreateSQLQuery(int ExerciseID)
        {
            return "SELECT * FROM " + table +  "WHERE exercise_ID =" + ExerciseID + ";";
        }

    }
}
