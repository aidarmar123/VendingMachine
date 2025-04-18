//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppVendingMachin.Models
{
    using System;
	using Newtonsoft.Json;
	using WebAppVendingMachin.Services;
    using System.Collections.Generic;
    
    public partial class VendingMachin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VendingMachin()
        {
            this.EquipmentVachinMachin = new HashSet<EquipmentVachinMachin>();
            this.MachineProduct = new HashSet<MachineProduct>();
            this.MachineTypePay = new HashSet<MachineTypePay>();
            this.Report = new HashSet<Report>();
            this.Sales = new HashSet<Sales>();
            this.Services = new HashSet<Services>();
            this.VendingMachinTypeConnection = new HashSet<VendingMachinTypeConnection>();
            this.Incasation = new HashSet<Incasation>();
        }
    
        public int Id { get; set; }
        public string Adress { get; set; }
        public string Lacation { get; set; }
        public string Coordination { get; set; }
        public string Name { get; set; }
        public int ManufactureId { get; set; }
        public int ModelId { get; set; }
        public int WorkModeId { get; set; }
        public System.DateTime InitWork { get; set; }
        public int StatusMachinId { get; set; }
        public int TotalIncome { get; set; }
        public Nullable<System.DateTime> LastServiceDate { get; set; }
        public bool IsDelete { get; set; }
        public bool HaveModem { get; set; }
        public string Notes { get; set; }
        public int TimeZoneId { get; set; }
        public int ProductMatrixId { get; set; }
        public Nullable<int> ShcemaCritValueId { get; set; }
        public Nullable<int> ShcemaNotificationId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> MenedgerId { get; set; }
        public Nullable<int> IngenerId { get; set; }
        public Nullable<int> TapId { get; set; }
        public string PFIDServiece { get; set; }
        public string RFIDIncasation { get; set; }
        public string RFIDDownload { get; set; }
        public string KitOnline { get; set; }
        public int PriotityServiceId { get; set; }
        public Nullable<int> Number { get; set; }
        public string TimeWork { get; set; }
        public Nullable<int> ConnectionProviderId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public int PriceInMounth { get; set; }
        public int PaybackMonth { get; set; }
        public int Money { get; set; }
        public int TypeMachinId { get; set; }
        public int TotalProduct { get; set; }
    
        [JsonIgnore]
    
        public virtual Company Company 
        {
            get
            {
                return DataManager.Companys.FirstOrDefault(x=>x.Id == CompanyId);
            }
            set
            {
            CompanyId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual ConnectionProvider ConnectionProvider 
        {
            get
            {
                return DataManager.ConnectionProviders.FirstOrDefault(x=>x.Id == ConnectionProviderId);
            }
            set
            {
            ConnectionProviderId= value.Id;
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentVachinMachin> EquipmentVachinMachin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MachineProduct> MachineProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MachineTypePay> MachineTypePay { get; set; }
        [JsonIgnore]
    
        public virtual Manufacture Manufacture 
        {
            get
            {
                return DataManager.Manufactures.FirstOrDefault(x=>x.Id == ManufactureId);
            }
            set
            {
            ManufactureId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual Model Model 
        {
            get
            {
                return DataManager.Models.FirstOrDefault(x=>x.Id == ModelId);
            }
            set
            {
            ModelId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual PriotityService PriotityService 
        {
            get
            {
                return DataManager.PriotityServices.FirstOrDefault(x=>x.Id == PriotityServiceId);
            }
            set
            {
            PriotityServiceId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual ProductMatrix ProductMatrix 
        {
            get
            {
                return DataManager.ProductMatrixs.FirstOrDefault(x=>x.Id == ProductMatrixId);
            }
            set
            {
            ProductMatrixId= value.Id;
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Report { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Services> Services { get; set; }
        [JsonIgnore]
    
        public virtual ShcemaCritValue ShcemaCritValue 
        {
            get
            {
                return DataManager.ShcemaCritValues.FirstOrDefault(x=>x.Id == ShcemaCritValueId);
            }
            set
            {
            ShcemaCritValueId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual ShcemaNotification ShcemaNotification 
        {
            get
            {
                return DataManager.ShcemaNotifications.FirstOrDefault(x=>x.Id == ShcemaNotificationId);
            }
            set
            {
            ShcemaNotificationId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual StatusMachin StatusMachin 
        {
            get
            {
                return DataManager.StatusMachins.FirstOrDefault(x=>x.Id == StatusMachinId);
            }
            set
            {
            StatusMachinId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual TimeZone TimeZone 
        {
            get
            {
                return DataManager.TimeZones.FirstOrDefault(x=>x.Id == TimeZoneId);
            }
            set
            {
            TimeZoneId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual User Client 
        {
            get
            {
                return DataManager.Users.FirstOrDefault(x=>x.Id == ClientId);
            }
            set
            {
            ClientId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual User Menedger 
        {
            get
            {
                return DataManager.Users.FirstOrDefault(x=>x.Id == MenedgerId);
            }
            set
            {
            MenedgerId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual User Ingener 
        {
            get
            {
                return DataManager.Users.FirstOrDefault(x=>x.Id == IngenerId);
            }
            set
            {
            IngenerId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual User Tap 
        {
            get
            {
                return DataManager.Users.FirstOrDefault(x=>x.Id == TapId);
            }
            set
            {
            TapId= value.Id;
            }
        }
        [JsonIgnore]
    
        public virtual WorkMode WorkMode 
        {
            get
            {
                return DataManager.WorkModes.FirstOrDefault(x=>x.Id == WorkModeId);
            }
            set
            {
            WorkModeId= value.Id;
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendingMachinTypeConnection> VendingMachinTypeConnection { get; set; }
        [JsonIgnore]
    
        public virtual TypeMachine TypeMachin 
        {
            get
            {
                return DataManager.TypeMachines.FirstOrDefault(x=>x.Id == TypeMachinId);
            }
            set
            {
            TypeMachinId= value.Id;
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incasation> Incasation { get; set; }
    }
}
