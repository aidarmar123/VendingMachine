using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppVendingMachin.Models
{
    public partial class VendingMachin
    {

        public string FullAdress { get => Adress + "\n" + Lacation; }
    }
}
