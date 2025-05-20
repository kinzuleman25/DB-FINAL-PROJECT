using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Data;
using System.Windows;

namespace WpfApp6
{
    public partial class project_history : Window
    {
        public ChartValues<int> CompletedProjects { get; set; }
        public ChartValues<int> InProgressProjects { get; set; }
        public ChartValues<int> NotStartedProjects { get; set; }

        public DataTable OrdersList { get; set; } // ✅ For DataGrid binding
        public project_history()
        {
            try
            {
                InitializeComponent();

                CompletedProjects = new ChartValues<int> { GetProjectCountByStatus("Completed") };
                InProgressProjects = new ChartValues<int> { GetProjectCountByStatus("In Progress") };
                NotStartedProjects = new ChartValues<int> { GetProjectCountByStatus("Not Started") };

                OrdersList = LoadProjectData();
                DataContext = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup error: {ex.Message}");
            }
        }

       

        private int GetProjectCountByStatus(string status)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM projects WHERE Status = '{status}'";
                object result = DatabaseHelper.ExecuteScalar(query);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
                return 0;
            }
        }

        private DataTable LoadProjectData()
        {
            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT ClientId, ProjectId, Status, StartDate, EndDate, Budget FROM projects";
                dt = DatabaseHelper.ExecuteQuery(query);

                dt.Columns.Add("SNo", typeof(int)); // Add SNo column

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["SNo"] = i + 1;
                }

                dt.Columns["SNo"].SetOrdinal(0); // Move SNo to first column
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }

            return dt;
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
