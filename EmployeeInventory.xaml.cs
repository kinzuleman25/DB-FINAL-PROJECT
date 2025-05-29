using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace WpfApp6
{
    public partial class EmployeeInventory : Window
    {
        public ObservableCollection<InventoryItem> InventoryList { get; set; }

        public EmployeeInventory()
        {
            InitializeComponent();

            InventoryList = new ObservableCollection<InventoryItem>
            {
                new InventoryItem { Material = "Steel", InStock = "100", Required = 50 },
                new InventoryItem { Material = "Plastic", InStock = "60", Required = 80 }
            };

            this.DataContext = this;
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            EmployeeProfile profileWindow = new EmployeeProfile();
            profileWindow.Show();
            this.Close();
        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInventory inventoryWindow = new EmployeeInventory();
            inventoryWindow.Show();
            this.Close();
        }

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            EmployeeTasks tasksWindow = new EmployeeTasks();
            tasksWindow.Show();
            this.Close();
        }

        private void SaveToDatabase_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in InventoryList)
            {
                string query = "INSERT INTO inventory (material, instock, required) VALUES (@material, @instock, @required)";

                var parameters = new Dictionary<string, object>
                {
                    { "@material", item.Material },
                    { "@instock", item.InStock },
                    { "@required", item.Required }
                };

                try
                {
                    DatabaseHelper.ExecuteNonQuery(query, parameters);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error saving: " + ex.Message);
                }
            }

            MessageBox.Show("Data saved successfully!");
        }
    }

    public class InventoryItem : INotifyPropertyChanged
    {
        private string _material;
        private string _inStock;
        private int _required;

        public string Material
        {
            get => _material;
            set { _material = value; OnPropertyChanged(nameof(Material)); }
        }

        public string InStock
        {
            get => _inStock;
            set { _inStock = value; OnPropertyChanged(nameof(InStock)); }
        }

        public int Required
        {
            get => _required;
            set { _required = value; OnPropertyChanged(nameof(Required)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}


