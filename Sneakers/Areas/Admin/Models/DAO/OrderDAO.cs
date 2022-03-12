using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneakers.Areas.Admin.Models.DAO
{
    public class OrderDAO
    {
        SneakersModel db;
        public OrderDAO()
        {
            db = new SneakersModel();
        }
        public IQueryable<ORDER> Orders
        {
            get { return db.ORDERs; }
        }
        public IQueryable<ORDER> ListOrder()
        {
            var res = (from s in db.ORDERs select s);
            return res;
        }
        public ORDER FindOrderByID(int id)
        {
            return db.ORDERs.Find(id);
        }
        public int Create(ORDER or)
        {
            db.ORDERs.Add(or);
            db.SaveChanges();
            return or.OrderID;
        }
        public void Edit(ORDER or)
        {
            ORDER order = FindOrderByID(or.OrderID);
            if (order != null)
            {
                order.Amount = or.Amount;
                order.Daytime = or.Daytime;
                order.DeliveryAddress = or.DeliveryAddress;
                order.OrderDescription = or.OrderDescription;
                order.OrderStatus = or.OrderStatus;
                db.SaveChanges();
            }
        }
        public void DeleteOrder(int id)
        {
            ORDER pro = db.ORDERs.Find(id);
            if (pro != null)
            {
                db.ORDERs.Remove(pro);
                db.SaveChanges();
            }
        }


    }
    

}