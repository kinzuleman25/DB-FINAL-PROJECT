using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Data;
using System.Windows;

namespace WpfApp6
{
    public partial class project_history : Window
    {
        // Dummy chart data for pie charts
        public ChartValues<int> CompletedOrders { get; set; }
        public ChartValues<int> PendingOrders { get; set; }

        public ChartValues<int> NewOrders { get; set; }
        public ChartValues<int> ProcessingOrders { get; set; }

        public ChartValues<int> CancelledOrders { get; set; }
        public ChartValues<int> DeliveredOrders { get; set; }

        // Real data from DB for DataGrid
        public DataTable OrdersList { get; set; }

        public project_history()
        {
            try
            {
                InitializeComponent();

                // Set dummy values for pie charts
                CompletedOrders = new ChartValues<int> { 15 };
                PendingOrders = new ChartValues<int> { 7 };

                NewOrders = new ChartValues<int> { 10 };
                ProcessingOrders = new ChartValues<int> { 6 };

                CancelledOrders = new ChartValues<int> { 2 };
                DeliveredOrders = new ChartValues<int> { 18 };

                // Load real project data from the database
                OrdersList = LoadProjectData();

                DataContext = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup error: {ex.Message}");
            }
        }

        // ✅ Keeps loading table from database
        private DataTable LoadProjectData()
        {
            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT ClientId, ProjectId, Status, StartDate, EndDate, Budget FROM projects";
                dt = DatabaseHelper.ExecuteQuery(query);

                dt.Columns.Add("SNo", typeof(int)); // Add serial number column

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["SNo"] = i + 1;
                }

                dt.Columns["SNo"].SetOrdinal(0); // Move SNo to the first column
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }

            return dt;
        }

        // Navigation Button Handlers
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
            // Already on this page
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
