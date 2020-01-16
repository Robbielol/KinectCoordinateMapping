using System;
using System.Collections.Generic;
using System.Windows;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using KinectCoordinateMapping.DOAs;
using MySql.Data.MySqlClient;

namespace KinectCoordinateMapping.UserInterfaces
{
    public partial class PerformExerciseForm : Form
    {
        private DatabaseController conn;
        private MainWindow main;
        private RoutedEventArgs eventArgs;
        private MySqlDataReader reader;
        private String query, workoutType;
        private Button exerciseButton;
        private int buttonLocation = 10, exerciseID;
        private GetExercises getExercises;
        private List<Button> allExercisesNames= new List<Button>();
        private List<int> allExercisesID = new List<int>();
        private List<String> allExerciseTypes = new List<String>();
        private List<String> allExerciseDesc = new List<String>();

        public PerformExerciseForm(DatabaseController conn, MainWindow main, RoutedEventArgs e)
        {
            this.conn = conn;
            eventArgs = e;
            this.main = main;
            getExercises = new GetExercises(conn);
            query = getExercises.GetAllExercises();   //Integer is not used here
            reader = getExercises.ExecuteQuery(query);
            InitializeComponent();
            AllExercisesAsButtons();
        }

        private void PerformButton_Click(object sender, EventArgs e)
        {
            Hide();
            main.SetRecordOrPerform(false);
            main.SetExerciseID(exerciseID);
            main.Window_Loaded(sender, eventArgs);
        }

        private void AllExercisesAsButtons()
        {
            while (reader.Read())
            {
                exerciseButton = new Button();
                exerciseButton.Name = reader[1].ToString();
                exerciseButton.Text = reader[1].ToString();
                exerciseButton.Click += myEventHandler;              
                exerciseButton.Location = new System.Drawing.Point(10, buttonLocation);
                buttonLocation += 40;
                ExercisePanel.Controls.Add(exerciseButton);
                allExercisesID.Add(int.Parse(reader[0].ToString()));
                allExercisesNames.Add(exerciseButton);
                allExerciseTypes.Add(reader[2].ToString());
                allExerciseDesc.Add(reader[3].ToString());           
            }
        }

        private void myEventHandler(object sender, EventArgs e)
        {
            string endImage = "", startImage = "";
            listView1.Items.Clear();
            Button button = sender as Button;
            int idx = allExercisesNames.IndexOf(button);
            exerciseID = allExercisesID[idx];
            string[] filePaths = Directory.GetFiles(@"Images\");
            foreach (string str in filePaths)
            {
                if (str.Contains(exerciseID + "End"))
                {
                    endImage = str;
                }
                else if (str.Contains(exerciseID + "Start"))
                {
                    startImage = str;
                }

            }
            startPosPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            endPosPictBox.SizeMode = PictureBoxSizeMode.Zoom;
            if (startImage != "" && endImage != "")
            {
                startPosPicBox.Image = Image.FromFile(startImage);
                endPosPictBox.Image = Image.FromFile(endImage);
            }
            AddWorkoutType(allExerciseTypes[idx], allExerciseDesc[idx]);
        }

        //NEED TO DO: add a picture or video how the exercise is performed    

        private void AddWorkoutType(String type, String desc)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add("c");
            listView1.Items.Add(item);
            listView1.Items[0].SubItems[0].Text = desc;
            listView1.Items[0].SubItems[1].Text = type;
        }

        private Image ToImage(String path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);
           
            return img;
        }


    }
}