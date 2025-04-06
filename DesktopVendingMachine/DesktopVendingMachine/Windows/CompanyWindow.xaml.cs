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
    /// Логика взаимодействия для CompanyWindow.xaml
    /// </summary>
    public partial class CompanyWindow : Window
    {
        Company contextCompany;
        public CompanyWindow(Models.Company company)
        {
            InitializeComponent();
            contextCompany = company;
            DataContext = contextCompany;
        }

        private async void BSave_Click(object sender, RoutedEventArgs e)
        {
            var response = await NetManager.Post("api/Companys", contextCompany);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Данные успешно сохранены");
                this.Close();

            }
            else
            {
                var error = await NetManager.ParseResponse<ErrorMessage>(response);
                MessageBox.Show(error.Message);
            }
        }
    }
}
