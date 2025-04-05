using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVendingMachine.Models
{
    public partial class User
    {
        public string FullName { get => $"{Surname} {Name[0]}. {Patronic[0]}."; }
    }
}
