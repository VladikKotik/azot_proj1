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
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using azot_proj1.Models;
    
    public partial class azot_db1Entities1 : DbContext
    {
        public azot_db1Entities1()
            : base("name=azot_db1Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sensor_types> sensor_types { get; set; }
        public virtual DbSet<sensors> sensors { get; set; }
        public virtual DbSet<warnings> warnings { get; set; }
        public virtual DbSet<workshop> workshop { get; set; }
        
        public List<QueryResultModel> res;


        public List<QueryResultModel> getWarningsBySensorTypes(int in_workshop_id) { //возвращает данные по нарушениям по типу датчиков(считает кол-во нарушений для типа датчика)
            res = new List<QueryResultModel>();

            IQueryable<warnings> mywarnings=warnings
                .Include("sensors")
                .Where(c=> c.workshop_id==in_workshop_id)
                .Select(c=> c);

         
            foreach (var line in mywarnings.GroupBy(c => c.sensors.sensor_types)
                .Select(group => new {
                    myKey=group.Key,
                    myCount=group.Count()
                  
                }))
            {
                res.Add(new QueryResultModel
                {
                    sensor_type_name = line.myKey.name,
                    normal_value=line.myKey.normal_value,
                    warnings_quantity = line.myCount,
                    workshop_id=in_workshop_id,
                    sensor_type_id = line.myKey.id

                });

            }
            return res;

        }



        public List<QueryResultModel> getDetailedWarnings(int in_workshop_id) {//возвращает более подробные данные про все нарушения для цеха (2я таблица)

            res = new List<QueryResultModel>();

            IQueryable<warnings> mywarnings = warnings
                .Include("sensors")
                .Where(c => c.workshop_id == in_workshop_id)
                .OrderBy(c=>c.sensors.sensor_type_id)
                .Select(c => c);

            foreach (warnings w in mywarnings)
            {
                res.Add(new QueryResultModel
                {
                    sensor_name = w.sensors.name,
                    dangerous_value = w.dangerous_value,
                    warning_time = w.getWarningTime(),
                    warning_time_end = w.getWarningTimeEnd(),
                    sensor_type_id=w.sensors.sensor_type_id

                });
            }
            return res;
        }
    }
}
