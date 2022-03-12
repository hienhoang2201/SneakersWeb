using Sneakers.Areas.Admin.Models.DTO;
using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Sneakers.Areas.Admin.Models.DAO
{
    public class ProductDAO
    {
        SneakersModel db;
        public ProductDAO()
        {
            db = new SneakersModel();
        }
        public IQueryable<PRODUCT> Products
        {
            get { return db.PRODUCTs; }
        }
        public IQueryable<PRODUCT> ListProduct()
        {
            var res = (from s in db.PRODUCTs select s);
            return res;
        }
        public IEnumerable<ProductDTO> lstjoin(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("SELECT ProductID, ProName,ProDescription, Price, " +
                " ProStatus, CateName, ImageLink " +
                " FROM PRODUCT P, CATEGORY C " +
                " WHERE P.CategoryID = C.CateID "
                ).ToPagedList<ProductDTO>(pageNum, pageSize);
            return lst;
        }
        
        public PRODUCT FindProductByID(int id)
        {
            return db.PRODUCTs.Find(id);
        }
        
        public void DeleteProduct(int id)
        {
            PRODUCT pro = db.PRODUCTs.Find(id);
            if (pro != null)
            {
                db.PRODUCTs.Remove(pro);
                db.SaveChanges();
            }
        }
        public void Create(PRODUCT pro)
        {
            db.PRODUCTs.Add(pro);
            db.SaveChanges();
        }
        public void Edit(PRODUCT pro)
        {
            PRODUCT product = FindProductByID(pro.ProductID);
            if (product != null)
            {
                product.ProName = pro.ProName;
                product.ProDescription = pro.ProDescription;
                product.Price = pro.Price;
                product.ImageLink = pro.ImageLink;
                product.ProStatus = pro.ProStatus;
                product.CategoryID = pro.CategoryID;
                db.SaveChanges();
            }


        }
        public IEnumerable<ProductDTO> lstSearchProByName(string proName, int categoryId, double minPrice, double maxPrice, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("lstSearchProByName " +
                "N'" + proName + "', " + categoryId + ", " + minPrice + ", " + maxPrice
                ).ToPagedList<ProductDTO>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<ProductDTO> lstSearchProByProName(string proName, int categoryId, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("lstSearchProByProName " +
                "N'" + proName + "'," + categoryId
                ).ToPagedList<ProductDTO>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<ProductDTO> lstSearchProByPriceMin(int categoryId, double minPrice,  int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("lstSearchProByPriceMin " +
                  +categoryId + ", "+minPrice  
                ).ToPagedList<ProductDTO>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<ProductDTO> lstSearchProByPriceMax(int categoryId, double maxPrice, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("lstSearchProByPriceMax " +
                  +categoryId + ", " + maxPrice
                ).ToPagedList<ProductDTO>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<ProductDTO> lstSearchProByMinMax(int categoryId, double minPrice,double maxPrice, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("lstSearchProByMinMax " +
                   +categoryId+ "," +maxPrice + ", " + minPrice
                ).ToPagedList<ProductDTO>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<ProductDTO> lstSearchProByNameAndMin(string proName, int categoryId,double minPrice,  int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("lstSearchProByProNameAndMin " +
                "N'" + proName + "', " + categoryId +  ", "  + minPrice
                ).ToPagedList<ProductDTO>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<ProductDTO> lstSearchProByNameAndMax(string proName, int categoryId,double maxPrice, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("lstSearchProByNameAndMax " +
                "N'" + proName + "', " + categoryId +  ", " + maxPrice
                ).ToPagedList<ProductDTO>(pageNum, pageSize);
            return lst;
        }
        //public IEnumerable<ProductDTO> lstSearchProByCate( int categoryId, int pageNum, int pageSize)
        //{
        //    var lst = db.Database.SqlQuery<ProductDTO>("lstSearchProByCate " +
        //         + categoryId 
        //        ).ToPagedList<ProductDTO>(pageNum, pageSize);
        //    return lst;
        //}


    }
}
