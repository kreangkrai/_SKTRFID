using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDEXPORT.Interface
{
    interface IExport
    {
        string Export(string start, string stop);
    }
}
