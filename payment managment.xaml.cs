using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp6
{
    public partial class payment_managment : Window
    {
        public payment_managment()
        {
            InitializeComponent();
            LoadPayments();
        }

        private void LoadPayments()
        {
            try
            {
                string query = "SELECT ProjectId, ClientId, TotalAmount, DueAmount, PaymentDate FROM payments";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                List<Payment> payments = new List<Payment>();

                foreach (DataRow row in dt.Rows)
                {
                    payments.Add(new Payment
                    {
                        ProjectId = Convert.ToInt32(row["ProjectId"]),
                        ClientId = Convert.ToInt32(row["ClientId"]),
                        TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                        DueAmount = Convert.ToDecimal(row["DueAmount"]),
                        PaymentDate = Convert.ToDateTime(row["PaymentDate"])
                    });
                }

                PaymentsDataGrid.ItemsSource = payments;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payments: " + ex.Message);
            }
        }

        // Navigation methods (unchanged)
        private void DashboardButton_Click(object sender, RoutedEventArgs e) => new dashboard().Show();
        private void ManageProjectsButton_Click(object sender, RoutedEventArgs e) => new manage_projects().Show(); 
        private void InventoryButton_Click(object sender, RoutedEventArgs e) => new inventory().Show(); 
        private void ProjectHistoryButton_Click(object sender, RoutedEventArgs e) => new project_history().Show(); 
        private void PaymentManagmentButton_Click(object sender, RoutedEventArgs e) => new payment_managment().Show(); 
        private void OrderRequestsButton_Click(object sender, RoutedEventArgs e) => new OrderRequests().Show(); 
        private void FeedbacksButton_Click(object sender, RoutedEventArgs e) => new feedbacks().Show(); 
        private void ProfileButton_Click(object sender, RoutedEventArgs e) => new Profileowner().Show();
        private void UpdatePayments_Click(object sender, RoutedEventArgs e) => new PaymentForm().Show(); 
    }
   

    public class Payment
    {
        public int ProjectId { get; set; }
        public int ClientId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }

}
