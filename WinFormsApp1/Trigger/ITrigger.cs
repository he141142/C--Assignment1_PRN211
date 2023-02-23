using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Trigger
{
    public interface Itrigger
    {
        public void PerFormYes();
        public void PerformNo();

        public String Title();
        public String Content();
    }
}
