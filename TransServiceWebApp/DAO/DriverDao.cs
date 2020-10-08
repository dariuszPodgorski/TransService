using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.Enum;
using TransServiceWebApp.Models;

namespace TransServiceWebApp.DAO
{
    public class DriverDao
    {
        internal List<Employee> GetAll()
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.Employee.Where(s => s.EmployeeType.IdEmployeeType == (byte)UserType.EmployeeDriver).ToList();
                return model;
            }

        }
    }
}