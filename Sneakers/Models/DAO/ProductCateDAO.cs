using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneakers.Models.DAO
{
    public class ProductCateDAO
    {
        SneakersModel db;
        public ProductCateDAO()
        {
            db = new SneakersModel();

        }
        public IQueryable<CATEGORY> CATEGORies
        {
            get { return db.CATEGORies; }
        }
        public List<CATEGORY> listall()
        {
            return db.CATEGORies.ToList();
        }
        public CATEGORY getById(int id)
        {
            return db.CATEGORies.Single(i => i.CateID == id);
        }
    }
}

