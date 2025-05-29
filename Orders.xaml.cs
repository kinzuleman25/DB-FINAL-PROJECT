using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp6
{
    public partial class Orders : Window
    {
        public Orders()
        {
            try
            {
                InitializeComponent();
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during InitializeComponent: " + ex.Message);
            }
        }

        private void LoadOrders()
        {
            string query = "SELECT * FROM `order`"; // Corrected table name with backticks
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
           
        }

        private void SubmitOrder_Click(object sender, RoutedEventArgs e)
        {
            string clientId = ClientIdTextBox.Text.Trim();
            string articleNo = ArticleNumberTextBox.Text.Trim();
            string material = (MaterialComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            string date = DateTextBox.Text.Trim();
            string info = InfoTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(clientId) ||
                string.IsNullOrWhiteSpace(articleNo) ||
                string.IsNullOrWhiteSpace(material) ||
                string.IsNullOrWhiteSpace(date))
            {
                MessageBox.Show("Please fill all required fields.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string insertQuery = "INSERT INTO `order` (ClientId, Articleno, Date, Material, Information) " +
                                 "VALUES (@ClientId, @Articleno, @Date, @Material, @Information)";

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    var cmd = new MySql.Data.MySqlClient.MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@ClientId", clientId);
                    cmd.Parameters.AddWithValue("@Articleno", articleNo);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Material", material);
                    cmd.Parameters.AddWithValue("@Information", info);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Order submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Refresh the data grid and clear inputs
                    LoadOrders();
                    ClientIdTextBox.Clear();
                    ArticleNumberTextBox.Clear();
                    DateTextBox.Clear();
                    MaterialComboBox.SelectedIndex = -1;
                    InfoTextBox.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            home1 homeWindow = new home1();
            homeWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow feedbackWindow = new MainWindow();
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
}
