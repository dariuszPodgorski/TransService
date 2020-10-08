using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.Models;

namespace TransServiceWebApp.DAO
{
    public class RegistrationDao
    {

        internal void Save(Client principal)
        {
            try
            {
                using (var db = new TransServiceDbContext())
                {
                    db.Client.Add(principal);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Wystapil blad podczas zapisu do bazy danych");
            }
        }
    }
}