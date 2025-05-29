using MySql.Data.MySqlClient;
using System;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfApp6
{
    public partial class PaymentForm : Window
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string clientId = ClientIdTextBox.Text.Trim();
            string projectId = OrderIdTextBox.Text.Trim(); // ProjectId = OrderId textbox
            string totalAmount = TotalAmountTextBox.Text.Trim();
            string dueAmount = DueAmountTextBox.Text.Trim();
            string paymentDate = DateTime.Now.ToString("yyyy-MM-dd");

            string connectionString = "server=127.0.0.1;port=3306;user id=root;password=kinza25;database=smajorglazing;";


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"INSERT INTO payments (ClientId, ProjectId, TotalAmount, DueAmount, PaymentDate)
                                     VALUES (@ClientId, @ProjectId, @TotalAmount, @DueAmount, @PaymentDate)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClientId", clientId);
                        cmd.Parameters.AddWithValue("@ProjectId", projectId);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@DueAmount", dueAmount);
                        cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Payment data saved to the payments table successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
        }
        private void DashboardButton_Click(object sender, RoutedEventArgs e) { new dashboard().Show(); this.Close(); }
        private void ManageProjectsButton_Click(object sender, RoutedEventArgs e) { new manage_projects().Show(); this.Close(); }
        private void InventoryButton_Click(object sender, RoutedEventArgs e){ new inventory().Show(); this.Close(); }
        private void ProjectHistoryButton_Click(object sender, RoutedEventArgs e) {new project_history().Show(); this.Close(); }
        private void PaymentManagmentButton_Click(object sender, RoutedEventArgs e) {new payment_managment().Show(); this.Close(); }
        private void OrderRequestsButton_Click(object sender, RoutedEventArgs e){ new OrderRequests().Show(); this.Close(); }
        private void FeedbacksButton_Click(object sender, RoutedEventArgs e){new feedbacks().Show();this.Close();}

        private void ProfileButton_Click(object sender, RoutedEventArgs e) { new Profileowner().Show(); this.Close(); }
    }
    // Your other navigation button methods go here (unchanged)
}


