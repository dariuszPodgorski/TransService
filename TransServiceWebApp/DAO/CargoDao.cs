using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.Models;

namespace TransServiceWebApp.DAO
{
    public class CargoDao
    {
        internal List<TypeCargo> GetAllTypeCargo()
        {

            using (var db = new TransServiceDbContext())
            {
                return db.TypeCargo.ToList();
            }



        }

    }
}