using SKTRFIDLIBRARY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDLIBRARY.Interface
{
    public interface IRFID
    {
        DataModel GetDataByDump(int dump);
        List<DataModel> GetDatas(string crop_year);
        List<DataModel> GetDatasByAreaYear(int area_id,string crop_year);
        string UpdateRFID(DataModel data);
        string InsertRFID(List<DataModel> datas);
    }
}
