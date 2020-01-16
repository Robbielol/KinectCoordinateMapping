using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Kinect;
using LightBuzz.Vitruvius;
using KinectCoordinateMapping.DOAs;
using KinectCoordinateMapping.Utilities;
using MySql.Data.MySqlClient;

namespace KinectCoordinateMapping.PTlogic
{
    public class ExerciseMovements
    {
        private KinectSensor sensor;
        private Body body;

        private StartingPositionsDOA startingPositions;
        private FinishingPositionsDOA finishingPositions;
        private String sqlQuery; 
        private MySqlDataReader sqlStartingResult, sqlFinishingResult;

        private Boolean bodyPos = false, leftArmPos = false, rightArmPos = false, leftLegPos = false, rightLegPos = false;

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
        private Joint handTipLeft;
        private Joint handTipRight;
        private Joint handThumbLeft;
        private Joint handThumbRight;
        private Joint leftHip;
        private Joint rightHip;
        private Joint leftKnee;
        private Joint rightKnee;
        private Joint leftAnkle;
        private Joint rightAnkle;
        private Joint rightFoot;
        private Joint leftFoot;

        //user angles
        private double user_neck_Angle;
        private double user_hozSpineShoulder_Angle;
        private double user_vertSpineShoulder_Angle;
        private double user_spineMid_Angle;
        private double user_spineBase_Angle;
        private double user_leftShoulder_Angle;
        private double user_rightShoulder_Angle;
        private double user_leftElbow_Angle;
        private double user_rightElbow_Angle;
        private double user_leftWrist_Angle;
        private double user_rightWrist_Angle;
        private double user_leftHip_Angle;
        private double user_rightHip_Angle;
        private double user_leftKnee_Angle;
        private double user_rightKnee_Angle;
        private double user_leftAnkle_Angle;
        private double user_rightAnkle_Angle;

        //trainers angles
        private List<double> trainer_neck_Angle = new List<double>();
        private List<double> trainer_hozSpineShoulder_Angle = new List<double>();
        private List<double> trainer_vertSpineShoulder_Angle = new List<double>();
        private List<double> trainer_spineMid_Angle = new List<double>();
        private List<double> trainer_spineBase_Angle = new List<double>();
        private List<double> trainer_leftShoulder_Angle = new List<double>();
        private List<double> trainer_rightShoulder_Angle = new List<double>();
        private List<double> trainer_leftElbow_Angle = new List<double>();
        private List<double> trainer_rightElbow_Angle = new List<double>();
        private List<double> trainer_leftWrist_Angle = new List<double>();
        private List<double> trainer_rightWrist_Angle = new List<double>();
        private List<double> trainer_leftHip_Angle = new List<double>();
        private List<double> trainer_leftKnee_Angle = new List<double>();
        private List<double> trainer_leftAnkle_Angle = new List<double>();
        private List<double> trainer_rightHip_Angle = new List<double>();
        private List<double> trainer_rightKnee_Angle = new List<double>();
        private List<double> trainer_rightAnkle_Angle = new List<double>();



        public ExerciseMovements(DatabaseController conn, int exerciseID, KinectSensor sensor)
        {
            this.sensor = sensor;

            startingPositions = new StartingPositionsDOA(conn);
            finishingPositions = new FinishingPositionsDOA(conn);

            sqlQuery = startingPositions.CreateSQLQuery(exerciseID);
            sqlStartingResult = startingPositions.ExecuteQuery(sqlQuery);

            sqlQuery = finishingPositions.CreateSQLQuery(exerciseID);
            sqlFinishingResult = finishingPositions.ExecuteQuery(sqlQuery);          
        } 

        public void SetUserJointAngles(Body body)
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
            handTipLeft = body.Joints[JointType.HandTipLeft];
            handTipRight = body.Joints[JointType.HandTipRight];
            handThumbLeft = body.Joints[JointType.ThumbLeft];
            handThumbRight = body.Joints[JointType.ThumbRight];
            leftHip = body.Joints[JointType.HipLeft];
            rightHip = body.Joints[JointType.HipRight];
            leftKnee = body.Joints[JointType.KneeLeft];
            rightKnee = body.Joints[JointType.KneeRight];
            leftAnkle = body.Joints[JointType.AnkleLeft];
            rightAnkle = body.Joints[JointType.AnkleRight];
            rightFoot = body.Joints[JointType.FootRight];
            leftFoot = body.Joints[JointType.FootLeft];

