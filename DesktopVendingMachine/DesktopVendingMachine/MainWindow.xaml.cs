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
using DesktopVendingMachine.Pages;

namespace DesktopVendingMachine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.mainWindow = this;
            FrameLogin.Navigate(new LoginPage());
        }
        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            App.AuthUser = null;
            GProfile.DataContext = null;
            FrameLogin.Navigate(new LoginPage());
            Main.Visibility = Visibility.Collapsed;
            FrameLogin.Visibility = Visibility.Visible;
        }
        private void HLMain_Click(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new MainPage());

        }

        private void HLMonitor_Click(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new MonitorVendingMachin());
        }

        private void HLVendingMachine_Click(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new VendingMachinePage());

        }

        private void HlCompany_Click(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new CompanyPage());
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProfileButton.ContextMenu != null)
            {
               
                ProfileButton.ContextMenu.IsOpen = true;
            }
        }

    }
}
