using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDSHIFT.Service
{
    public static class DBConnectService
    {
        public static string data_source()
        {
            return "Data Source=OPT3050-01\\MEEDB;Initial Catalog=SKT;User ID=sa;Password=Meeci50026;Trusted_Connection=False;MultipleActiveResultSets=true;integrated security=SSPI";
        }
    }
}
