using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for inventory.xaml
    /// </summary>
    public partial class inventory : Window
    {
        // Property for Inventory Chart Data
        public ChartValues<double> StockValues { get; set; }

        public inventory()
        {
            InitializeComponent();

            // Initialize Inventory Chart Data (Stock Levels for Different Products)
            StockValues = new ChartValues<double> { 50, 80, 60, 30, 90 };

            // Set DataContext for Data Binding
            DataContext = this;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection changes in the DataGrid (if needed)
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
