using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Kinect;
using KinectCoordinateMapping.DOAs;
using MySql.Data.MySqlClient;

namespace KinectCoordinateMapping.PTlogic
{
    class UserPerformanceState
    {
        private KinectSensor sensor;
        private DatabaseController conn;
        private MySqlDataReader reader;
        private Canvas canvas;
        private Boolean startCompleted = false, endCompleted = false;
        private String startInstructions, endInstuctions, query;
        private Decimal duration;
        private int exId;
        private ExerciseMovements ex;
       
        public UserPerformanceState() { }

        public void SetUserBody(DatabaseController conn, int exerciseID, Canvas canvas, KinectSensor sensor)
        {
            this.sensor = sensor;
            this.canvas = canvas;
            exId = exerciseID;
            this.conn = conn;
            this.ex = new ExerciseMovements(conn, exerciseID, sensor);
            SetInstuctions();
        }


        public void SetUserJointsAngles(Body body)
        {
            ex.SetUserJointAngles(body);
        }

        public Boolean CheckStateOfExercise
        {
            get
            {
                if (!startCompleted)
                {
                    if (ex.Starting_T_Position(canvas, Colors.Blue, Brushes.Blue))
                    {
                        startCompleted = true;
                    }
                }
                return startCompleted;
            }
        }

        public Boolean CheckEndStateOfExercise
        {
            get
            {
                if (!endCompleted)
                {
                    if (ex.Finishing_T_Position(canvas, Colors.Green, Brushes.Blue))
                    {
                        endCompleted = true;
                    }
                }
                return endCompleted;
            }
        }

        public void SetInstuctions()
        {
            query = "SELECT Start_Pos_Instructions, End_Pos_Instructions, Duration FROM exercises WHERE Exercise_ID = " +exId+ ";";
            using (reader = conn.ExecuteQuery(query))
            {
                while (reader.Read())
                {
                    startInstructions = reader[0].ToString();
                    endInstuctions = reader[1].ToString();
                    duration = decimal.Parse(reader[2].ToString());
                }
            }
        }

        public string GetCurrentStateInstructions()
        {

            if (!startCompleted)
            {
                return startInstructions;
            }
            else
            {
                return endInstuctions;
            }
        }
        
        public decimal GetExerciseDuration()
        {
            return duration;
        }
    }
}
