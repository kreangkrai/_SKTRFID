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
        List<DataModel> GetDatas();
        List<DataModel> GetDatasByBarCode(string barcode);
        List<DataModel> GetDatasByDate(DateTime start,DateTime stop);
    }
}
