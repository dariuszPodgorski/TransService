using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TransServiceWebApp.Models;

namespace TransServiceWebApp.DAO
{
    public class EmployeeDao
    {
        internal List<Employee> GetAllEmployee()
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.Employee.Include("EmployeeType").ToList();

                return db.Employee.ToList();
            }
        }


        internal List<EmployeeType> GetAll()
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.EmployeeType.ToList();
                return model;
            }

        }

        internal void Save(Employee employee)
        {
            try
            {
                using (var db = new TransServiceDbContext())
                {
                    using (var trans = db.Database.BeginTransaction())
                    {

                        db.Employee.Add(employee);
                        db.SaveChanges();
                        employee.IndentyficatorEmployee = "00" + employee.IdEmployee;   
                        db.SaveChanges();
                        trans.Commit();
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Wystapil blad podczas zapisu do bazy danych");
            }
        }

        internal Employee GetEmployeeDetails(int employeeId)
        {
            using (var db = new TransServiceDbContext())
            {
                var model1 = db.Employee.Include("Login").ToList();
                return db.Employee.Where(s => s.IdEmployee == employeeId).Single();
            }
        }


        internal Employee GetEmployee(int loginId)
        {
            using (var db = new TransServiceDbContext())
            {
                return db.Employee.Where(s => s.IdEmployee == loginId).Single();
            }
        }


        internal void Edit(Employee employee)
        {
            using (var db = new TransServiceDbContext())
            {
                try
                {
                    db.Employee.AddOrUpdate(employee);
                    db.SaveChanges();

                }
                catch (Exception)
                {
                    throw new Exception("Wystapil blad podczas zapisu do bazy danych");
                }
            }


           
        }


        internal void Update(Employee modelDb)
        {
            using (var db = new TransServiceDbContext())
            {
                try
                {
                    db.Employee.AddOrUpdate(modelDb);
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    throw new Exception("Wystąpił błąd na zapisie do bazy danych");
                }
            }
        }
    }
}