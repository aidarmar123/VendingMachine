using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVendingMachine.Models
{
    public partial class VendingMachin
    {

        public string FullAdress { get => Adress + "\n" + Lacation; }
        public string NameWithId { get => $"{Id} -  \"{Name}\""; }
        public double AllDownload { get => MachineProduct.Count / MinumProduct /100; set => AllDownload = value; }
        public double MinDownload { get => MachineProduct.Count!=0?(MachineProduct.Select(x => x.MinProduct).Sum() / MachineProduct.Count)/100:0; set => MinDownload = value; }
    }
}
