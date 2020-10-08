using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TransServiceWebApp.Models;

namespace TransServiceWebApp.DAO
{
    public class ClientDao
    {
        internal Client GetClient(int loginId)
        {
            using (var db = new TransServiceDbContext())
            {
                return db.Client.Where(s => s.IdLogin == loginId).Single();
            }
        }
        internal void Edit(Client principal)
        {
            using (var db = new TransServiceDbContext())
            {
                try
                {
                    db.Client.AddOrUpdate(principal);
                    db.SaveChanges();

                }
                catch (Exception)
                {
                    throw new Exception("Wystapil blad podczas zapisu do bazy danych");
                }
            }
        }

        internal List<Client> GetAllClient()
        {

            using (var db = new TransServiceDbContext())
            {
                return db.Client.ToList();
            }


        }
    }
}