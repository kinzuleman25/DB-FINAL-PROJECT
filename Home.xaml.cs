using System;
using System.Windows;
using System.Windows.Controls;
using ScottPlot.Plottables;
using ScottPlot;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Home button logic (if needed)
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open the Login window
                Login loginWindow = new Login();
                loginWindow.Show();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Login Page: " + ex.Message);
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SignUp signupWindow = new SignUp();
                signupWindow.Show();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Sign Up Page: " + ex.Message);
            }
        }

        private void AboutUsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                About aboutWindow = new About();
                aboutWindow.Show();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening About Page: " + ex.Message);
            }
        }
      

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}