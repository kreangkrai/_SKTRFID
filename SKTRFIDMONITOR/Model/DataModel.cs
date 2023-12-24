using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDMONITOR.Model
{
    class DataModel
    {
        public int dump_id { get; set; }
        public int queue { get; set; }       
        public int area_id { get; set; }
        public string crop_year { get; set; }
        public string rfid { get; set; }
        public string barcode { get; set; }
        public int cane_type { get; set; }
        public string allergen { get; set; }
        public string truck_number { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }
}
