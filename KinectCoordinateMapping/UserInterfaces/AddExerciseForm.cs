using System;
using System.Windows;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinectCoordinateMapping.DOAs;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KinectCoordinateMapping.UserInterfaces
{
    public partial class AddExerciseForm : Form
    {
        private DatabaseController conn;
        private MainWindow main;
        private RoutedEventArgs e;
        private MySqlDataReader reader;
        private InsertNewExercise newExercise;
        private Boolean exsists = false, validForm = false, exExists = false;
        private int exerciseID, rowsAffected, trainerID = 0;
        private String exerciseName, trainerName, SQLQuery, exNamesQuery = "SELECT Exercise_Name FROM exercises;";
        private Regex rgx = new Regex("[^a-zA-Z]");

        private void endInstructionsLabel_Click(object sender, EventArgs e)
        {

        }

        private List<string> allExerciseNames = new List<string>();

        private void exercise_Textbox_TextChanged(object sender, EventArgs e)
        {
            exExsistLabel.Visible = false;
            exerciseName = exercise_Textbox.Text;
            trainerName = trainer_Textbox.Text;
            String temp = exerciseName;
            exerciseName = rgx.Replace(temp, "");
            exerciseName = exerciseName.ToLower();
            foreach (String ex in allExerciseNames)
            {
                if (exerciseName.Equals(ex))
                {
                    exExsistLabel.Text = "Exercise already exsists. Other text fields not required.";
                    exExsistLabel.Visible = true;
                    exExists = true;
                }
            }
        }


        public AddExerciseForm(DatabaseController conn, MainWindow main, RoutedEventArgs e)
        {
            newExercise = new InsertNewExercise(conn);
            this.e = e;
            this.main = main;
            this.conn = conn;
            reader = newExercise.ExecuteQuery(exNamesQuery);
            while (reader.Read())
            {
                allExerciseNames.Add(reader[0].ToString());               
            }
            InitializeComponent();
        }

        private void record_Button_Click(object sender, EventArgs eventArgs)
        {
            
            if(exerciseName == "")
            {
                exExsistLabel.Text = "Exercise Name must only contain alphabetic characters only.";
                exExsistLabel.Visible = true;
            }

            if ((startInstructBox.Text == "" || endInstructBox.Text == "" || workoutTypeBox.Text == "") && !exExists)
            {
                requiredLabel.Visible = true;
            }
            else 
            {
                newExercise = new InsertNewExercise("exercises", exerciseName, conn, startInstructBox.Text, endInstructBox.Text, descBox.Text, workoutTypeBox.Text, durationCounter.Value);
                SQLQuery = newExercise.GetSQLExerciseIDs();
                reader = newExercise.ExecuteQuery(SQLQuery);
                //gets largest exercise id and sets new
                try
                {
                    while (reader.Read())
                    {
                        exerciseID = reader.GetInt16(0) + 1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    exerciseID = 1;
                }
                reader.Close();

                //Checks if exercise exsists in db
                SQLQuery = newExercise.CreateExisitingResultsQuery(exerciseID);
                reader = newExercise.ExecuteQuery(SQLQuery);
                while (reader.Read())
                {
                    if (exerciseName.Equals(reader.GetString("Exercise_Name")))
                    {
                        exsists = true;
                        exerciseID = reader.GetInt32("Exercise_ID");
                    }
                }
                reader.Close();

                if (!exsists)
                {
                    //add new entry if doesnt exsist
                    SQLQuery = newExercise.CreateSQLQuery(exerciseID);
                    newExercise.ExecuteNonQuery(SQLQuery);
                }

                //Adds personal trainer
                newExercise.SetTableName("personal_trainer");
                newExercise.SetTrainerName(trainerName);
                SQLQuery = newExercise.GetSQLExerciseIDs();
                reader = newExercise.ExecuteQuery(SQLQuery);

                Hide();
                main.SetRecordOrPerform(true);
                main.SetExerciseID(exerciseID);
                main.SetTrainerID(trainerID);
                main.Window_Loaded(sender, e);
            }
        }

        public int GetExerciseID()
        {
            return exerciseID;
        }
    }

    //NEED TO DO: add trainer properly, & PT name to lower
}
