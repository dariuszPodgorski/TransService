using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.Models;

namespace TransServiceWebApp.DAO
{
    public class ProfilDao
    {
        internal Client GetClient(int loginId)
        {
            using (var db = new TransServiceDbContext())
            {
                return db.Client.Where(s => s.IdLogin == loginId).Single();
            }
        }


        internal Employee GetEmployee(int loginId)
        {
            using (var db = new TransServiceDbContext())
            {
                return db.Employee.Where(s => s.IdLogin == loginId).Single();
            }
        }
    }
}