using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVendingMachine.Models
{
    public partial class GetToken
    {
        public string Token { get; set; }
        public User contextUser { get; set; }
    }
}
