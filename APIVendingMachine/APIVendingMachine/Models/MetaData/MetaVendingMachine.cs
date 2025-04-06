using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace APIVendingMachine.Models.MetaData
{
    public class MetaVendingMachine
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Adress { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lacation { get; set; }
        public string Coordination { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(1,100, ErrorMessage="Необходимо указать Производителя")]
        public int ManufactureId { get; set; }
        [Range(1, 100, ErrorMessage = "Необходимо указать Модель")]

        public int ModelId { get; set; }
        [Range(1, 100, ErrorMessage = "Необходимо указать Режим работы")]

        public int WorkModeId { get; set; }
        public System.DateTime InitWork { get; set; }
        public int StatusMachinId { get; set; }
        public int TotalIncome { get; set; }
        public Nullable<System.DateTime> LastServiceDate { get; set; }
        public bool IsDelete { get; set; }
        public bool HaveModem { get; set; }
        public string Notes { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Необходимо указать Часовой пояс")]

        public int TimeZoneId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Необходимо указать Товарную матрицу")]

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
        [Range(1, int.MaxValue, ErrorMessage = "Необходимо указать Приоретет обслуживания")]

        public int PriotityServiceId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Необходимо указать Номер автомата")]
        [Required]
        public Nullable<int> Number { get; set; }
        [RegularExpression("\\d\\d:\\d\\d-\\d\\d:\\d\\d")]
        public string TimeWork { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MachineProduct> MachineProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MachineTypePay> MachineTypePay { get; set; }
        [JsonIgnore]
        public virtual Manufacture Manufacture { get; set; }
        [JsonIgnore]
        public virtual Model Model { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Services> Services { get; set; }
        [JsonIgnore]
        public virtual StatusMachin StatusMachin { get; set; }
        [JsonIgnore]
        public virtual WorkMode WorkMode { get; set; }
        [JsonIgnore]
        public virtual PriotityService PriotityService { get; set; }
        [JsonIgnore]
        public virtual ProductMatrix ProductMatrix { get; set; }
        [JsonIgnore]
        public virtual TimeZone TimeZone { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual User User1 { get; set; }
        [JsonIgnore]
        public virtual User User2 { get; set; }
        [JsonIgnore]
        public virtual User User3 { get; set; }
        [JsonIgnore]
        public virtual ShcemaCritValue ShcemaCritValue { get; set; }
        [JsonIgnore]
        public virtual ShcemaNotification ShcemaNotification { get; set; }
    }
}