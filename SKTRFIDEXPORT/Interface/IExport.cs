using SKTRFIDEXPORT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDEXPORT.Interface
{
    interface IExport
    {
        string Export(List<ReportModel> reports);
        List<ReportModel> GetReportByDate(DateTime start, DateTime stop);
    }
}
