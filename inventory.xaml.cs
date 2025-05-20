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
        public List<string> ProductLabels { get; set; }

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

            // Bind DataTable directly to DataGrid
            InventoryDataGrid.ItemsSource = dt.DefaultView;

            // Prepare chart data
            StockValues = new ChartValues<double>();
            ProductLabels = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                if (int.TryParse(row["quantity"].ToString(), out int quantity))
                {
                    StockValues.Add(quantity);
                    ProductLabels.Add(row["product"].ToString());
                }
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
            new order_requests().Show(); this.Close();
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
