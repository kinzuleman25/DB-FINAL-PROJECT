using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp6
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged_2(object sender, RoutedEventArgs e)
        {
            // Password changed handler (if needed)
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            // Remember me logic (optional)
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                // Access Username and Password TextBoxes manually
                var usernameTextBox = (TextBox)this.FindName("UsernameTextBox") ?? (TextBox)LogicalTreeHelper.FindLogicalNode(this, "UsernameTextBox");
                var passwordBox = (TextBox)this.FindName("PasswordBox") ?? (TextBox)LogicalTreeHelper.FindLogicalNode(this, "PasswordBox");

                string username = usernameTextBox?.Text ?? "";
                string password = passwordBox?.Text ?? "";

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }

                if (username == "owner" && password == "123")
                {
                    dashboard ownerPage = new dashboard();
                    ownerPage.Show();
                    this.Close();
                }
                else if (username == "client" && password == "123")
                {
                    home1 clientPage = new home1();
                    clientPage.Show();
                    this.Close();
                }
                else if (username == "employee" && password == "123")
                {
                    EmployeeTasks employeePage = new EmployeeTasks();
                    employeePage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login: " + ex.Message);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SignUp signUpWindow = new SignUp();
                signUpWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Sign Up Page: " + ex.Message);
            }
        }
    }
}