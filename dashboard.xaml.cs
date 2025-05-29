using LiveCharts;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Configuration;

namespace WpfApp6
{
    public partial class dashboard : Window
    {
        public ChartValues<double> RevenueValues { get; set; }
        public ChartValues<double> CompletedProjects { get; set; }
        public ChartValues<double> InProgressProjects { get; set; }
        public ChartValues<double> PendingProjects { get; set; }
        public ChartValues<double> OrdersValues { get; set; }

        public string TotalProjects { get; set; }
        public string PendingProjectsCount { get; set; }
        public string TotalClientsText { get; set; }

        public dashboard()
        {
            InitializeComponent();

            // Dummy data for charts
            RevenueValues = new ChartValues<double> { 10000, 15000, 20000 };
            CompletedProjects = new ChartValues<double> { 5 };
            InProgressProjects = new ChartValues<double> { 3 };
            PendingProjects = new ChartValues<double> { 2 };
            OrdersValues = new ChartValues<double> { 5, 8, 10 };

            // Fetch database values for summary labels
            LoadDashboardData();

            DataContext = this;
        }

        private void LoadDashboardData()
        {
            string connectionString = "server=localhost;user id=root;password=;database=software_company";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Total projects
                    string query1 = "SELECT COUNT(*) FROM projects";
                    MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                    TotalProjects = cmd1.ExecuteScalar().ToString();

                    // Pending projects
                    string query2 = "SELECT COUNT(*) FROM projects WHERE status = 'Pending'";
                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    PendingProjectsCount = cmd2.ExecuteScalar().ToString();

                    // Total clients
                    string query3 = "SELECT COUNT(DISTINCT client_id) FROM clients";
                    MySqlCommand cmd3 = new MySqlCommand(query3, connection);
                    TotalClientsText = cmd3.ExecuteScalar().ToString();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            new dashboard().Show();
            this.Close();
        }

        private void ManageProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            new manage_projects().Show();
            this.Close();
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            new inventory().Show();
            this.Close();
        }

        private void ProjectHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            new project_history().Show();
            this.Close();
        }

        private void PaymentManagmentButton_Click(object sender, RoutedEventArgs e)
        {
            new payment_managment().Show();
            this.Close();
        }

        private void OrderRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            new OrderRequests().Show();
            this.Close();
        }

        private void FeedbacksButton_Click(object sender, RoutedEventArgs e)
        {
            new feedbacks().Show();
            this.Close();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            new Profileowner().Show();
        }
    }
}


