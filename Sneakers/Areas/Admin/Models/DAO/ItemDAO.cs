using Sneakers.Models.DTO;
using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneakers.Areas.Admin.Models.DAO
{
    public class ItemDAO
    {
        SneakersModel db;
        public ItemDAO()
        {
            db = new SneakersModel();
        }
        public void InsertItem(ITEM i)
        {
            db.ITEMs.Add(i);//luu tren RAM
            db.SaveChanges();//luu vao o dia
            return;
        }
        public void UpdatetItem(ITEM tmp)
        {
            ITEM i = db.ITEMs.Find(tmp.OrderID, tmp.ProductID);
            if (i != null)
            {
                i.Quantity = tmp.Quantity;
                i.ItemPrice = tmp.ItemPrice;
                db.SaveChanges();//luu vao o dia
            }
            return;
        }

        public ITEM FindItem(int proId, int orderId)
        {
            return db.ITEMs.Find(proId, orderId);
        }
        public int Delete(int proId, int orderId)
        {
            ITEM i = db.ITEMs.Find(proId, orderId);
            if (i != null)
            {
                db.ITEMs.Remove(i);
                return db.SaveChanges();
            }
            return -1;
        }
        public List<ItemDTO> GetListItem(int oId, string proName)
        {
            var lst = db.Database.SqlQuery<ItemDTO>(string.Format("GetListItem {0}, N'{1}'", oId, proName)
                ).ToList();
            return lst;
        }
    }
}