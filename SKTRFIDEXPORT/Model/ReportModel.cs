﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDREPORT.Model
{
    class ReportModel
    {
        public int queue { get; set; }
        public int dump_id { get; set; }
        public DateTime date { get; set; }
        public int area_id { get; set; }
        public string crop_year { get; set; }
        public string rfid { get; set; }
        public string barcode { get; set; }
        public string farmer_name { get; set; }
        public int cane_type { get; set; }
        public string allergen { get; set; }
        public string truck_number { get; set; }
        public int round { get; set; }
    }
}
