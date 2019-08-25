using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace azot_proj1.Models
{
    public class QueryResultModel
    {
        public int warn_id { get; set; }
        public string dangerous_value { get; set; }
        //public DateTime warning_time { get; set; }
        public string workshop_name { get; set; }
        public string sensor_name { get; set; }
        public string sensor_type_name { get; set; }
        public string normal_value { get; set; }
        //public DateTime warning_time_end { get; set; }
        public string warning_time { get; set; }
        public string warning_time_end { get; set; }
        public int warnings_quantity { get; set; }
        public int workshop_id { get; set; }


    }
}