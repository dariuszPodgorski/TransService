using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.Models;

namespace TransServiceWebApp.DAO
{
    public class VehicleDao
    {
        internal List<Vehicle> GetAll()
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.Vehicle.ToList();
                return model;
            }

        }

        internal void Save(Vehicle vehicle)
        {

            var db = new TransServiceDbContext();

            db.Vehicle.Add(vehicle);
            db.SaveChanges();

        }


        internal Vehicle GetVehicleDetails(int vehicleId)
        {
            using (var db = new TransServiceDbContext())
            {
                return db.Vehicle.Where(s => s.IdVehicle == vehicleId).Single();
            }
        }
    }
}