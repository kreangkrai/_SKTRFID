using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDEDIT.Model
{
    class SubDataModel
    {
        public string dump_id { get; set; }
        public int area_id { get; set; }
        public string crop_year { get; set; }
        public string barcode { get; set; }
        public string cane_type { get; set; }
        public string allergen { get; set; }
        public string truck_number { get; set; }
        public DateTime rfid_lastdate { get; set; }
    }
}
