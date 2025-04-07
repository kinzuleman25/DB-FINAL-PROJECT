using System;
using System.Collections.Generic;
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
    /// Interaction logic for payment_managment.xaml
    /// </summary>
    public partial class payment_managment : Window
    {
        public payment_managment()
        {
            InitializeComponent();
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
            profileWindow.Show(); // Opens the window

            // Optionally close the current window
            // this.Close();
        }
        private void UpdatePayments_Click(object sender, RoutedEventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.Show();
            this.Close();
        }

    }
}


