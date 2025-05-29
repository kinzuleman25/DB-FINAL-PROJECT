using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e) { }
        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e) { }
        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e) { }
        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e) { }
        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e) { }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate all fields
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
                string.IsNullOrWhiteSpace(CNICTextBox.Text) ||
                string.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                string.IsNullOrWhiteSpace(GenderTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(ConfirmPasswordTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Incomplete Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check if passwords match
            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
            {
                MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string insertQuery = @"
                INSERT INTO client 
                (FirstName, LastName, Username, Password, PhoneNumber, Gender, Address, ClientID)
                VALUES
                (@FirstName, @LastName, @Username, @Password, @PhoneNumber, @Gender, @Address, @ClientID)";

                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", NameTextBox.Text);
                        cmd.Parameters.AddWithValue("@LastName", EmailTextBox.Text);
                        cmd.Parameters.AddWithValue("@Username", PhoneTextBox.Text);
                        cmd.Parameters.AddWithValue("@Password", ConfirmPasswordTextBox.Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", CNICTextBox.Text);
                        cmd.Parameters.AddWithValue("@Gender", GenderTextBox.Text);
                        cmd.Parameters.AddWithValue("@Address", AddressTextBox.Text);
                        cmd.Parameters.AddWithValue("@ClientID", ClientIDTextBox.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration complete!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                home1 home = new home1();
                home.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}