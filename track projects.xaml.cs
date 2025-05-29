using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows;
using LiveCharts;

namespace WpfApp6
{
    public partial class track_projects : Window
    {
        public ChartValues<int> CompletedOrders { get; set; }
        public ChartValues<int> PendingOrders { get; set; }
        public ChartValues<int> NewOrders { get; set; }
        public ChartValues<int> ProcessingOrders { get; set; }
        public ChartValues<int> CancelledOrders { get; set; }
        public ChartValues<int> DeliveredOrders { get; set; }

        public track_projects()
        {
            InitializeComponent();

            // Initialize chart values
            CompletedOrders = new ChartValues<int> { 70 };
            PendingOrders = new ChartValues<int> { 30 };
            NewOrders = new ChartValues<int> { 40 };
            ProcessingOrders = new ChartValues<int> { 60 };
            CancelledOrders = new ChartValues<int> { 15 };
            DeliveredOrders = new ChartValues<int> { 85 };

            DataContext = this;

            // ✅ Load payments into the DataGrid
            LoadPayments();
        }

        private void LoadPayments()
        {
            string query = "SELECT ProjectId, TotalAmount FROM payments";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            List<ProjectPayment> payments = new List<ProjectPayment>(); // 🔄 FIXED: Use ProjectPayment
            int serial = 1;

            foreach (DataRow row in dt.Rows)
            {
                payments.Add(new ProjectPayment
                {
                    SerialNo = serial++,
                    ProjectId = Convert.ToInt32(row["ProjectId"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"])
                });
            }

            paymentsDataGrid.ItemsSource = payments;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            home1 homeWindow = new home1();
            homeWindow.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow feedbackWindow = new MainWindow(); // Feedback page
            feedbackWindow.Show();
            this.Close();
        }

        private void MyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.Show();
            this.Close();
        }
    }

    // ✅ Renamed to avoid name clash with another class
    public class ProjectPayment
    {
        public int SerialNo { get; set; }
        public int ProjectId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
