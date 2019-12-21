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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new AppDBContext())
            {
                Console.WriteLine("Adding New Users");

                var user = new User
                {
                    Name = "Joe Bloggs",
                    Rank = "WOFF",
                    Email = "JB@domain.com",
                    UserId = 100,
                    Mobile = "0404112113"
                };

                context.Users.Add(user);

                user = new User
                {
                    Name = "Albert Einstein",
                    Rank = "Goat",
                    Email = "E=MC@Squared.com",
                    UserId = 929,
                    Mobile = "0419255699"
                };

                context.Users.Add(user);
                context.SaveChanges();

                Console.WriteLine("Retrieving Users...");

                var users = (from s in context.Users orderby s.Name select s).ToList<User>();

                foreach (var usr in users)
                {
                    Console.WriteLine("ID: {0}, Name: {1}, Email: {2}", usr.UserId, usr.Name, usr.Email);
                }
            }
        }
    }
}
