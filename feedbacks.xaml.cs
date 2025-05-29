using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace WpfApp6
{
    public partial class feedbacks : Window
    {
        public feedbacks()
        {
            InitializeComponent();
            LoadFeedbackData();
        }

        private void LoadFeedbackData()
        {
            try
            {
                string query = "SELECT `Feedback Id`, `Project Id`, `Client Id`, `Rating`, `Comments` FROM feedback LIMIT 3";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    OrderIdLabel.Content = dt.Rows[0]["Project Id"].ToString();
                    ClientIdLabel.Content = dt.Rows[0]["Client Id"].ToString();
                    RateLabel.Content = dt.Rows[0]["Rating"].ToString();
                    CommentsLabel.Content = dt.Rows[0]["Comments"].ToString();
                }

                if (dt.Rows.Count > 1)
                {
                    OrderIdLabel1.Content = dt.Rows[1]["Project Id"].ToString();
                    ClientIdLabel1.Content = dt.Rows[1]["Client Id"].ToString();
                    RateLabel1.Content = dt.Rows[1]["Rating"].ToString();
                    CommentsLabel1.Content = dt.Rows[1]["Comments"].ToString();
                }

                if (dt.Rows.Count > 2)
                {
                    OrderIdLabel2.Content = dt.Rows[2]["Project Id"].ToString();
                    ClientIdLabel2.Content = dt.Rows[2]["Client Id"].ToString();
                    RateLabel2.Content = dt.Rows[2]["Rating"].ToString();
                    CommentsLabel2.Content = dt.Rows[2]["Comments"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading feedback data: " + ex.Message);
            }
        }

        // Your existing button navigation methods
        private void FeedbacksButton_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Feedbacks Button Clicked!");
        private void DashboardButton_Click(object sender, RoutedEventArgs e) { new dashboard().Show(); Close(); }
        private void ManageProjectsButton_Click(object sender, RoutedEventArgs e) { new manage_projects().Show(); Close(); }
        private void InventoryButton_Click(object sender, RoutedEventArgs e) { new inventory().Show(); Close(); }
        private void ProjectHistoryButton_Click(object sender, RoutedEventArgs e) { new project_history().Show(); Close(); }
        private void PaymentManagmentButton_Click(object sender, RoutedEventArgs e) { new payment_managment().Show(); Close(); }
        private void OrderRequestsButton_Click(object sender, RoutedEventArgs e) { new OrderRequests().Show(); Close(); }
        private void ProfileButton_Click(object sender, RoutedEventArgs e) { new Profileowner().Show(); }
    }
}
