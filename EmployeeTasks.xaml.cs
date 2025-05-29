using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Collections.Generic;

namespace WpfApp6
{
    public partial class EmployeeTasks : Window
    {
        public ChartValues<double> CompletedTasks { get; set; }
        public ChartValues<double> AssignedTasks { get; set; }

        public EmployeeTasks()
        {
            InitializeComponent();
            LoadTaskStatistics();
            LoadAssignedTasks();
            LoadCompletedTasks();
            DataContext = this;
        }

        private void LoadTaskStatistics()
        {
            try
            {
                int completed = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM tasks WHERE Status = 'Completed'"));
                int assigned = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM tasks WHERE Status = 'Assigned'"));

                CompletedTasks = new ChartValues<double> { completed };
                AssignedTasks = new ChartValues<double> { assigned };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading task statistics: " + ex.Message);
            }
        }

        private void LoadAssignedTasks()
        {
            try
            {
                DataTable taskData = DatabaseHelper.ExecuteQuery("SELECT TaskId, AssignedTasks FROM tasks WHERE Status = 'Assigned'");
                AssignedTasksPanel.Children.Clear();

                foreach (DataRow row in taskData.Rows)
                {
                    string taskId = row["TaskId"].ToString();
                    string taskName = row["AssignedTasks"].ToString();

                    CheckBox checkBox = new CheckBox
                    {
                        Content = taskName,
                        Tag = taskId,
                        FontSize = 18,
                        Margin = new Thickness(5)
                    };

                    checkBox.Checked += TaskCompleted_Checked;
                    AssignedTasksPanel.Children.Add(checkBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assigned tasks: " + ex.Message);
            }
        }

        private void LoadCompletedTasks()
        {
            try
            {
                DataTable completedData = DatabaseHelper.ExecuteQuery("SELECT AssignedTasks FROM tasks WHERE Status = 'Completed'");
                CompletedTasksPanel.Children.Clear();

                foreach (DataRow row in completedData.Rows)
                {
                    TextBlock completedTask = new TextBlock
                    {
                        Text = row["AssignedTasks"].ToString(),
                        FontSize = 18,
                        Margin = new Thickness(5)
                    };

                    CompletedTasksPanel.Children.Add(completedTask);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading completed tasks: " + ex.Message);
            }
        }

        private void TaskCompleted_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is string taskId)
            {
                string query = "UPDATE tasks SET Status = 'Completed' WHERE TaskId = @TaskId";
                var parameters = new Dictionary<string, object> { { "@TaskId", taskId } };

                try
                {
                    DatabaseHelper.ExecuteNonQuery(query, parameters);
                    LoadTaskStatistics();
                    LoadAssignedTasks();
                    LoadCompletedTasks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating task status: " + ex.Message);
                }
            }
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            new EmployeeProfile().Show();
            Close();
        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            new EmployeeInventory().Show();
            Close();
        }
    }
}
