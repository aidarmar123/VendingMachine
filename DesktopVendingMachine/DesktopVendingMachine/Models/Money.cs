using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVendingMachine.Models
{
    public partial class Money
    {
        public Banknot[] banknots { get; set; }
        public Coin[] coins { get; set; }
    }
    public class Banknot
    {
        public int value { get; set; }
        public int count { get; set; }
    }

    public class Coin
    {
        public int value { get; set; }
        public int count { get; set; }
    }
}
