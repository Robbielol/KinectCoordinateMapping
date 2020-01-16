using System;
using System.Windows;
using System.Windows.Forms;
using KinectCoordinateMapping.DOAs;

namespace KinectCoordinateMapping.UserInterfaces
{
    public partial class MenuWindow : Form
    {
        private MainWindow main;
        private RoutedEventArgs eventArgs;
        private DatabaseController conn;
        private Boolean record, perform;
        private AddExerciseForm addExercise;
        private PerformExerciseForm performExercise;

        public MenuWindow(DatabaseController conn, MainWindow main, RoutedEventArgs e)
        {
            eventArgs = e;
            this.conn = conn;
            this.main = main;
            InitializeComponent();
        }

        private void RecordExerciseButton_Click(object sender, EventArgs e)
        {
            record = true;
            perform = false;
            addExercise = new AddExerciseForm(conn, main, eventArgs);
            Hide();
            addExercise.Show();
        }

        private void PerformExerciseButton_Click(object sender, EventArgs e)
        {
            perform = true;
            record = false;
            performExercise = new PerformExerciseForm(conn, main, eventArgs);
            Hide();
            performExercise.Show();
        }

        public Boolean GetRecordButtonState()
        {
            return record;
        }

        public Boolean GetPerfromButtonState()
        {
            return perform;
        }
    }
}
