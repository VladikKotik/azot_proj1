//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace azot_proj1
{
    using System;
    using System.Collections.Generic;
    
    public partial class warnings
    {
        public int id { get; set; }
        public string dangerous_value { get; set; }
        public Nullable<System.DateTime> warning_time { get; set; }
        public Nullable<int> sensor_id { get; set; }
        public Nullable<int> workshop_id { get; set; }
        public Nullable<System.DateTime> warning_time_end { get; set; }
    
        public virtual sensors sensors { get; set; }
        public virtual workshop workshop { get; set; }

        public string getWarningTime()
        {
            string res;
            if (warning_time != null)
            {
                res = warning_time.ToString();
            }
            else { res = ""; }
            return res;

        }

        public string getWarningTimeEnd()
        {
            string res;
            if (warning_time_end != null)
            {
                res = warning_time_end.ToString();
            }
            else { res = ""; }
            return res;

        }
    }
}
