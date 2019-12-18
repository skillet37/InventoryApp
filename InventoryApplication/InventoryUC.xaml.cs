using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.ComponentModel;

class InventoryItem
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int SerialNo { get; set; }
    public string Location { get; set; }
    public string COBy { get; set; }
    public string CODate { get; set; }
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

        BackgroundWorker worker;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();

            worker.DoWork += new DoWorkEventHandler(Update_UI);

            worker.RunWorkerAsync();
        }

        private void Update_UI(object sender, DoWorkEventArgs e)
        {
            using (var dbh = new DBHandler())
            {
                var values = dbh.fillInventory();
                while (values.Read())
                {
                    inventoryList.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate ()
                    {
                        inventoryList.Items.Add(new InventoryItem() { SerialNo = values.GetInt32(0), Name = values.GetString(1), Type = values.GetString(2), Location = values.GetString(3) });
                    }));
                }
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (worker.IsBusy)
            {
                worker.Dispose();
            }
        }
    }
}
