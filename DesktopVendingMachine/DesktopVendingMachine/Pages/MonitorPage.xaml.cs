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
using DesktopVendingMachine.Models;
using DesktopVendingMachine.Services;

namespace DesktopVendingMachine.Pages
{
    /// <summary>
    /// Логика взаимодействия для MonitorPage.xaml
    /// </summary>
    public partial class MonitorPage : Page
    {
        public MonitorPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            LBState.ItemsSource = DataManager.StatusMachins;
            DgVendingMachin.ItemsSource = DataManager.VendingMachins;
        }

        private void BAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BFilter_Click(object sender, RoutedEventArgs e)
        {
            var query = DataManager.VendingMachins;
            if (LBState.SelectedItem is StatusMachin status)
            {
                query = query.Where(x => x.StatusMachinId == status.Id).ToList();
            }
            DgVendingMachin.ItemsSource = query;
        }
    }
}
