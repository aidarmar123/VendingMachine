using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DesktopVendingMachine.Models;

namespace DesktopVendingMachine
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static User AuthUser { get; set; }
        public static MainWindow mainWindow;
    }
}
