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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace InventoryApplication
{
    /// <summary>
    /// Interaction logic for UserUC.xaml
    /// </summary>
    /// 

    class UserItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }

    }

    public partial class UserUC : UserControl
    {
        public UserUC()
        {
            InitializeComponent();
        }

        private BackgroundWorker worker;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();

            worker.DoWork += new DoWorkEventHandler(Update_Users);

            worker.RunWorkerAsync();
        }

        private void Update_Users(object sender, DoWorkEventArgs e)
        {
            using (var dbh = new DBHandler())
            {
                var values = dbh.fillUsers();
                while (values.Read())
                {
                    userList.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate ()
                    {
                        userList.Items.Add(new UserItem() { ID = values.GetInt32(0).ToString(), Rank = values.GetString(1), Name = values.GetString(2) });
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
