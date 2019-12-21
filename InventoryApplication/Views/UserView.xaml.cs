using System;
using System.Linq;
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
            using(var context = new AppDBContext())
            {
                var users = (from s in context.Users select s).ToList<User>();
                userList.ItemsSource = users;
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
