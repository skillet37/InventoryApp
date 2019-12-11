using System.Windows;
using System.Windows.Controls;

class InventoryItem
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string SerialNo { get; set; }
    public string Location { get; set; }
    public string CODate { get; set; }
    public string RetDate { get; set; }
}


namespace InventoryApplication
{
    /// <summary>
    /// Interaction logic for InventoryUC.xaml
    /// </summary>
    public partial class InventoryUC : UserControl
    {
        public InventoryUC()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InventoryList.Items.Add(new InventoryItem() { Name = "M16", Type = "Weapon", SerialNo = "X1234", Location = "Shelf 1, Spot A", CODate = "", RetDate = "" });
            InventoryList.Items.Add(new InventoryItem() { Name = "Beretta", Type = "Weapon", SerialNo = "HG9876", Location = "Shelf 10, Spot C", CODate = "", RetDate = "" });
            InventoryList.Items.Add(new InventoryItem() { Name = "Backpack", Type = "Accessory", SerialNo = "X1DD33", Location = "Shelf 2, Spot B", CODate = "", RetDate = "" });
        }
    }
}
