using SKTRFIDShift.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDShift.Interface
{
    interface IShift
    {
        List<ShiftModel> GetShifts(DateTime start, DateTime stop);
        ShiftModel GetShift(DateTime date);
        string Update(ShiftModel data);
        string Insert(ShiftModel data);
    }
}
