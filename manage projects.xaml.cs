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
using LiveCharts.Wpf;

namespace WpfApp6
{
    
    public partial class manage_projects : Window
    {
        public ChartValues<double> CompletedProjects { get; set; }
        public ChartValues<double> InProgressProjects { get; set; }
        public ChartValues<double> PendingProjects { get; set; }
        
        public manage_projects()
        {
            InitializeComponent();
            CompletedProjects = new ChartValues<double> { 30 };  // 30 Completed Projects
            InProgressProjects = new ChartValues<double> { 15 }; // 15 In Progress
            PendingProjects = new ChartValues<double> { 5 };     // 5 Pending Projects
            DataContext = this;
        }
      
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            dashboard dashboardWindow = new dashboard();
            dashboardWindow.Show();
            this.Close (); // Optional: Close the current window if needed
        }
        

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            inventory inventoryWindow = new inventory();
            inventoryWindow.Show();
            this.Close(); // Close current window if needed
        }
        private void ProjectHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            project_history projectHistoryWindow = new project_history();
            projectHistoryWindow.Show();
            this.Close(); // Hide the dashboard instead of closing
        }

        private void PaymentManagmentButton_Click(object sender, RoutedEventArgs e)
        {
            payment_managment paymentWindow = new payment_managment();
            paymentWindow.Show();
            this.Close();
        }

        private void OrderRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            order_requests orderRequestsWindow = new order_requests();
            orderRequestsWindow.Show();
            this.Close();
        }

        private void FeedbacksButton_Click(object sender, RoutedEventArgs e)
        {
            feedbacks feedbacksWindow = new feedbacks();
            feedbacksWindow.Show();
            this.Close();
        }
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            Profileowner profileWindow = new Profileowner();
            profileWindow.Show(); // Opens the window

            // Optionally close the current window
            // this.Close();
        }
    }
}
