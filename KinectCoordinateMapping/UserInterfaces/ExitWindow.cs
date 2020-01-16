using System;
using System.Windows;
using System.Windows.Forms;
using KinectCoordinateMapping.DOAs;


namespace KinectCoordinateMapping.UserInterfaces
{
    public partial class ExitWindow : Form
    {
        private MainWindow main;
        private DatabaseController conn;
        private RoutedEventArgs e;


        public ExitWindow(MainWindow main, RoutedEventArgs e)
        { 
            this.e = e;
            this.main = main;
            InitializeComponent();
        }

        private void returnButton_Click(object sender, EventArgs eArgs)
        {
            main.Hide();
            Hide();
            MenuWindow menu = new MenuWindow(conn, main, e);
            menu.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            main.Close();
            this.Close();
        }
    }
}
