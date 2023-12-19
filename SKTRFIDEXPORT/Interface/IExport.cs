using SKTRFIDEXPORT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDEXPORT.Interface
{
    interface IExport
    {
        string Export(List<ReportModel> reports);
        string Export(DataGridView data);
        List<ReportModel> GetReportByDate(DateTime start, DateTime stop);
        List<ReportModel> GetReportByDBarCode(string barcode);
    }
}
