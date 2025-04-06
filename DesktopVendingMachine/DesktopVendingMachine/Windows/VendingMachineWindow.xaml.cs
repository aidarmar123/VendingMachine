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
using System.Windows.Shapes;
using DesktopVendingMachine.Models;
using DesktopVendingMachine.Services;

namespace DesktopVendingMachine.Windows
{
    /// <summary>
    /// Логика взаимодействия для VendingMachineWindow.xaml
    /// </summary>
    public partial class VendingMachineWindow : Window
    {

        VendingMachin conetxtMachin;
        public VendingMachineWindow(VendingMachin vendingMachin)
        {
            InitializeComponent();
            if (vendingMachin.Id == 0)
            {
                this.Title = "Создание торгового автомата";
                SPCreate.Visibility = Visibility.Visible;
                BSave.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.Title = "Редактирование торгового автомата";
                SPCreate.Visibility = Visibility.Collapsed;
                BSave.Visibility = Visibility.Visible;
            }
            BindingValueToCobmboBox();

            conetxtMachin = vendingMachin;
            SpTitle.DataContext = this;
            DataContext = conetxtMachin;

        }

        private void BindingValueToCobmboBox()
        {
            CLBTypePay.ItemsSource = DataManager.TypePays;

            CbWorkMode.ItemsSource = DataManager.WorkModes;
            CbManufacture.ItemsSource = DataManager.Manufactures;
            CbModel.ItemsSource = DataManager.Models;
            CbProductMatrix.ItemsSource = DataManager.ProductMatrixs;
            CbPriotityService.ItemsSource = DataManager.PriotityServices;
            CbShcemaCritValue.ItemsSource = DataManager.ShcemaCritValues;
            CbTimeZone.ItemsSource = DataManager.TimeZones;
            CbSchema.ItemsSource = DataManager.ShcemaNotifications;
            CbClient.ItemsSource = DataManager.Users.Where(x => x.RoleId == 2).ToList();
            CbIngener.ItemsSource = DataManager.Users.Where(x => x.RoleId == 3).ToList();
            CbMenedger.ItemsSource = DataManager.Users.Where(x => x.RoleId == 4).ToList();
            CbTap.ItemsSource = DataManager.Users.Where(x => x.RoleId == 5).ToList();

        }

        private async void BSave_Click(object sender, RoutedEventArgs e)
        {
            var response = await NetManager.Put($"api/VendingMachins/{conetxtMachin.Id}", conetxtMachin);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Данные сохранены");
                this.Close();
            }
            else
            {
                var result = await NetManager.ParseResponse<ErrorMessage>(response);
                MessageBox.Show(result.Message);
            }
        }


        private async void BCreate_Click(object sender, RoutedEventArgs e)
        {
            var response = await NetManager.Post("api/VendingMachins", conetxtMachin);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Данные сохранены");
                this.Close();
            }
            else
            {
                var result = await NetManager.ParseResponse<ErrorMessage>(response);
                MessageBox.Show(result.Message);
            }
        }
        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
