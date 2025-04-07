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
using LiveCharts;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for EmployeeTasks.xaml
    /// </summary>
    public partial class EmployeeTasks : Window
    {
        
            public ChartValues<double> CompletedTasks { get; set; }
            public ChartValues<double> PendingTasks { get; set; }
            public ChartValues<double> AssignedTasks { get; set; }

            public EmployeeTasks()
            {
                InitializeComponent();
                CompletedTasks = new ChartValues<double> { 30 };  // 30 Completed Projects
                PendingTasks = new ChartValues<double> { 15 }; // 15 In Progress
                AssignedTasks = new ChartValues<double> { 5 };     // 5 Pending Projects
                DataContext = this;
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

       

    }
    }
