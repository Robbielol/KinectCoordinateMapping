using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KinectCoordinateMapping.DOAs
{

    class GetExercises : DatabaseController, DOA
    {
        private MySqlDataReader reader;
        private DatabaseController conn;

        public GetExercises(DatabaseController conn)
        {
            this.conn = conn; 
        }

        private MySqlDataReader ExecuteQuery(String sqlStat)
        {
            return base.ExecuteQuery(sqlStat);
        }

        public String CreateSQLQuery(int exerciseID)
        {
            return "SELECT * FROM exercises WHERE exercise_ID = " +exerciseID+ ";";
        }

        public String GetAllExercises()
        {
            return "SELECT * FROM exercises;";
        }

        public String GetDurationQuery(int id)
        {
            return "SELECT Duration FROM exercises WHERE exercise_ID = " + id + ";";
        }
    }
}
