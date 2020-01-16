using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using KinectCoordinateMapping.DOAs;
using KinectCoordinateMapping.PTlogic;
using KinectCoordinateMapping.Utilities;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace KinectCoordinateMapping.UserInterfaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinectSensor _sensor;
        private MultiSourceFrameReader _reader;
        private IList<Body> _bodies;
        private ExerciseMovements ex;
        private String startTable = "start_exercise_position", finishTable = "finish_exercise_position";
        private Stopwatch time = new Stopwatch();
        private TimeSpan ts;
        private Boolean startCompleted = false, endCompleted = false, record = false, perform = false,  trainerPresent = false, userSetUp = false;
        private Boolean startPicTaken = false, endPicTaken = false;
        private UserPerformanceState ups = new UserPerformanceState();
        private RecordTrainers recordTrainers;
        private DatabaseController st;
        private MenuWindow menu;
        private RoutedEventArgs e;
        private int exerciseID, trainerID, completedReps;
        private String startPosPng, endPosPng;
        private long duration;
        private readonly int repsToDo = 5;
        

        CameraMode _mode = CameraMode.Color;

        public MainWindow() : this(0, 0)
        {
            InitializeComponent();

        }

        public MainWindow(int trainerID, int exID)
        {
            completedReps = 0;
            exerciseID = exID;
            this.trainerID = trainerID;
            st = new DatabaseController();
            st.MakeConnection();
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs routedEvent)
        {
            e = routedEvent;
            menu = new MenuWindow(st, this, e);


            if (exerciseID == 0)
            {
                Hide();
                menu.Show();
            }
           

            if (exerciseID != 0)
            {
                Show();
                _sensor = KinectSensor.GetDefault();
                if (_sensor != null)
                {
                    _sensor.Open();

                    _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Depth | FrameSourceTypes.Infrared | FrameSourceTypes.Body);
                    _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (_reader != null)
            {
                _reader.Dispose();
            }

            if (_sensor != null)
            {
                _sensor.Close();
            }
        }

        private void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs multSource)
        {


            if (trainerPresent && !startCompleted && !time.IsRunning)
            {
                time.Start();
            }

            if(startCompleted && !endCompleted && time.ElapsedMilliseconds == 0)
            {
                time.Start();
            }else if( startCompleted && endCompleted && completedReps < 3)
            {
                startCompleted = false;
                endCompleted = false;
                time.Reset();
            }
            



            var reference = multSource.FrameReference.AcquireFrame();

            // Color
            using (ColorFrame frame = reference.ColorFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    if (_mode == CameraMode.Color)
                    {
                        camera.Source = frame.ToBitmap();
                    }
                }
            }

            // Depth
            using (DepthFrame frame = reference.DepthFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    if (_mode == CameraMode.Depth)
                    {
                        camera.Source = frame.ToBitmap();
                    }
                }
            }

            // Infrared
            using (InfraredFrame frame = reference.InfraredFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    if (_mode == CameraMode.Infrared)
                    {
                        camera.Source = frame.ToBitmap();
                    }

                }
            }

            // Body
            using (BodyFrame frame = reference.BodyFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    int bodyCount = 0;
                    canvas.Children.Clear();

                    _bodies = new Body[frame.BodyFrameSource.BodyCount];

                    frame.GetAndRefreshBodyData(_bodies);

                    foreach (var body in _bodies)
                    {
                        if (body.IsTracked)
                        {
                            canvas.DrawSkeleton(body, _sensor, _mode);
                            
                            if (record && completedReps < repsToDo)
                            { 
                                trainerPresent = true;
                                if (time.ElapsedMilliseconds > 5000)
                                {
                                    Complete.Text = "GET READY!";
                                }
                                ts = time.Elapsed;
                                Timer.Text = ts.Seconds.ToString();
                                if(time.ElapsedMilliseconds >= 5000 && !startCompleted)
                                {
                                    Instructions.Text = "You have till 10 before recording";
                                }
                                else if(!startCompleted)
                                {
                                    Instructions.Text = "Get into your starting position";
                                }

                                if (ts.Seconds >= 10 && !startCompleted)
                                {
                                    if (!startPicTaken)
                                    {
                                        startPosPng = "Images\\" + exerciseID + "StartPositon.png";
                                        CreatePng(startPosPng, (BitmapSource)camera.Source);
                                        startPicTaken = true;
                                    }
                                    recordTrainers = new RecordTrainers(body, startTable, st, trainerID,  exerciseID);
                                    duration = (long)recordTrainers.GetDuration();
                                    recordTrainers.StorePointsInTable();
                                    time.Stop();
                                    time.Reset();  
                                    startCompleted = true;
                                    Complete.Text = "NOW, EXERCISE!";
                                    Instructions.Text = "Now, Execute a controlled repetition, slowly";
                                }
                                else if (startCompleted && !endCompleted)
                                {
                                    if (time.ElapsedMilliseconds >= duration)
                                    {
                                        if (!endPicTaken)
                                        {
                                            endPosPng = "Images\\" + exerciseID + "EndPositon.png";
                                            CreatePng(endPosPng, (BitmapSource) camera.Source);
                                            endPicTaken = true;
                                        }
                                        recordTrainers.SetBody(body);
                                        recordTrainers.SetTableName(finishTable);
                                        recordTrainers.StorePointsInTable();
                                        time.Stop();
                                        time.Reset();
                                        endCompleted = true;
                                        Instructions.Text = recordTrainers.GetInsertSQLResult();
                                        completedReps++;
                                        Complete.Text = "COMPLETED A REP";
                                    }
                                }
                               
                            }
                            else //perform
                            {
                                if (!userSetUp)
                                {
                                    ups.SetUserBody(st, exerciseID, canvas, _sensor);
                                    userSetUp = true;
                                }
                                ups.SetUserJointsAngles(body);
                                Instructions.Text = ups.GetCurrentStateInstructions();
                                startCompleted = ups.CheckStateOfExercise;
                                if (startCompleted)
                                {
                                    AdviceText.Text = "Good Start";
                                    endCompleted = ups.CheckEndStateOfExercise;
                                    if (endCompleted)
                                    {
                                        AdviceText2.Text = "Good Finish";

                                    }
                                    else
                                    {
                                        AdviceText2.Text = "Bad Finish";
                                    }
                                }
                                else
                                {
                                    AdviceText.Text = "Bad Start";
                                }
                            }
                        }
                        if(!body.IsTracked && trainerPresent)
                        {
                            bodyCount++; //counts number of bodies not being tracked
                        }
                        
                        if(bodyCount == _bodies.Count)
                        {
                            time.Stop();
                            trainerPresent = false;
                            Instructions.Text = "Please move in view of the camera";
                        }

                    }
                    
                }
            }

            if (time.ElapsedMilliseconds >= 11000)
            {
                time.Stop();
            }

            if (startCompleted && endCompleted && completedReps == repsToDo)
            {
                ExitWindow exitWindow = new ExitWindow(this, e);
                exitWindow.Show();
            }
        }

        private void CreatePng(string filename, BitmapSource image)
        {
            if (filename != string.Empty)
            {
                using (FileStream stream = new FileStream(filename, FileMode.Create))
                {
                    PngBitmapEncoder encoder5 = new PngBitmapEncoder();
                    encoder5.Frames.Add(BitmapFrame.Create(image));
                    encoder5.Save(stream);
                }
            }
        }

        public void SetRecordOrPerform(Boolean recOrPer)
        {
            if (!recOrPer)
            {
                perform = true;
                AdviceText.Visibility = Visibility.Visible;
                AdviceText2.Visibility = Visibility.Visible;
                Timer.Visibility = Visibility.Hidden;
                GreenRec.Visibility = Visibility.Visible;
                BlueRec.Visibility = Visibility.Visible;
                startLabel.Visibility = Visibility.Visible;
                finishLabel.Visibility = Visibility.Visible;
                Complete.Visibility = Visibility.Hidden;
            }
            else
            {
                record = true;
                Timer.Visibility = Visibility.Visible;
                Complete.Visibility = Visibility.Visible;
                AdviceText.Visibility = Visibility.Hidden;
                AdviceText2.Visibility = Visibility.Hidden;
                GreenRec.Visibility = Visibility.Hidden;
                BlueRec.Visibility = Visibility.Hidden;
                startLabel.Visibility = Visibility.Hidden;
                finishLabel.Visibility = Visibility.Hidden;
            }
        }
        
        public void SetExerciseID(int id)
        {
            exerciseID = id;
        }

        public void SetTrainerID(int id)
        {
            trainerID = id;
        }
       
    }
    

    public enum CameraMode
    {
        Color,
        Depth,
        Infrared
    }
}
//NEED TO DO: create better UI,
