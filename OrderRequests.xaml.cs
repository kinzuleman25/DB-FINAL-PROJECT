using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class OrderRequests : Window
    {
        public OrderRequests()
        {
            InitializeComponent();
            LoadOrderData();
        }
        private void LoadOrderData()
        {
            try
            {
                string query = "SELECT * FROM `order` LIMIT 1"; // Get the latest or first order
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Assuming you have named your labels in XAML as follows:
                    ArticleNoLabel.Content = row["Articleno"].ToString();
                    MaterialLabel.Content = row["Material"].ToString();
                    DateLabel.Content = Convert.ToDateTime(row["Date"]).ToShortDateString();
                    InformationLabel.Content = row["Information"].ToString();
                    ClientIdLabel.Content = row["Clientid"].ToString();
                }
                else
                {
                    MessageBox.Show("No orders found in the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order data: " + ex.Message);
            }
        }
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int clientId = int.Parse(ClientIdLabel.Content.ToString());

                // Check if the ClientId exists (simple and works with current ExecuteScalar definition)
                string checkClientQuery = $"SELECT COUNT(*) FROM client WHERE ClientId = {clientId}";
                int clientExists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkClientQuery));

                if (clientExists == 0)
                {
                    MessageBox.Show("❌ The specified Client ID does not exist. Please enter a valid client before proceeding.", "Client Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Prepare parameters for insert
                Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@Date", DateTime.Parse(DateLabel.Content.ToString()) },
            { "@Articleno", int.Parse(ArticleNoLabel.Content.ToString()) },
            { "@Material", MaterialLabel.Content.ToString() },
            { "@ExtraInfo", InformationLabel.Content.ToString() },
            { "@ClientId", clientId }
        };

                string insertQuery = @"
            INSERT INTO ongoingprojects (Articleno, Date, Material, ExtraInfo, ClientId) 
            VALUES (@Articleno, @Date, @Material, @ExtraInfo, @ClientId)";

                int result = DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);

                if (result > 0)
                {
                    MessageBox.Show("✅ Order has been successfully accepted and added to ongoing projects.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("❌ Order could not be processed. Please try again.", "Insert Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("foreign key constraint fails"))
                {
                    MessageBox.Show("❌ Cannot insert the project. The specified Client ID does not exist.", "Foreign Key Violation", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("⚠️ Error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void OrderRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Order Requests Button Clicked!");
        }
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            dashboard dashboardWindow = new dashboard();
            dashboardWindow.Show();
            this.Close(); // Optional: Close the current window if needed
        }
        private void ManageProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            manage_projects manageProjectsWindow = new manage_projects();
            manageProjectsWindow.Show();
            this.Close(); // Close current window if needed
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            inventory inventoryWindow = new inventory();
            inventoryWindow.Show();
            this.Close(); // Close current window if needed
        }
        private void ProjectHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            project_history projectHistoryWindow = new project_history();
            projectHistoryWindow.Show();
            this.Close(); // Hide the dashboard instead of closing
        }

        private void PaymentManagmentButton_Click(object sender, RoutedEventArgs e)
        {
            payment_managment paymentWindow = new payment_managment();
            paymentWindow.Show();
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
            profileWindow.Show(); // Opens the window

            // Optionally close the current window
            // this.Close();
        }
    }
}