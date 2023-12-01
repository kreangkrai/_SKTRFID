using SKTRFIDSETTING.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDSETTING.Interface
{
    interface ISetting
    {
        DataModel GetData();
        string Update(DataModel setting);
    }
}
