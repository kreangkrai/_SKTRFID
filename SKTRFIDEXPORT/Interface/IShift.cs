using SKTRFIDEXPORT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDEXPORT.Interface
{
    interface IShift
    {
        List<ShiftModel> GetShiftByDate(DateTime start, DateTime stop);
    }
}
