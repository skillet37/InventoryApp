using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InventoryApplication
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "MenuCheckout":
                    usc = new CheckoutView();
                    GridMain.Children.Add(usc);
                    break;
                case "MenuInventory":
                    usc = new InventoryView();
                    GridMain.Children.Add(usc);
                    break;
                case "MenuUserMan":
                    usc = new UserView();
                    GridMain.Children.Add(usc);
                    break;
                case "MenuReturn":
                    usc = new ReturnView();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
