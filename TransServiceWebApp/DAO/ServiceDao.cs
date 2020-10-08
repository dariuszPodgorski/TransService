using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.Models;

namespace TransServiceWebApp.DAO
{
    public class ServiceDao
    {
        internal List<TypeService> GetAllTypeService()
        {

            using (var db = new TransServiceDbContext())
            {
                return db.TypeService.ToList();
            }


        }

        internal void Save(Service service)
        {

            var db = new TransServiceDbContext();

            db.Service.Add(service);
            db.SaveChanges();

        }

        internal List<Service> GetAll()
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.Service.Include("Vehicle").ToList();
                var model2 = db.Service.Include("TypeService").ToList();
                return db.Service.ToList();
            }
        }

        internal Service GetServiceDetails(int serviceId)
        {
            using (var db = new TransServiceDbContext())
            {
                var model1 = db.Service.Include("Vehicle").ToList();
                var model2 = db.Service.Include("TypeService").ToList();

                return db.Service.Where(s => s.IdSerwis == serviceId).Single();
            }
        }
    }
}