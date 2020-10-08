using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TransServiceWebApp.Models;

namespace TransServiceWebApp.DAO
{
    public class OrderDao
    {
        internal List<AllOrder> GetClientOrders(int idLogin)
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.AllOrder.Include("Status").Where(s => s.Client.IdLogin == idLogin).ToList();

                return model;
            }
        }


        /*
        * 
        *  SZCZEGÓŁY NOWEGO ZAMÓWIENIA
        *  
        */

        internal AllOrder GetNewOrderDetails(int orderId)
        {
            using (var db = new TransServiceDbContext())
            {

                return db.AllOrder.Where(s => s.IdAllOrder == orderId).Single();
            }
        }


        /*
         * 
         *  SZCZEGÓŁY NOWEGO ZAMÓWIENIA
         *  
         */

        internal AllOrder GetDetailsOrder(int orderId)
        {
            using (var db = new TransServiceDbContext())
            {

                var model2 = db.AllOrder.Include("Status").ToList();
                var model1 = db.AllOrder.Include("TypeCargo").ToList();

                return db.AllOrder.Where(s => s.IdAllOrder == orderId).Single();
            }
        }

        /*
         * 
         * ZAPISYWANIE NOWEGO ZAMÓWIENIA 
         * 
         */

        internal void Save(AllOrder order)
        {
            using (var db = new TransServiceDbContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {

                    db.AllOrder.Add(order);
                    db.SaveChanges();
                    order.DateCreate = DateTime.Now;
                    order.NameOrder = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + order.IdAllOrder;
                    order.IdStatus = 1;
                    db.SaveChanges();
                    trans.Commit();
                }
            }
        }


        internal List<AllOrder> GetAllOrder()
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.AllOrder.ToList();
                return model;
            }

        }


        internal List<AllOrder> GetOrders()
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.AllOrder.Include("Status").ToList();

                return db.AllOrder.ToList();
            }
        }

        internal List<AllOrder> GetNewOrders()
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.AllOrder.Include("Status").ToList();

                return db.AllOrder.Where(s => s.IdStatus == 1).ToList();
            }
        }

        internal List<AllOrder> GeOrdersInProgress()
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.AllOrder.Include("Status").ToList();

                return db.AllOrder.Where(s => s.IdStatus == 3).ToList();
            }
        }

        internal List<AllOrder> GeOrdersClose()
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.AllOrder.Include("Status").ToList();

                return db.AllOrder.Where(s => s.IdStatus == 4).ToList();
            }
        }


        internal AllOrder GetOrder(int orderId)
        {
            using (var db = new TransServiceDbContext())
            {
                return db.AllOrder.Where(s => s.IdAllOrder == orderId).Single();
            }
        }





        internal void Update(AllOrder model)
        {
            using (var db = new TransServiceDbContext())
            {
                db.AllOrder.AddOrUpdate(model);
                db.SaveChanges();
            }
        }

        public List<AllOrder> GetDriverOrder(int idLogin)
        {
            using (var db = new TransServiceDbContext())
            {
                var model = db.AllOrder.Include("Status").Where(s => s.Employee.IdLogin == idLogin).ToList();
                return model;
            }
        }
    }
}