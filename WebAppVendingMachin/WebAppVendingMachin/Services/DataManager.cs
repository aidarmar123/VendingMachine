using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppVendingMachin.Models;

namespace WebAppVendingMachin.Services
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
        public static List<ConnectionProvider> ConnectionProviders;
        public static List<StateConnect> StateConnects;
        public static List<Models.Company> Companys;


        public static List<WebAppVendingMachin.Models.User> Users;
        public static List<VendingMachin> VendingMachins;
        public static List<WorkMode> WorkModes;
        public static List<ProductMatrix> ProductMatrixs;
        public static List<PriotityService> PriotityServices;
        public static List<Models.TimeZone> TimeZones;
        public static List<ShcemaCritValue> ShcemaCritValues;
        public static List<ShcemaNotification> ShcemaNotifications;

        public  static async Task InitData()
        {
            Roles = await NetManager.Get<List<Role>>("api/Roles");
            Models = await NetManager.Get<List<Model>>("api/Models");
            Manufactures = await NetManager.Get<List<Manufacture>>("api/Manufactures");
            Users = await NetManager.Get<List<User>>("api/Users");
            TypePays = await NetManager.Get<List<TypePay>>("api/TypePays");
            ProductMatrixs = await NetManager.Get<List<ProductMatrix>>("api/ProductMatrixs");
            PriotityServices = await NetManager.Get<List<PriotityService>>("api/PriotityServices");
            ShcemaCritValues = await NetManager.Get<List<ShcemaCritValue>>("api/ShcemaCritValues");
            ShcemaNotifications = await NetManager.Get<List<ShcemaNotification>>("api/ShcemaNotifications");
            WorkModes = await NetManager.Get<List<WorkMode>>("api/WorkModes");
            TimeZones = await NetManager.Get<List<Models.TimeZone>>("api/TimeZones");



            VendingMachins = await NetManager.Get<List<VendingMachin>>("api/VendingMachins");
            Products = await NetManager.Get<List<Product>>("api/Products");
            Saless = await NetManager.Get<List<Sales>>("api/Sales");
            Servicess = await NetManager.Get<List<Models.Services>>("api/Services");
            Companys = await NetManager.Get<List<Company>>("api/Companys");
            
        }
    }
}