            //Setting angles user has executed
            user_neck_Angle = neck.Angle(head, spineShoulder);
            user_hozSpineShoulder_Angle = spineShoulder.Angle(leftShoulder, rightShoulder);
            user_vertSpineShoulder_Angle = spineShoulder.Angle(neck, spineMid);
            user_spineMid_Angle = spineMid.Angle(spineShoulder, spineBase);
            user_spineBase_Angle = spineBase.Angle(leftHip, rightHip);
            user_leftShoulder_Angle = leftShoulder.Angle(spineShoulder, leftElbow);
            user_rightShoulder_Angle = rightShoulder.Angle(spineShoulder, rightElbow);
            user_leftElbow_Angle = leftElbow.Angle(leftShoulder, leftWrist);
            user_rightElbow_Angle = rightElbow.Angle(rightShoulder, rightWrist);
            user_leftWrist_Angle = leftWrist.Angle(leftElbow, leftHand);
            user_rightWrist_Angle = rightWrist.Angle(rightElbow, rightHand);
            user_leftHip_Angle = leftHip.Angle(spineBase, leftKnee);
            user_rightHip_Angle = rightHip.Angle(spineBase, rightKnee);
            user_leftKnee_Angle = leftKnee.Angle(leftHip, leftAnkle);
            user_rightKnee_Angle = rightKnee.Angle(rightHip, rightAnkle);
            user_leftAnkle_Angle = leftAnkle.Angle(leftKnee, leftFoot);
            user_rightAnkle_Angle = rightAnkle.Angle(rightKnee, rightFoot);
        }
        
