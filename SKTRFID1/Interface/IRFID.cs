﻿using SKTRFID1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFID1.Interface
{
    interface IRFID
    {
        DataModel GetDataByDump(int dump);
        List<DataModel> GetDatas();
    }
}
