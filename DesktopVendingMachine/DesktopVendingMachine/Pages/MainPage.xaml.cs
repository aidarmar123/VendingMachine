﻿using System;
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
using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;

namespace DesktopVendingMachine.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        public double Money { get; set; }
        public double Change { get; set; }
        public double ProfitTodya { get; set; }
        public double ProfitYestday { get; set; }
        public double IncisedToday { get; set; }
        public double IncisedYestday { get; set; }
        public int Services { get; set; }

        public double ValueEffects { get; set; } = 1;

        public LiveCharts.Wpf.Separator Separator { get; set; } = new LiveCharts.Wpf.Separator() { Step=1};

        public string[] LabelSales { get; set; } = Enumerable.Range(0,11).Select(i => DateTime.Now.AddDays(-10 + i).ToString("M")).ToArray();
        public string Dates { get; set; } = $"{DateTime.Now.AddDays(-10).ToString("d")} по {DateTime.Now.ToString("d")}";
        public MainPage()
        {
            InitializeComponent();
            GenerateSummmary();
            GenerateState();
            GenerateSales();
            Refresh();
            ValueEffects =DataManager.VendingMachins.Count(x=>x.StatusMachinId==1)/DataManager.VendingMachins.Count()*100;
            DataContext = this;

        }

        private void GenerateSummmary()
        {
            Money = DataManager.Saless.Sum(x => x.CountProduct * x.Product.Price);
            ProfitTodya = DataManager.Saless.Where(x => x.DateTimeSale.Date == DateTime.Now.Date).Sum(x => x.CountProduct * x.Product.Price);
            ProfitYestday = DataManager.Saless.Where(x => x.DateTimeSale.Date == DateTime.Now.AddDays(-1).Date).Sum(x => x.CountProduct * x.Product.Price);
            Services = DataManager.Servicess.Where(x => x.DateService.Date == DateTime.Now.Date).Count();
        }
        private async void Refresh()
        {
            var news = await NetManager.Get<List<News>>("api/News");
            LVNews.ItemsSource = news.OrderBy(x => x.Date);
        }

        private void GenerateSales(bool isSum = false)
        {
            var sales = DataManager.Saless.Where(x => x.DateTimeSale.Date >= DateTime.Now.AddDays(-10).Date).ToList();

            var values = Enumerable.Range(0, 11).Select(i => sales.Where(x => x.DateTimeSale.Date == DateTime.Now.AddDays(-10 + i).Date).Sum(x=>x.CountProduct* (isSum ? x.Product.Price : 1))).ToList();

            //var values = sales.GroupBy(x => x.DateTimeSale.Date).Select(y => y.Select(s => s.CountProduct *(isSum?s.Product.Price:1)).Sum()).AsChartValues();

            var seriesCollection = new SeriesCollection(


                )
            {
                  new ColumnSeries
                {
                    Title = "Продажи",
                    Values = values.AsChartValues(),
                }
            };

            LVSales.Series = seriesCollection;
        }

        private void GenerateState()
        {
            var vendingMachin = DataManager.VendingMachins;

            var pieCollection = new SeriesCollection()
            {
                new PieSeries
                {
                    Title ="работает",
                    Values = new ChartValues<int>{vendingMachin.Count(x=>x.StatusMachinId==1)}

                },
                 new PieSeries
                {
                    Title ="не работает",
                    Values = new ChartValues<int>{vendingMachin.Count(x=>x.StatusMachinId==2)}
                    

                },
                 new PieSeries
                {
                    Title ="на обслуживании",
                    Values = new ChartValues<int>{vendingMachin.Count(x=>x.StatusMachinId==3)}


                },


            };
                
            PStae.Series = pieCollection;
                
        }

        private void BSum_Click(object sender, RoutedEventArgs e)
        {
            GenerateSales(true);
        }

        private void BCount_Click(object sender, RoutedEventArgs e)
        {
            GenerateSales(false);

        }
    }
}
