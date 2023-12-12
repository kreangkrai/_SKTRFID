using SKTRFIDEDIT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDEDIT.Interface
{
    interface IRFIDLog
    {
        List<DataModel> GetRFID(int n, string dump, string truck_number, string date);
        string UpdateRFID(DataModel data);
    }
}
