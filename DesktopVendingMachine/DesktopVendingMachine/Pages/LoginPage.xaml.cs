﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.RightsManagement;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            DataContext = this;
        
        }

        private async void BLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Login + Password))
            {

                var bytePassword = Encoding.UTF8.GetBytes(Password);
                var hashByte = MD5.Create().ComputeHash(bytePassword);
                var sb = new StringBuilder();
                foreach (var item in hashByte)
                {
                    sb.Append(item.ToString("X2"));
                }
                Password = sb.ToString();

                var response = await NetManager.Authorization(Login, Password);
                if (response.IsSuccessStatusCode)
                {
                    await DataManager.InitData();
                    App.AuthUser  = (await NetManager.ParseResponse<GetToken>(response)).contextUser;
                    App.mainWindow.GProfile.DataContext = null;
                    App.mainWindow.Content.Visibility = Visibility.Visible;
                    App.mainWindow.FrameLogin.Visibility = Visibility.Collapsed;
                    App.mainWindow.GProfile.DataContext =App.AuthUser;
                    App.mainWindow.Main.Navigate(new MainPage());

                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show("User not found");
                    }
                    else
                    {

                        var result = await NetManager.ParseResponse<string>(response);
                        MessageBox.Show(result);
                    }
                }
            }
            else
            {
                MessageBox.Show("Line is empty");
            }
        }
    }
}
