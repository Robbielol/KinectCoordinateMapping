using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LightBuzz.Vitruvius;
using KinectCoordinateMapping.UserInterfaces;


namespace KinectCoordinateMapping.Utilities
{
    public static class Extensions
    { 

        #region Drawing

        public static void DrawSkeleton(this Canvas canvas, Body body, KinectSensor sensor, CameraMode _mode)
        {
            if (body == null) return;

            foreach (Joint joint in body.Joints.Values)
            {
                canvas.DrawPoint(joint, sensor, _mode, Brushes.Red);
            }
            
            canvas.DrawLine(body.Joints[JointType.Head], body.Joints[JointType.Neck], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.Neck], body.Joints[JointType.SpineShoulder], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.SpineShoulder], body.Joints[JointType.ShoulderLeft], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.SpineShoulder], body.Joints[JointType.ShoulderRight], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.SpineShoulder], body.Joints[JointType.SpineMid], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.ShoulderLeft], body.Joints[JointType.ElbowLeft], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.ShoulderRight], body.Joints[JointType.ElbowRight], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.ElbowLeft], body.Joints[JointType.WristLeft], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.ElbowRight], body.Joints[JointType.WristRight], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.WristLeft], body.Joints[JointType.HandLeft], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.WristRight], body.Joints[JointType.HandRight], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.HandLeft], body.Joints[JointType.HandTipLeft], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.HandRight], body.Joints[JointType.HandTipRight], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.HandLeft], body.Joints[JointType.ThumbLeft], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.HandRight], body.Joints[JointType.ThumbRight], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.SpineMid], body.Joints[JointType.SpineBase], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.SpineBase], body.Joints[JointType.HipLeft], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.SpineBase], body.Joints[JointType.HipRight], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.HipLeft], body.Joints[JointType.KneeLeft], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.HipRight], body.Joints[JointType.KneeRight], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.KneeLeft], body.Joints[JointType.AnkleLeft], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.KneeRight], body.Joints[JointType.AnkleRight], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.AnkleLeft], body.Joints[JointType.FootLeft], sensor, Colors.Red);
            canvas.DrawLine(body.Joints[JointType.AnkleRight], body.Joints[JointType.FootRight], sensor, Colors.Red);
            
        }

        public static void DrawPoint(this Canvas canvas, Joint joint, KinectSensor sensor, CameraMode _mode, SolidColorBrush brush)
        {
            if (joint.TrackingState == TrackingState.Tracked)
            {
                CameraSpacePoint jointPosition = joint.Position;
                Point point = new Point();

                if (_mode == CameraMode.Color)
                {
                    ColorSpacePoint colorPoint = sensor.CoordinateMapper.MapCameraPointToColorSpace(jointPosition);

                    point.X = float.IsInfinity(colorPoint.X) ? 0 : colorPoint.X;
                    point.Y = float.IsInfinity(colorPoint.Y) ? 0 : colorPoint.Y;

                }
                else if (_mode == CameraMode.Depth || _mode == CameraMode.Infrared) // Change the Image and Canvas dimensions to 512x424
                {
                    DepthSpacePoint depthPoint = sensor.CoordinateMapper.MapCameraPointToDepthSpace(jointPosition);

                    point.X = float.IsInfinity(depthPoint.X) ? 0 : depthPoint.X;
                    point.Y = float.IsInfinity(depthPoint.Y) ? 0 : depthPoint.Y;
                }

                // Draw
                Ellipse ellipse = new Ellipse
                {
                    Fill = brush,
                    Width = 20,
                    Height = 20
                };

                Canvas.SetLeft(ellipse, point.X - ellipse.Width / 2);
                Canvas.SetTop(ellipse, point.Y - ellipse.Height / 2);

                canvas.Children.Add(ellipse);
            }
        }

        public static void DrawLine(this Canvas canvas, Joint first, Joint second, KinectSensor sensor, Color color)
        {
            if (first.TrackingState == TrackingState.NotTracked || second.TrackingState == TrackingState.NotTracked) return;

            CameraSpacePoint jointPosition = first.Position;
            Point firstPoint = new Point();

            ColorSpacePoint colorPoint = sensor.CoordinateMapper.MapCameraPointToColorSpace(jointPosition);

            firstPoint.X = float.IsInfinity(colorPoint.X) ? 0 : colorPoint.X;
            firstPoint.Y = float.IsInfinity(colorPoint.Y) ? 0 : colorPoint.Y;

            jointPosition = second.Position;
            Point secondPoint = new Point();

            colorPoint = sensor.CoordinateMapper.MapCameraPointToColorSpace(jointPosition);

            secondPoint.X = float.IsInfinity(colorPoint.X) ? 0 : colorPoint.X;
            secondPoint.Y = float.IsInfinity(colorPoint.Y) ? 0 : colorPoint.Y;

            Line line = new Line
            {
                X1 = firstPoint.X,
                Y1 = firstPoint.Y,
                X2 = secondPoint.X,
                Y2 = secondPoint.Y,
                StrokeThickness = 8,
                Stroke = new SolidColorBrush(color)
            };
            
            canvas.Children.Add(line);
        }

        #endregion
    }
}
