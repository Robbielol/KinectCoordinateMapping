using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KinectCoordinateMapping.DOAs
{

    class InsertNewExercise : DatabaseController, DOA
    {
        private DatabaseController conn;
        private String table, name, query, startInstruct, endInstruct, desc, type;
        private decimal duration;

        public InsertNewExercise(DatabaseController conn)
        {
            this.conn = conn;
        }

        public InsertNewExercise(String table, String exerciseName, DatabaseController conn, String strInstruct, String endInstruct, String desc, String type, decimal duration)
        {
            this.conn = conn;
            this.table = table;
            this.name = exerciseName;
            startInstruct = strInstruct;
            this.endInstruct = endInstruct;
            this.type = type;
            this.desc = desc;
            this.duration = duration;
        }

        public String CreateSQLQuery(int id)
        {
            query ="INSERT INTO " + table + "( Exercise_ID , Exercise_Name, Exercise_Type, Exercise_Description, Start_Pos_Instructions, End_Pos_Instructions, Duration)" +
                " VALUES (" + id + ", \"" + name + "\", \"" +type +"\", \"" +desc+ "\", \"" + startInstruct+ "\", \"" +endInstruct+ "\", " +duration+ "); ";
            return query;
        }

        public String CreateExisitingResultsQuery(int id)
        {
            query = "SELECT Exercise_Name, Exercise_ID FROM " + table + " WHERE Exercise_Name = \"" + name + "\";";
            return query;
        }

        public String GetSQLExerciseIDs()
        {
            query = "SELECT MAX(Exercise_ID) FROM exercises;";
            return query;
        }

        public MySqlDataReader ExecuteNonQuery(String sqlStatment)
        {
            if (sqlStatment == null)
            {
                throw new ArgumentNullException(nameof(sqlStatment));
            }

            return base.ExecuteNonQuery(sqlStatment);
        }

        public int RowsAffected => base.GetRowsAffected();

        public MySqlDataReader ExecuteQuery(String sqlStatment)
        {
            return base.ExecuteQuery(sqlStatment);
        }

        public void SetTableName(String tableName)
        {
            table = tableName;
        }

        public void SetTrainerName(String trainerName)
        {
            name = trainerName;
        }
        
       
    }
}
