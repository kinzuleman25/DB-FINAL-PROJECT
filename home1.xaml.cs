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
using static ScottPlot.Colors;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home1 : Window
    {
        public home1()
        {
            InitializeComponent();
        }
        private void ExploreWindows_Click(object sender, RoutedEventArgs e)
        {
            Windows windowsPage = new Windows();
            windowsPage.Show();
            this.Close();
        }

        private void ExploreDoors_Click(object sender, RoutedEventArgs e)
        {
            Doors doorsPage = new Doors();
            doorsPage.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                MainWindow feedbackWindow = new MainWindow(); // Create instance of feedback page
                feedbackWindow.Show(); // Show the feedback window
                this.Close(); // Optional: close the home window
            }
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