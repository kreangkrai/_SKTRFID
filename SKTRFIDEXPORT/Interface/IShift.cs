using SKTRFIDREPORT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDREPORT.Interface
{
    interface IShift
    {
        List<ShiftModel> GetShiftByDate(DateTime start, DateTime stop);
    }
}
