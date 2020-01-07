using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryApplication.Views
{
    /// <summary>
    /// Interaction logic for CheckoutSubView.xaml
    /// </summary>
    public partial class CheckoutSubView : UserControl
    {
        public CheckoutSubView()
        {
            InitializeComponent();
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            Thread t1 = new Thread(FillInventory);
            t1.Start();
        }

        private void FillInventory()
        {
            using (var context = new AppDBContext())
            {
                var users = (from s in context.Users select s).ToList<User>();
                userList.Dispatcher.Invoke(new Action(() => { userList.ItemsSource = users; }));
            }
        }

        private void userList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Go_Button.IsEnabled = true;
        }
    }
}
