using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApp6
{
    public partial class inventory : Window
    {
        public ChartValues<double> StockValues { get; set; }
        public List<string> MaterialLabels { get; set; }

        public inventory()
        {
            InitializeComponent();

            try
            {
                LoadInventoryData(); // Load from database
                DataContext = this;  // Set chart binding context
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory data: " + ex.Message);
            }
        }

        private void LoadInventoryData()
        {
            string query = "SELECT * FROM inventory";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            // Display full table in DataGrid (s.no will appear too)
            InventoryDataGrid.ItemsSource = dt.DefaultView;

            // Prepare chart data
            StockValues = new ChartValues<double>();
            MaterialLabels = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                // instock is VARCHAR in DB, we parse it to int for the chart
                if (int.TryParse(row["instock"].ToString(), out int instock))
                {
                    StockValues.Add(instock);
                    MaterialLabels.Add(row["material"].ToString());
                }

                // You can access s.no if needed
                int sno = Convert.ToInt32(row["s.no"]);
            }
        }

        private void InventoryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Optional: handle selection
        }

        // Navigation Buttons
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            new dashboard().Show(); this.Close();
        }

        private void ManageProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            new manage_projects().Show(); this.Close();
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            new inventory().Show(); this.Close();
        }

        private void ProjectHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            new project_history().Show(); this.Close();
        }

        private void PaymentManagmentButton_Click(object sender, RoutedEventArgs e)
        {
            new payment_managment().Show(); this.Close();
        }

        private void OrderRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            new OrderRequests().Show(); this.Close();
        }

        private void FeedbacksButton_Click(object sender, RoutedEventArgs e)
        {
            new feedbacks().Show(); this.Close();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            new Profileowner().Show();
        }
    }
}
