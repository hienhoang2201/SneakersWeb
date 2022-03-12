using Sneakers.Models;
using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneakers.Areas.Admin.Models.DAO
{
    public class CategoryDAO
    {
        
        private SneakersModel db;

        public CategoryDAO()
        {
            db = new SneakersModel();
        }
        public IQueryable<CATEGORY> CATEGORies
        {
            get { return db.CATEGORies; }
        }
        public List<CATEGORY> ListCate()
        {
            return db.CATEGORies.ToList();
        }
        public CATEGORY getById(int id)
        {
            return db.CATEGORies.Single(i => i.CateID == id);
        }
        public void CreateCate(CATEGORY ca)
        {
            db.CATEGORies.Add(ca);
            db.SaveChanges();
        }
        public CATEGORY FindCateByID(int id)
        {
            return db.CATEGORies.Find(id);
        }
        public void Edit(CATEGORY ca)
        {
            CATEGORY category = FindCateByID(ca.CateID);
            if (category != null)
            {
                category.CateName = ca.CateName;
                category.CateDescription = ca.CateDescription;
                //category.AdminID = ca.AdminID;
                db.SaveChanges();
            }
        }
        public void DeleteCate(int id)
        {
            CATEGORY ca = db.CATEGORies.Find(id);
            if (ca != null)
            {
                db.CATEGORies.Remove(ca);
                db.SaveChanges();
            }
        }

    }
}