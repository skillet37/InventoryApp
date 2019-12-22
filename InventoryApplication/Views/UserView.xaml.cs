using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApplication
{
    /// <summary>
    /// Interaction logic for UserUC.xaml
    /// </summary>
 
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            Thread t1 = new Thread(FillInventory);
            t1.Start();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void FillInventory()
        {
            using (var context = new AppDBContext())
            {
                var users = (from s in context.Users select s).ToList<User>();
                userList.Dispatcher.Invoke(new Action(() => { userList.ItemsSource = users; }));
            }
        }  
    }
}
