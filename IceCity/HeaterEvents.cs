using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{
    public class HeaterEventArgs : EventArgs
    {
        public HeaterBase Heater { get; set; }
    }

    public class HeaterDurationEventArgs : EventArgs
    {
        public HeaterBase Heater { get; set; }
        public double HoursWorked { get; set; }
    }

    public delegate void SaveDailyUsageDelegate(DailyUsage usage);
    public delegate void HeaterEventHandler(object sender, HeaterEventArgs e);
    public delegate void HeaterDurationHandler(object sender, HeaterDurationEventArgs e);
}

