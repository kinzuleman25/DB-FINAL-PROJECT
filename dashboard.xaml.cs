using LiveCharts;
using System.Windows;

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

        public object TotalRevenueText { get; private set; }
        public object TotalClientsText { get; private set; }
        public object TotalProjects { get; private set; }

        public dashboard()
        {
            InitializeComponent();

            // Initialize Chart Values
            RevenueValues = new ChartValues<double> { 10000, 15000, 20000 };
            CompletedProjects = new ChartValues<double> { 10, 12, 14 };
            InProgressProjects = new ChartValues<double> { 4, 3, 2 };
            PendingProjects = new ChartValues<double> { 1, 2, 3 };
            OrdersValues = new ChartValues<double> { 5, 8, 10 };

            // Initialize dashboard summary
            TotalRevenueText = "$45,000";
            TotalClientsText = "120";
            TotalProjects = "26";

            // Set DataContext for data binding in XAML
            DataContext = this;
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            dashboard dashboardWindow = new dashboard();
            dashboardWindow.Show();
            this.Close();
        }

        private void ManageProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            manage_projects manageProjectsWindow = new manage_projects();
            manageProjectsWindow.Show();
            this.Close();
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            inventory inventoryWindow = new inventory();
            inventoryWindow.Show();
            this.Close();
        }

        private void ProjectHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            project_history projectHistoryWindow = new project_history();
            projectHistoryWindow.Show();
            this.Close();
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
            profileWindow.Show();
        }
    }
}
