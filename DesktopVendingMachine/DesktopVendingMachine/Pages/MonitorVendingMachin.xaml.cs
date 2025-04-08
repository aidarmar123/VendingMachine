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
    /// Логика взаимодействия для MonitorVendingMachin.xaml
    /// </summary>
    public partial class MonitorVendingMachin : Page
    {

        public Dictionary<string, Func<List<VendingMachin>, IEnumerable<VendingMachin>>> sorting = new Dictionary<string, Func<List<VendingMachin>, IEnumerable<VendingMachin>>>
        {
            {"По состоянию ТА ", list=>list.OrderBy(x=>x.StatusMachinId) },
            {"По названию ТА", list=>list.OrderBy(x=>x.Name) },

             {"По времени пинга ⬆ ", list=>list.OrderBy(x=>x.StateApi) },
            {"По времени пинга ⬇", list=>list.OrderByDescending(x=>x.StateApi) },

             {"По общей загрузке ⬆ ", list=>list.OrderBy(x=>x.AllDownload) },
            {"По общей загрузке ⬇", list=>list.OrderByDescending(x=>x.AllDownload) },

             {"По минимальной загрузке ⬆", list=>list.OrderBy(x=>x.MinDownload) },
            {"По минимальной загрузке ⬇", list=>list.OrderByDescending(x=>x.MinDownload) },

             
            {"По сумме монет ⬆ ", list=>list.OrderBy(x=>x.SumCoins) },
            {"По сумме монет ⬇", list=>list.OrderByDescending(x=>x.SumCoins) },

             
            {"По сумме купюр ⬆", list=>list.OrderBy(x=>x.SumBanknots) },
            {"По сумме купюр ⬇", list=>list.OrderByDescending(x=>x.SumBanknots) },

             
            {"По сумме сдачи ⬆ ", list=>list.OrderBy(x=>x.SumTotal) },
            {"По сумме сдачи ⬇", list=>list.OrderByDescending(x=>x.SumTotal) },

             
            {"По времени продажи ⬆ ", list=>list.OrderBy(x=>x.LastSale) },
            {"По времени продажи ⬇", list=>list.OrderByDescending(x=>x.LastSale) },

             
            {"По времени инкасации ⬆", list=>list.OrderBy(x=>x.LastIncasation) },
            {"По времени инкасации ⬇", list=>list.OrderByDescending(x=>x.LastIncasation) },

             
            {"По времени обслуживания ⬆", list=>list.OrderBy(x=>x.LastService) },
            {"По времени обслуживания ⬇", list=>list.OrderByDescending(x=>x.LastService) },


             {"По сумме продаж сегодня ⬆ ", list=>list.OrderBy(x=>x.Sales.Where(y=>y.DateTimeSale.Date==DateTime.Now.Date)?.Select(y=>y.Product.Price*y.CountProduct).Sum()) },
            {"По сумме продаж сегодня ⬇", list=>list.OrderByDescending(x=>x.Sales.Where(y=>y.DateTimeSale.Date==DateTime.Now.Date)?.Select(y=>y.Product.Price*y.CountProduct).Sum()) },


             {"По сумме продаж с обслуж ⬆", list=>list.OrderBy(x=>x.Services.Count) },
            {"По сумме продаж с обслуж ⬇", list=>list.OrderByDescending(x=>x.Services.Count) },

            {"По кол-во продаж с обслуж ⬆", list=>list.OrderBy(x=>x.Services.Count) },
            {"По  кол-во продаж с обслуж ⬇", list=>list.OrderByDescending(x=>x.Services.Count) },
        };

        public MonitorVendingMachin()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            LVState.ItemsSource = DataManager.StatusMachins;
            LVConnection.ItemsSource = DataManager.TypeConnections;
            LVAdditional.ItemsSource = DataManager.StatusMachins;
            CBSort.ItemsSource = sorting.Keys;
            DgVendingMachine.ItemsSource = DataManager.VendingMachins;
            TbResult.Text = $"Итого автоматов:{DataManager.VendingMachins.Count}({DataManager.VendingMachins.Count(x=>x.StatusMachinId==1)}/{DataManager.VendingMachins.Count(x => x.StatusMachinId == 2)}/{DataManager.VendingMachins.Count(x => x.StatusMachinId == 3)}). Денег в автоматах: {DataManager.VendingMachins.Select(x=>x.SumTotal).Sum()} р.";
        }

        private void BFilter_Click(object sender, RoutedEventArgs e)
        {
            DgVendingMachine.Visibility = Visibility.Visible;
            var query = DataManager.VendingMachins;
            if(LVState.SelectedItem is StatusMachin status)
                query = query.Where(x=>x.StatusMachinId == status.Id).ToList();

            if (LVConnection.SelectedItem is TypeConnection connection)
                query = query.Where(x => x.VendingMachinTypeConnection.FirstOrDefault(y=>y.TypeConnectionId == connection.Id)!=null).ToList();

            if (CBSort.SelectedItem!=null && sorting.ContainsKey(CBSort.SelectedItem.ToString()))
             {
                query = sorting[CBSort.SelectedItem.ToString()](query).ToList();
            }

            if (query.Count == 0)
                DgVendingMachine.Visibility = Visibility.Collapsed;


            TbResult.Text = $"Итого автоматов:{query.Count}({query.Count(x => x.StatusMachinId == 1)}/{query.Count(x => x.StatusMachinId == 2)}/{query.Count(x => x.StatusMachinId == 3)}). Денег в автоматах: {query.Select(x => x.SumTotal).Sum()} р.";

            DgVendingMachine.ItemsSource = query;
        }

        private void BAll_Click(object sender, RoutedEventArgs e)
        {
            DgVendingMachine.Visibility = Visibility.Visible;

            LVState.SelectedItem = null;
            LVConnection.SelectedItem = null;
            LVAdditional.SelectedItem = null;

            InitData();
        }

       
    }
}
