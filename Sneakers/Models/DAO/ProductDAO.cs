using PagedList;
using Sneakers.Areas.Admin.Models.DTO;
using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneakers.Models.DAO
{
    public class ProductDAO
    {
        SneakersModel db;
        public ProductDAO()
        {
            db = new SneakersModel();

        }
        public List<PRODUCT> ListProduct()
        {
            return db.PRODUCTs.ToList();
        }
        public PRODUCT FindProductByID(int id)
        {
            return db.PRODUCTs.Find(id);
        }
        //public List<PRODUCT> cate(int id/*, int pageNum = 1, int pageSize = 3*/)
        //{
        //    var CatePro = from p in db.PRODUCTs where p.CategoryID == id select p;
        //    return View(CatePro.ToList());
        //    //return db.PRODUCTs.Where(x => x.CategoryID == id).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        //}
        public IEnumerable<ProductDTO> lst(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("SELECT ProductID, ProName,ProDescription, Price, " +
                " ProStatus, CateName, ImageLink " +
                " FROM PRODUCT P, CATEGORY C " +
                " WHERE P.CategoryID = C.CateID "
                ).ToPagedList<ProductDTO>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<ProductDTO> lstSearchName(string key,  int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("SELECT ProductID, ProName,ProDescription, Price, " +
                " ProStatus, CateName, ImageLink " +
                " FROM PRODUCT P, CATEGORY C " +
                " WHERE P.CategoryID = C.CateID AND P.ProName LIKE '%" + key + "%'" 
                ).ToPagedList<ProductDTO>(pageNum, pageSize);
            return lst;
        }
    }
}