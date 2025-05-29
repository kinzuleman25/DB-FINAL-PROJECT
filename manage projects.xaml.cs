using LiveCharts;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace WpfApp6
{
    public partial class manage_projects : Window
    {
        public ChartValues<double> CompletedProjects { get; set; }
        public ChartValues<double> InProgressProjects { get; set; }
        public ChartValues<double> PendingProjects { get; set; }

        public ObservableCollection<ProjectEntry> ProjectEntries { get; set; }

        public manage_projects()
        {
            InitializeComponent();
            LoadProjectStatistics();
            ProjectEntries = new ObservableCollection<ProjectEntry>();
            DataContext = this;
        }

        private void LoadProjectStatistics()
        {
            try
            {
                int completed = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM ongoing_projects WHERE Status = 'Completed'"));
                int inProgress = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM ongoing_projects WHERE Status = 'In Progress'"));
                int pending = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM ongoing_projects WHERE Status = 'Pending'"));

                CompletedProjects = new ChartValues<double> { completed };
                InProgressProjects = new ChartValues<double> { inProgress };
                PendingProjects = new ChartValues<double> { pending };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading project statistics: " + ex.Message);
                CompletedProjects = new ChartValues<double> { 0 };
                InProgressProjects = new ChartValues<double> { 0 };
                PendingProjects = new ChartValues<double> { 0 };
            }
        }

        private void SaveTasksButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var entry in ProjectEntries)
                {
                    if (!string.IsNullOrWhiteSpace(entry.Deadline) && entry.ClientId > 0)
                    {
                        string query = "INSERT INTO tasks (AssignedTasks, ClientId) VALUES (@AssignedTasks, @ClientId)";

                        var parameters = new Dictionary<string, object>
                {
                    { "@AssignedTasks", entry.Deadline },
                    { "@ClientId", entry.ClientId }
                };

                        DatabaseHelper.ExecuteNonQuery(query, parameters);
                    }
                }

                MessageBox.Show("Tasks saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ProjectEntries.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving tasks: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            dashboard dashboardWindow = new dashboard();
            dashboardWindow.Show();
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
            OrderRequests orderRequestsWindow = new OrderRequests();
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

    // Data Model for DataGrid
    public class ProjectEntry
    {
        public int ClientId { get; set; } // changed from string to int
        public string Deadline { get; set; } // Bound to Task column
    }
}
