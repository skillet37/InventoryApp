using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.ComponentModel;

class InventoryItem
{

}

namespace InventoryApplication
{
    /// <summary>
    /// Interaction logic for InventoryUC.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            Thread t1 = new Thread(FillInventory);
            t1.Start();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FillInventory()
        {
            using (var context = new AppDBContext())
            {
                var items = (from s in context.Items select s).ToList<Item>();
                itemList.Dispatcher.Invoke(new Action(() => { itemList.ItemsSource = items; }));
            }
        }
    }
}