        public Boolean Starting_T_Position(Canvas canvas, Color color, SolidColorBrush brush)
        {
            //Setting angles trainer has executed
            SetTrainerAngles(sqlStartingResult);

            Boolean correctStart = false;

            //Head & Body
            if(user_neck_Angle <= trainer_neck_Angle.Max() && user_neck_Angle >= trainer_neck_Angle.Min())
            {
                canvas.DrawPoint(head, sensor, UserInterfaces.CameraMode.Color, brush);
                canvas.DrawLine(head, neck, sensor, color);

                if (user_vertSpineShoulder_Angle <= trainer_vertSpineShoulder_Angle.Max() && user_vertSpineShoulder_Angle >= trainer_vertSpineShoulder_Angle.Min())
                {
                    canvas.DrawPoint(neck, sensor, UserInterfaces.CameraMode.Color, brush);
                    canvas.DrawLine(neck, spineShoulder, sensor, color);

                    if (user_spineMid_Angle <= trainer_spineMid_Angle.Max() && user_spineMid_Angle >= trainer_spineMid_Angle.Min())
                    {
                        canvas.DrawPoint(spineShoulder, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawLine(spineShoulder, spineMid, sensor, color);

                        if (user_spineBase_Angle <= trainer_spineBase_Angle.Max() && user_spineBase_Angle >= trainer_spineBase_Angle.Min())
                        {
                            canvas.DrawPoint(spineMid, sensor, UserInterfaces.CameraMode.Color, brush);
                            canvas.DrawPoint(spineBase, sensor, UserInterfaces.CameraMode.Color, brush);
                            canvas.DrawLine(spineMid, spineBase, sensor, color);
                            bodyPos = true;
                        }
                    }
                }
            }

            //Left Arm
            if (user_leftShoulder_Angle <= trainer_leftShoulder_Angle.Max() && user_leftShoulder_Angle >= trainer_leftShoulder_Angle.Min())
            {
                canvas.DrawLine(spineShoulder, leftShoulder, sensor, color);

                if (user_leftElbow_Angle <= trainer_leftElbow_Angle.Max() && user_leftElbow_Angle >= trainer_leftElbow_Angle.Min())
                {
                    canvas.DrawPoint(leftShoulder, sensor, UserInterfaces.CameraMode.Color, brush);
                    canvas.DrawLine(leftShoulder, leftElbow, sensor, color);

                    if (user_leftWrist_Angle <= trainer_leftWrist_Angle.Max() && user_leftWrist_Angle >= trainer_leftWrist_Angle.Min()) 
                    {
                        canvas.DrawPoint(leftElbow, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(leftWrist, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(leftHand, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(handThumbLeft, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(handTipLeft, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawLine(leftElbow, leftWrist, sensor, color);
                        canvas.DrawLine(leftWrist, leftHand, sensor, color);
                        canvas.DrawLine(leftHand, handTipLeft, sensor, color);
                        canvas.DrawLine(leftHand, handThumbLeft, sensor, color);
                        leftArmPos = true;
                    }
                }
            }

            //Right Arm
            if (user_rightShoulder_Angle <= trainer_rightShoulder_Angle.Max() && user_rightShoulder_Angle >= trainer_rightShoulder_Angle.Min())
            {
                canvas.DrawLine(spineShoulder, rightShoulder, sensor, color);

                if (user_rightElbow_Angle <= trainer_rightElbow_Angle.Max() && user_rightElbow_Angle >= trainer_rightElbow_Angle.Min())
                {
                    canvas.DrawPoint(rightShoulder, sensor, UserInterfaces.CameraMode.Color, brush);
                    canvas.DrawLine(rightShoulder, rightElbow, sensor, color);

                    if (user_rightWrist_Angle <= trainer_rightWrist_Angle.Max() && user_rightWrist_Angle >= trainer_rightWrist_Angle.Min())
                    {
                        canvas.DrawPoint(rightElbow, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(rightWrist, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(rightHand, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(handTipRight, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(handThumbRight, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawLine(rightElbow, rightWrist, sensor, color);
                        canvas.DrawLine(rightWrist, rightHand, sensor, color);
                        canvas.DrawLine(rightHand, handTipRight, sensor, color);
                        canvas.DrawLine(rightHand, handThumbRight, sensor, color);
                        rightArmPos = true;
                    }
                }
            }

            //Right Leg
            if(user_rightHip_Angle <= trainer_rightHip_Angle.Max() && user_rightHip_Angle >= trainer_rightHip_Angle.Min())
            {
                canvas.DrawLine(spineBase, rightHip, sensor, color);

                if(user_rightKnee_Angle <= trainer_rightKnee_Angle.Max() && user_rightKnee_Angle >= trainer_rightKnee_Angle.Min())
                {
                    canvas.DrawPoint(rightHip, sensor, UserInterfaces.CameraMode.Color, brush);
                    canvas.DrawLine(rightHip, rightKnee, sensor, color);

                    if(user_rightAnkle_Angle <= trainer_rightAnkle_Angle.Max() && user_rightAnkle_Angle >= trainer_rightAnkle_Angle.Min())
                    {
                        canvas.DrawPoint(rightKnee, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(rightAnkle, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(rightFoot, sensor, UserInterfaces.CameraMode.Color, brush);

                        canvas.DrawLine(rightKnee, rightAnkle, sensor, color);
                        canvas.DrawLine(rightAnkle, rightFoot, sensor, color);
                        rightLegPos = true;
                    }
                }
            }

            //Left Leg
            if (user_leftHip_Angle <= trainer_leftHip_Angle.Max() && user_leftHip_Angle >= trainer_leftHip_Angle.Min())
            {
                canvas.DrawLine(spineBase, leftHip, sensor, color);

                if (user_leftKnee_Angle <= trainer_leftKnee_Angle.Max() && user_leftKnee_Angle >= trainer_leftKnee_Angle.Min())
                {
                    canvas.DrawPoint(leftHip, sensor, UserInterfaces.CameraMode.Color, brush);
                    canvas.DrawLine(leftHip, leftKnee, sensor, color);

                    if (user_leftAnkle_Angle <= trainer_leftAnkle_Angle.Max() && user_leftAnkle_Angle >= trainer_leftAnkle_Angle.Min())
                    {
                        canvas.DrawPoint(leftKnee, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(leftAnkle, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawPoint(leftFoot, sensor, UserInterfaces.CameraMode.Color, brush);
                        canvas.DrawLine(leftKnee, leftAnkle, sensor, color);
                        canvas.DrawLine(leftAnkle, leftFoot, sensor, color);
                        leftLegPos = true;
                    }
                }
            }

            if(leftLegPos && rightLegPos && rightArmPos && leftArmPos && bodyPos)
            {
                correctStart = true;
            }

            return correctStart;
        }

        public Boolean Finishing_T_Position(Canvas canvas, Color color, SolidColorBrush brush)
        {
            //Setting angles trainer has executed
            SetTrainerAngles(sqlFinishingResult);

            Boolean correctFinish = Starting_T_Position(canvas, color, brush);

            return correctFinish;
        }

        private void SetTrainerAngles(MySqlDataReader dataReader)
        {
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    trainer_neck_Angle.Add(dataReader.GetFloat("Neck_Angle"));
                    trainer_hozSpineShoulder_Angle.Add(dataReader.GetFloat("SpineShoulder_Hor_Angle"));
                    trainer_vertSpineShoulder_Angle.Add(dataReader.GetFloat("SpineShoulder_Vert_Angle"));
                    trainer_spineMid_Angle.Add(dataReader.GetFloat("SpineMid_Angle"));
                    trainer_spineBase_Angle.Add(dataReader.GetFloat("SpineBase_Angle"));
                    trainer_leftShoulder_Angle.Add(dataReader.GetFloat("LeftShoulder_Angle"));
                    trainer_rightShoulder_Angle.Add(dataReader.GetFloat("RightShoulder_Angle"));
                    trainer_leftElbow_Angle.Add(dataReader.GetFloat("LeftElbow_Angle"));
                    trainer_rightElbow_Angle.Add(dataReader.GetFloat("RightElbow_Angle"));
                    trainer_leftWrist_Angle.Add(dataReader.GetFloat("LeftWrist_Angle"));
                    trainer_rightWrist_Angle.Add(dataReader.GetFloat("RightWrist_Angle"));
                    trainer_leftHip_Angle.Add(dataReader.GetFloat("LeftHip_Angle"));
                    trainer_leftKnee_Angle.Add(dataReader.GetFloat("LeftKnee_Angle"));
                    trainer_leftAnkle_Angle.Add(dataReader.GetFloat("LeftAnkle_Angle"));
                    trainer_rightHip_Angle.Add(dataReader.GetFloat("RightHip_Angle"));
                    trainer_rightKnee_Angle.Add(dataReader.GetFloat("RightKnee_Angle"));
                    trainer_rightAnkle_Angle.Add(dataReader.GetFloat("RightAnkle_Angle"));
                }
            }
        }
    }
}