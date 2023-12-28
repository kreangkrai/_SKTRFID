using SKTRFIDREPORT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDREPORT.Interface
{
    interface IExport
    {
        string Export(List<ReportModel> reports);
        List<ReportModel> GetReportByDate(DateTime start, DateTime stop);
        List<ReportModel> GetReportByDBarCode(string barcode);
    }
}
