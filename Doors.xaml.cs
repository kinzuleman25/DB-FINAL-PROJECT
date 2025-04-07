using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp6;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for Doors.xaml
    /// </summary>
    public partial class Doors : Window
    {
        public Doors()
        {
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            home1 homePage = new home1();
            homePage.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Orders orderPage = new Orders();
            orderPage.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Orders orderPage = new Orders();
            orderPage.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Orders orderPage = new Orders();
            orderPage.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            home1 homeWindow = new home1();
            homeWindow.Show();

            this.Close(); // Optional: close the current feedback window
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            MainWindow feedbackWindow = new MainWindow(); // Create instance of feedback page
            feedbackWindow.Show(); // Show the feedback window
            this.Close(); // Optional: close the home window

        }
        private void ProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            track_projects trackProjectsWindow = new track_projects();
            trackProjectsWindow.Show();
            this.Close();
        }
        private void MyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.Show();
             this.Close();
        }

    }
}