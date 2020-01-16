using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.Timers;
using KinectCoordinateMapping.DOAs;
using MySql.Data.MySqlClient;

using LightBuzz.Vitruvius;


namespace KinectCoordinateMapping
{
     public class RecordTrainers
     {
        private DatabaseController conn;
        private InsertExercise insert;
        private MySqlDataReader reader;
        private int trainerID, exerciseID;
        private String query;
        private List<double> newExerciseEntry = new List<double>();
        private String tableName;

        private Body body;
        private Joint head;
        private Joint neck;
        private Joint spineShoulder;
        private Joint spineMid;
        private Joint spineBase;
        private Joint leftShoulder;
        private Joint rightShoulder;
        private Joint leftElbow;
        private Joint rightElbow;
        private Joint leftWrist;
        private Joint rightWrist;
        private Joint leftHand;
        private Joint rightHand;
        private Joint leftHip;
        private Joint rightHip;
        private Joint leftKnee;
        private Joint rightKnee;
        private Joint leftAnkle;
        private Joint rightAnkle; 
        private Joint rightFoot;
        private Joint leftFoot;

        private double head_Angle;
        private double neck_Angle;
        private double hozSpineShoulder_Angle;
        private double vertSpineShoulder_Angle;
        private double spineMid_Angle;
        private double spineBase_Angle;
        private double leftShoulder_Angle;
        private double rightShoulder_Angle;
        private double leftElbow_Angle;
        private double rightElbow_Angle;
        private double leftWrist_Angle;
        private double rightWrist_Angle;
        private double leftHip_Angle;
        private double rightHip_Angle;
        private double leftKnee_Angle;
        private double rightKnee_Angle;
        private double leftAnkle_Angle;
        private double rightAnkle_Angle;


        public RecordTrainers(Body body, String tableName, DatabaseController conn, int id, int exerciseID)
        {
            this.conn = conn;
            this.exerciseID = exerciseID;
            trainerID = id;
            SetBody(body);
            this.tableName = tableName;
        }

        public void SetTableName(String tableName)
        {
            this.tableName = tableName;
        }

        public void SetBody(Body body)
        {
            this.body = body;
            head = body.Joints[JointType.Head];
            neck = body.Joints[JointType.Neck];
            spineShoulder = body.Joints[JointType.SpineShoulder];
            spineMid = body.Joints[JointType.SpineMid];
            spineBase = body.Joints[JointType.SpineBase];
            leftShoulder = body.Joints[JointType.ShoulderLeft];
            rightShoulder = body.Joints[JointType.ShoulderRight];
            leftElbow = body.Joints[JointType.ElbowLeft];
            rightElbow = body.Joints[JointType.ElbowRight];
            leftWrist = body.Joints[JointType.WristLeft];
            rightWrist = body.Joints[JointType.WristRight];
            leftHand = body.Joints[JointType.HandLeft];
            rightHand = body.Joints[JointType.HandRight];
            leftHip = body.Joints[JointType.HipLeft];
            rightHip = body.Joints[JointType.HipRight];
            leftKnee = body.Joints[JointType.KneeLeft];
            rightKnee = body.Joints[JointType.KneeRight];
            leftAnkle = body.Joints[JointType.AnkleLeft];
            rightAnkle = body.Joints[JointType.AnkleRight];
            rightFoot = body.Joints[JointType.FootRight];
            leftFoot = body.Joints[JointType.FootLeft];
            SetAngles();
        }

        public void SetAngles()
        {
            neck_Angle = neck.Angle(head, spineShoulder);
            vertSpineShoulder_Angle = spineShoulder.Angle(neck, spineMid);
            hozSpineShoulder_Angle = spineShoulder.Angle(leftShoulder, rightShoulder);
            spineMid_Angle = spineMid.Angle(spineShoulder, spineBase);
            spineBase_Angle = spineBase.Angle(leftHip, rightHip);
            leftShoulder_Angle = leftShoulder.Angle(spineShoulder, leftElbow);
            leftElbow_Angle = leftElbow.Angle(leftShoulder, leftWrist);
            leftWrist_Angle = leftWrist.Angle(leftElbow, leftHand);
            rightShoulder_Angle = rightShoulder.Angle(spineShoulder, rightElbow);
            rightElbow_Angle = rightElbow.Angle(rightShoulder, rightWrist);
            rightWrist_Angle = rightWrist.Angle(rightElbow, rightHand);
            leftHip_Angle = leftHip.Angle(spineBase, leftKnee);
            leftKnee_Angle = leftKnee.Angle(leftHip, leftAnkle);
            leftAnkle_Angle = leftAnkle.Angle(leftKnee, leftFoot);
            rightHip_Angle = rightHip.Angle(spineBase, rightKnee);
            rightKnee_Angle = rightKnee.Angle(rightHip, rightAnkle);
            rightAnkle_Angle = rightAnkle.Angle(rightKnee, rightFoot);
        }

        public void StorePointsInTable()
        {
            newExerciseEntry.Add(neck_Angle);
            newExerciseEntry.Add(vertSpineShoulder_Angle);
            newExerciseEntry.Add(hozSpineShoulder_Angle);
            newExerciseEntry.Add(spineMid_Angle);
            newExerciseEntry.Add(spineBase_Angle);
            newExerciseEntry.Add(leftShoulder_Angle);
            newExerciseEntry.Add(leftElbow_Angle);
            newExerciseEntry.Add(leftWrist_Angle);
            newExerciseEntry.Add(rightShoulder_Angle);
            newExerciseEntry.Add(rightElbow_Angle);
            newExerciseEntry.Add(rightWrist_Angle);
            newExerciseEntry.Add(leftHip_Angle);
            newExerciseEntry.Add(leftKnee_Angle);
            newExerciseEntry.Add(leftAnkle_Angle);
            newExerciseEntry.Add(rightHip_Angle);
            newExerciseEntry.Add(rightKnee_Angle);
            newExerciseEntry.Add(rightAnkle_Angle);

            insert = new InsertExercise(tableName, newExerciseEntry, conn, trainerID);
            query = insert.CreateSQLQuery(exerciseID);
            insert.ExecuteQuery(query);
        }

        public String GetInsertSQLResult()
        {
            int rowAffected;
            rowAffected = insert.GetRowsAffected();
            if(rowAffected <= 0)
            {
                return "Your exercise Entry was unsuccessful";
            }
            else
            {
                return rowAffected + " row(s) have been successfully added";
            }
        }

        public decimal GetDuration()
        {
            decimal duration=0;
            GetExercises getEx = new GetExercises(conn);
            String query;
            query = getEx.GetDurationQuery(exerciseID);
            reader = getEx.ExecuteQuery(query);
            while (reader.Read())
            {
                duration = decimal.Parse(reader[0].ToString());
            }
            return duration * 1000;
        }
     }
}
