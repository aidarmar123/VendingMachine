using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppVendingMachin.Models.MetaData
{
    public class MetaCompany
    {


        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Adress { get; set; }
        [Required]

        public string ContactCompany { get; set; }
        public string Notes { get; set; }
        public System.DateTime InitWork { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendingMachin> VendingMachin { get; set; }
    }
}