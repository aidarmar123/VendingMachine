using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopVendingMachine.Models;

namespace DesktopVendingMachine.Services
{
    public static class DataManager
    {
        public static List<MachineProduct> MachineProducts;
        public static List<MachineTypePay> MachineTypePays;
        public static List<Manufacture> Manufactures;
        public static List<Model> Models;
        public static List<Product> Products;
        public static List<Role> Roles;
        public static List<Sales> Saless;
        public static List<Models.Services> Servicess;
        public static List<StatusMachin> StatusMachins;
        public static List<TypePay> TypePays;
        public static List<User> Users;
        public static List<VendingMachin> VendingMachins;
        public static List<WorkMode> WorkModes;
        public static List<ProductMatrix> ProductMatrixs;
        public static List<PriotityService> PriotityServices;
        public static List<Models.TimeZone> TimeZones;

        public  static async Task InitData()
        {
            Roles = await NetManager.Get<List<Role>>("api/Roles");
            Models = await NetManager.Get<List<Model>>("api/Models");
            Manufactures = await NetManager.Get<List<Manufacture>>("api/Manufactures");



            VendingMachins = await NetManager.Get<List<VendingMachin>>("api/VendingMachins");
            Products = await NetManager.Get<List<Product>>("api/Products");
            Saless = await NetManager.Get<List<Sales>>("api/Sales");
            Servicess = await NetManager.Get<List<Models.Services>>("api/Services");
        }
    }
}
