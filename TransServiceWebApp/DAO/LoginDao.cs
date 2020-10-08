using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.Models;

namespace TransServiceWebApp.DAO
{
    public class LoginDao
    {
        public bool CheckPassword(string login, string Hash)
        {
            using (var db = new TransServiceDbContext())
            {
                return db.Login.Where(s => s.Login1 == login && s.Password == Hash).Any();
            }
        }

        internal int GetLoginId(string login)
        {
            using (var db = new TransServiceDbContext())
            {
                return db.Login.Where(s => s.Login1 == login).Select(s => s.IdLogin).Single();
            }
        }

        public int GetIdClient(int idLogin)
        {
            using (var db = new TransServiceDbContext())
            {

                return db.Client.Where(s => s.IdLogin == idLogin).Select(s => s.IdCleint).Single();

            }
        }

        

        internal string GetLogin(int idLogin)
        {
            using (var db = new TransServiceDbContext())
            {

                return db.Login.Where(s => s.IdLogin == idLogin).Select(s => s.Login1).Single();

            }
        }

        public int? GetEmployeeType(int idLogin)
        {
            using (var db = new TransServiceDbContext())
            {
                // var x = db.Employee.Where(s => s.Login.IdLogin == idLogin).FirstOrDefault();
                //  var y =  x.IdEmployeeType;
                return db.Employee.Where(s => s.Login.IdLogin == idLogin).Select(s => s.IdEmployeeType).SingleOrDefault();
            }
        }

        internal void ChangePassword(string login, string v)
        {
            using (var db = new TransServiceDbContext())
            {
                try
                {
                    db.Login.Where(s => s.Login1 == login).Single().Password = v;
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    throw new Exception("Wystąpił błąd podczas zapisu do bazy danych");
                }
            }
        }
    }
}