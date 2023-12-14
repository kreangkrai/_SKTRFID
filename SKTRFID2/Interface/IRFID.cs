using SKTRFID2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFID2.Interface
{
    interface IRFID
    {
        DataModel GetDataByDump(int dump);
        List<DataModel> GetDatas();
    }
}
