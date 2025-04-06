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
using DesktopVendingMachine.Windows;

namespace DesktopVendingMachine.Pages
{
    /// <summary>
    /// Логика взаимодействия для CompanyPage.xaml
    /// </summary>
    public partial class CompanyPage : Page
    {

        public List<Company> Companys { get; set; }
        public int CountItem { get; set; } = 1;

        private int indexPage = 0;
        public int IndexPage { get => indexPage + 1; }
        public CompanyPage()
        {
            InitializeComponent();
            CbCountItem.ItemsSource = Enumerable.Range(1, 50).ToList();
            Refresh();
            DataContext = this;
        }

        private void Refresh()
        {
            Companys = DataManager.Companys;
            DGMacine.ItemsSource = Companys.Skip(CountItem * indexPage).Take(CountItem).ToList();
            LVMachine.ItemsSource = Companys.Skip(CountItem * indexPage).Take(CountItem).ToList();


        }
        private void BDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectCompay = (sender as Button).DataContext as Company;
            if(selectCompay != null)
            {
                new CompanyWindow(selectCompay).ShowDialog();
                Refresh();
            }
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            new CompanyWindow(new Company() { InitWork = DateTime.Now }).ShowDialog();
            Refresh();

        }

        private void BNext_Click(object sender, RoutedEventArgs e)
        {
            if (IndexPage * CountItem < Companys.Count)
                indexPage++;
            DataContext = null;
            DataContext = this;
            Refresh();
        }

        private void BPrevous_Click(object sender, RoutedEventArgs e)
        {
            if (IndexPage > 0)
                indexPage--;
            DataContext = null;
            DataContext = this;
            Refresh();
        }

        private void CbCountItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();

        }

        private void BExport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
