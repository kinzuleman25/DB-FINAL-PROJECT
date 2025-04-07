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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp6;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SubmitFeedback_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for your feedback!", "Submission Successful", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Optional: Add logic if needed
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            home1 homeWindow = new home1();
            homeWindow.Show();

            this.Close();
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