﻿//------------------------------------------------------------------------------
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using azot_proj1.Models;
    using System.Linq;

    public partial class azot_db1Entities : DbContext
    {
        public azot_db1Entities()
            : base("name=azot_db1Entities")
        {
        }

        public List<QueryResultModel> res;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sensor_types> sensor_types { get; set; }
        public virtual DbSet<sensors> sensors { get; set; }
        public  DbSet<warnings> warnings { get; set; }
        public virtual DbSet<workshop> workshop { get; set; }


        public List<QueryResultModel> getWarningsForWorkshop(int in_id) {

            res = new List<QueryResultModel>();

            IQueryable<warnings> mywarnings = warnings
                .Include("sensors")
                .Include("workshop")
                .Where(c => c.workshop_id == in_id)
                .Select(c => c);

            foreach (warnings w in mywarnings)
            {
                res.Add(new QueryResultModel
                {
                    sensor_name = w.sensors.name,
                    warn_id = w.id,
                    workshop_name=w.workshop.name,
                    dangerous_value=w.dangerous_value,
                    warning_time=w.warning_time

                });
            }
            return res;
        }

        

        public List<QueryResultModel> getDataWithSensorValues(int in_id)
        {

            res = new List<QueryResultModel>();

            IQueryable<warnings> mywarnings = warnings
                .Include("sensors")               
                .Where(c => c.id == in_id)
                .Select(c => c);
/*select st.name,s.name,warn.dangerous_value,st.normal_value,warn.warning_time 
	from  sensors s 
	inner join warnings warn on warn.sensor_id=s.id
	inner join sensor_types st on s.sensor_type_id=st.id 
	where s.id=1;*/
            foreach (warnings w in mywarnings)
            {
                res.Add(new QueryResultModel
                {
                    sensor_name = w.sensors.name,
                    warn_id = w.id,
                    dangerous_value = w.dangerous_value,
                    warning_time = w.warning_time,
                    sensor_type_name=w.sensors.sensor_types.name,
                    normal_value=w.sensors.sensor_types.normal_value

                });
            }
            return res;
        }

    }
}
