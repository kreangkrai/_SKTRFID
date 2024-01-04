using SKTRFIDMONITOR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDMONITOR.Interface
{
    interface IMonitor
    {
        List<DataModel> GetLastUpdate(string crop_year);
    }
}
