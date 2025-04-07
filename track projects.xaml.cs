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
using LiveCharts;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for track_projects.xaml
    /// </summary>
    public partial class track_projects : Window
    {
        public ChartValues<int> CompletedOrders { get; set; }
        public ChartValues<int> PendingOrders { get; set; }
        public ChartValues<int> NewOrders { get; set; }
        public ChartValues<int> ProcessingOrders { get; set; }
        public ChartValues<int> CancelledOrders { get; set; }
        public ChartValues<int> DeliveredOrders { get; set; }

        public track_projects()
        {
            InitializeComponent();
            // Sample Data
            CompletedOrders = new ChartValues<int> { 70 };
            PendingOrders = new ChartValues<int> { 30 };
            NewOrders = new ChartValues<int> { 40 };
            ProcessingOrders = new ChartValues<int> { 60 };
            CancelledOrders = new ChartValues<int> { 15 };
            DeliveredOrders = new ChartValues<int> { 85 };
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            home1 homeWindow = new home1();
            homeWindow.Show();

            this.Close();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            MainWindow feedbackWindow = new MainWindow(); // Create instance of feedback page
            feedbackWindow.Show(); // Show the feedback window
            this.Close(); // Optional: close the home window

        }
        private void MyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.Show();
            this.Close();
        }

    }
}
