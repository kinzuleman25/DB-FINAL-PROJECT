using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.SqlServer.Server;
using System.Windows;
using System.Windows.Navigation;

namespace WpfApp6
{
    public partial class dashboard : Window
    {
        // Properties for Charts
        public ChartValues<double> RevenueValues { get; set; }
        public ChartValues<double> CompletedProjects { get; set; }
        public ChartValues<double> InProgressProjects { get; set; }
        public ChartValues<double> PendingProjects { get; set; }
        public ChartValues<double> OrdersValues { get; set; }

        public dashboard()
        {
            InitializeComponent();

            // Initialize Bar Chart Data (Revenue per Month)
            RevenueValues = new ChartValues<double> { 50000, 70000, 80000, 60000, 90000 };

            // Initialize Pie Chart Data (Project Status)
            CompletedProjects = new ChartValues<double> { 30 };  // 30 Completed Projects
            InProgressProjects = new ChartValues<double> { 15 }; // 15 In Progress
            PendingProjects = new ChartValues<double> { 5 };     // 5 Pending Projects

            // Initialize Line Chart Data (Orders per Month)
            OrdersValues = new ChartValues<double> { 120, 150, 100, 130, 160 };

            // Set DataContext for Data Binding
            DataContext = this;
        }
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            dashboard dashboardWindow = new dashboard();
            dashboardWindow.Show();
            this.Close(); // Optional: Close the current window if needed
        }
        private void ManageProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            manage_projects manageProjectsWindow = new manage_projects();
            manageProjectsWindow.Show();
            this.Close(); // Close current window if needed
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




