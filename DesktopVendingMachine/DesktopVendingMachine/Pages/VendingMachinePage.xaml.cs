using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

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
            VendingMachine = DataManager.VendingMachins.Where(x=>!x.IsDelete).ToList();
            DGMacine.ItemsSource = VendingMachine.Skip(CountItem * indexPage).Take(CountItem).ToList();
            LVMachine.ItemsSource = VendingMachine.Skip(CountItem * indexPage).Take(CountItem).ToList();
            var textNote = $"Записи с {IndexPage } до {CountItem*IndexPage} из {VendingMachine.Count} записей";
            TbNote.Text = textNote;
        }

        private void CbCountItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            new VendingMachineWindow(new VendingMachin() {InitWork = DateTime.Now, StatusMachinId = 1 }).ShowDialog();
        }

        private void BExport_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDilog = new SaveFileDialog() { Filter = ".csv | *.csv" };
            if (saveFileDilog.ShowDialog().GetValueOrDefault())
            {
                var file =  File.Create(saveFileDilog.FileName);
                file.Close();

                var content = "Id;Название;Модель;Компания;Адрес;В работе с;\n"
                    + string.Join("\n", VendingMachine.Select(x => $"{x.Id};{x.Name};{x.Model.Name};{x.Company?.Name:''};{x.Adress};{x.InitWork.ToString("d")}"));
                File.WriteAllText(saveFileDilog.FileName, content, Encoding.UTF8);
                
            }
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectMachine = (sender as Button).DataContext as VendingMachin;
            if(selectMachine != null)
            {
                new VendingMachineWindow(selectMachine).ShowDialog();
                Refresh();
            }
        }

        private async void BDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectMachine = (sender as Button).DataContext as VendingMachin;
            if (selectMachine != null)
            {
                await NetManager.Delete($"api/VendingMachins/{selectMachine.Id}");

            }
        }

        private void BUnlokModem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BNext_Click(object sender, RoutedEventArgs e)
        {
            if (IndexPage * CountItem < VendingMachine.Count)
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
    }
}
