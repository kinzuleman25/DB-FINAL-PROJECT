using System;
using System.Windows;
using WpfApp6;

namespace WpfApp6
{

    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open the Home window
                Home homeWindow = new Home();
                homeWindow.Show();

                // Optionally hide the About window

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Home Page: " + ex.Message);
            }
        }

        private void AboutUsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open the About window again (this might be unnecessary as you already are in About)
                About aboutWindow = new About();
                aboutWindow.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening About Page: " + ex.Message);
            }
        }



    }
}