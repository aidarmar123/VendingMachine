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
    /// Логика взаимодействия для VendingMachinePage.xaml
    /// </summary>
    public partial class VendingMachinePage : Page
    {
        public List<VendingMachin> VendingMachine { get; set; }
        public int CountItem { get; set; } = 1;

        private int indexPage = 0;
        public int IndexPage { get => indexPage + 1; }
        public VendingMachinePage()
        {
            InitializeComponent();
            CbCountItem.ItemsSource = Enumerable.Range(1, 50).ToList();
            Refresh();
            DataContext = this;
        }

        private void Refresh()
        {
            VendingMachine = DataManager.VendingMachins.ToList();
            DGMacine.ItemsSource = VendingMachine.Take(CountItem).Skip(CountItem * indexPage).ToList();
            LVMachine.ItemsSource = VendingMachine.Take(CountItem);
        }

        private void CbCountItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BUnlokModem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BNext_Click(object sender, RoutedEventArgs e)
        {
            if (IndexPage * CountItem < VendingMachine.Count)
                indexPage++;
        }

        private void BPrevous_Click(object sender, RoutedEventArgs e)
        {
            if (IndexPage > 0)
                indexPage--;


        }
    }
}
