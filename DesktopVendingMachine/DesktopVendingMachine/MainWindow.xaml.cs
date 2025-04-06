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
            Main.Navigate(new LoginPage());
        }
        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            App.AuthUser = null;
            GProfile.DataContext = null;
            Main.Navigate(new LoginPage());
        }
        private void HLMain_Click(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new MainPage());

        }

        private void HLMonitor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HLVendingMachine_Click(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new VendingMachinePage());

        }

        private void HlCompany_Click(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new CompanyPage());
        }
    }
}
