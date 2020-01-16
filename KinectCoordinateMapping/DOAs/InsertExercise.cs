using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KinectCoordinateMapping.DOAs
{
    class InsertExercise : DatabaseController, DOA
    {
        DatabaseController conn;
        private String tableName;
        private List<double> exerciseEntry;
        private int trainerID;
        public InsertExercise(String tableN, List<double> exEntry, DatabaseController conn, int id)
        {
            this.conn = conn;
            trainerID = id;
            tableName = tableN;
            exerciseEntry = exEntry;
        }

        public String CreateSQLQuery(int ExerciseID)
        {
            String query;
            query = "INSERT INTO " + tableName + "(Exercise_ID, Personal_Trainer_ID, Neck_Angle, SpineShoulder_Vert_Angle, SpineShoulder_Hor_Angle, SpineMid_Angle, SpineBase_Angle, LeftShoulder_Angle, LeftElbow_Angle, LeftWrist_Angle, RightShoulder_Angle, RightElbow_Angle, RightWrist_Angle, LeftHip_Angle, LeftKnee_Angle, LeftAnkle_Angle, RightHip_Angle, RightKnee_Angle, RightAnkle_Angle)" +
                " VALUES (" +ExerciseID+ ", " +trainerID+ "," +Convert.ToInt32(exerciseEntry[0])+ ", " + Convert.ToInt32(exerciseEntry[1]) + ", " + Convert.ToInt32(exerciseEntry[2]) + ", " + Convert.ToInt32(exerciseEntry[3]) + ", " + Convert.ToInt32(exerciseEntry[4]) + ", " + Convert.ToInt32(exerciseEntry[5]) + ", " + Convert.ToInt32(exerciseEntry[6]) + ", " + Convert.ToInt32(exerciseEntry[7]) + ", " + Convert.ToInt32(exerciseEntry[8]) + ", " + Convert.ToInt32(exerciseEntry[9]) + ", " + Convert.ToInt32(exerciseEntry[10]) + ", " + Convert.ToInt32(exerciseEntry[11]) + ", " + Convert.ToInt32(exerciseEntry[12]) + ", " + Convert.ToInt32(exerciseEntry[13]) + ", " + Convert.ToInt32(exerciseEntry[14]) + ", " + Convert.ToInt32(exerciseEntry[15]) + ", " + Convert.ToInt32(exerciseEntry[16]) + ");";
            return query;
        }

        public MySqlDataReader ExecuteQuery(String sqlStatment)
        {
            if (sqlStatment == null)
            {
                throw new ArgumentNullException(nameof(sqlStatment));
            }

            return base.ExecuteNonQuery(sqlStatment);
        }

        public int RowsAffected => base.GetRowsAffected();
    }
}
