using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesktopVendingMachine.Models
{
    public partial class StatusMachin
    {
        public Brush Color
        {
            get
            {
                if(Id == 1)
                    return Brushes.Green;
                else if(Id==2)
                        return Brushes.Red;
                else if(Id==3)
                    return Brushes.LightBlue;
                return Brushes.Gray;
            }
        }
    }
}
