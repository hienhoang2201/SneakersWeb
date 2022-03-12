using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sneakers.Models.DAO;
using Sneakers.Models.Entities;

namespace Sneakers.Controllers
{
    public class ProductController : Controller
    {
        SneakersModel db = new SneakersModel();
        // GET: Product
        public ActionResult Index(string key, int pageNum = 1, int pageSize = 4)
        {
            ProductCateDAO daoCate = new ProductCateDAO();
            ViewBag.cat = daoCate.listall();
            ProductDAO dao = new ProductDAO();
            if (!string.IsNullOrEmpty(key))
            {
                return View(dao.lstSearchName(key, pageNum, pageSize));
            }
            return View(dao.lst(pageNum, pageSize));
            //var ProductDAO = new ProductDAO();
            //ViewBag.Product = ProductDAO.ListProduct();
            //return View();

        }
        [ChildActionOnly]
        public PartialViewResult ProductCate()
        {
            var model = new ProductCateDAO().listall();
            return PartialView(model);
        }
        //public ActionResult cate (int id)
        //{
        //    var 
        //}
        public ActionResult Details(int id)
        {

            ProductDAO dao = new ProductDAO();
            PRODUCT pro = dao.FindProductByID(id);
            return View(pro);
        }
        public ActionResult cate(int id/*, int pageNum = 1, int pageSize = 3*/)
        {
            var CatePro = from p in db.PRODUCTs where p.CategoryID == id select p;
            return View(CatePro.ToList());

        }
    }
}