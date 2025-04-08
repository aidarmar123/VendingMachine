using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DesktopVendingMachine.Services;

namespace DesktopVendingMachine.Models
{
    public partial class VendingMachin
    {
        public async Task GetStateConnection()
        {
            var state = await NetManager.Get<StateApi>($"api/StateConnection/{Id}");
            StateApi = state.state;
            if (state.state > 0)
                ProviderState1 = Brushes.LightBlue;
            if (state.state > 1)
                ProviderState2 = Brushes.LightBlue;
            if (state.state > 2)
                ProviderState3 = Brushes.LightBlue;
            if (state.state > 3)
                ProviderState4 = Brushes.LightBlue;
            if (state.state > 4)
                ProviderState5 = Brushes.LightBlue;


        }
        public async Task GetMoney()
        {
            var money = await NetManager.Get<Money>($"api/Money/{Id}");
            SumBanknots = money.banknots.Select(x => x.count * x.value).Sum();
            Banknots = $"{SumBanknots} р. ({money.banknots.Select(x => x.count).Sum()} купюр)";
            SumCoins = money.coins.Select(x => x.count * x.value).Sum();
            Coins = $"{SumCoins} р. ({money.coins.Select(x => x.count).Sum()} монет)";
            SumTotal = SumCoins + SumBanknots;
            Total = $"{SumTotal} р.";
        }
        public async Task GetProducts()
        {
            var products = await NetManager.Get<CountProducts>($"api/LodaingProduct/{Id}");
            ProductsApi = products.countProducts;
        }


        public string FullAdress { get => Adress + "\n" + Lacation; }
        public string NameWithId { get => $"{Id} -  \"{Name}\""; }

        public int StateApi { get; set; }
        public int MoneyApi { get; set; }
        public int ProductsApi { get; set; }

        public int SumBanknots { get; set; }

        public string Banknots { get; set; }
        public int SumCoins { get; set; }
        public string Coins { get; set; }
        public int SumTotal { get; set; }
        public string Total { get; set; }


        public double AllDownload { get => ProductsApi / (double)TotalProduct; set => AllDownload = value; }
        public double MinDownload { get => MachineProduct.Count != 0 ? (MachineProduct.Count(x => x.MinProduct >= x.CountProduct) / (double)MachineProduct.Count) : 0; set => MinDownload = value; }

        public string LastService { get =>  Services.Count==0?"Пока ничего нет":Services.OrderBy(x => x.DateService)?.Last().DateService.ToString("M"); }
        public string LastIncasation { get => Incasation.Count==0? "Пока ничего нет" : Incasation.OrderBy(x => x.DateTime)?.Last().DateTime.ToString("M"); }
        public string LastSale { get => Sales.Count==0? "Пока ничего нет" : Sales.OrderBy(x => x.DateTimeSale)?.Last().DateTimeSale.ToString("M"); }

        public Brush ProviderState1 { get; set; } = Brushes.Gray;
        public Brush ProviderState2 { get; set; } = Brushes.Gray;
        public Brush ProviderState3 { get; set; } = Brushes.Gray;
        public Brush ProviderState4 { get; set; } = Brushes.Gray;
        public Brush ProviderState5 { get; set; } = Brushes.Gray;

        public Brush Socket
        {
            get
            {
                var equipment = EquipmentVachinMachin.FirstOrDefault(x => x.Id == 1);
                if (equipment != null)
                {
                    if (equipment.IsWork)
                        return Brushes.LightGreen;
                    else return Brushes.Red;
                }
                return Brushes.LightGray;
            }
        }

         public Brush AcceptBanknot
        {
            get
            {
                var equipment = EquipmentVachinMachin.FirstOrDefault(x => x.Id == 2);
                if (equipment != null)
                {
                    if (equipment.IsWork)
                        return Brushes.LightGreen;
                    else return Brushes.Red;
                }
                return Brushes.LightGray;
            }
        }

         public Brush AccpeptCoin
        {
            get
            {
                var equipment = EquipmentVachinMachin.FirstOrDefault(x => x.Id == 3);
                if (equipment != null)
                {
                    if (equipment.IsWork)
                        return Brushes.LightGreen;
                    else return Brushes.Red;
                }
                return Brushes.LightGray;
            }
        }

         public Brush AcceptCard
        {
            get
            {
                var equipment = EquipmentVachinMachin.FirstOrDefault(x => x.Id == 4);
                if (equipment != null)
                {
                    if (equipment.IsWork)
                        return Brushes.LightGreen;
                    else return Brushes.Red;
                }
                return Brushes.LightGray;
            }
        }

         public Brush Display
        {
            get
            {
                var equipment = EquipmentVachinMachin.FirstOrDefault(x => x.Id == 5);
                if (equipment != null)
                {
                    if (equipment.IsWork)
                        return Brushes.LightGreen;
                    else return Brushes.Red;
                }
                return Brushes.LightGray;
            }
        }

         public Brush AccpetNfc
        {
            get
            {
                var equipment = EquipmentVachinMachin.FirstOrDefault(x => x.Id == 6);
                if (equipment != null)
                {
                    if (equipment.IsWork)
                        return Brushes.LightGreen;
                    else return Brushes.Red;
                }
                return Brushes.LightGray;
            }
        }

        public Brush Provider
        {
            get
            {
                var equipment = EquipmentVachinMachin.FirstOrDefault(x => x.Id == 7);
                if (equipment != null)
                {
                    if (equipment.IsWork)
                        return Brushes.LightGreen;
                    else return Brushes.Red;
                }
                return Brushes.LightGray;
            }
        }



    }
}
