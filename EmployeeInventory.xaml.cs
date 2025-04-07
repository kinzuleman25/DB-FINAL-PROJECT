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
    /// Interaction logic for EmployeeInventory.xaml
    /// </summary>
    public partial class EmployeeInventory : Window
    {
        public EmployeeInventory()
        {
            InitializeComponent();

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection changes in the DataGrid (if needed)
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            EmployeeProfile profileWindow = new EmployeeProfile();
            profileWindow.Show();
            this.Close(); // optional: close current window
        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInventory inventoryWindow = new EmployeeInventory();
            inventoryWindow.Show();
            this.Close(); // optional
        }

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            EmployeeTasks tasksWindow = new EmployeeTasks();
            tasksWindow.Show();
            this.Close(); // optional
        }

    }
}
