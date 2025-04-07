using LiveCharts;
using LiveCharts.Wpf;
using System.Windows;

namespace WpfApp6
{
    public partial class project_history : Window
    {
        public ChartValues<int> CompletedOrders { get; set; }
        public ChartValues<int> PendingOrders { get; set; }
        public ChartValues<int> NewOrders { get; set; }
        public ChartValues<int> ProcessingOrders { get; set; }
        public ChartValues<int> CancelledOrders { get; set; }
        public ChartValues<int> DeliveredOrders { get; set; }

        public project_history()
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
            this.Show(); // Hide the dashboard instead of closing
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


