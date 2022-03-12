using Sneakers.Areas.Admin.Models.DAO;
using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sneakers.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index(string keywords, string categoryId, string minPrice, string maxPrice, int pageNum =1, int pageSize=3)
        {
            
            CategoryDAO daoCate = new CategoryDAO();
            ViewBag.cat = daoCate.ListCate();
            ProductDAO dao = new ProductDAO();
            if (!string.IsNullOrEmpty(keywords) && !string.IsNullOrEmpty(minPrice) && !string.IsNullOrEmpty(maxPrice))
            {
                return View(dao.lstSearchProByName(keywords, Convert.ToInt32(categoryId), Convert.ToDouble(minPrice), Convert.ToDouble(maxPrice), pageNum, pageSize));
            }
            if (!string.IsNullOrEmpty(keywords) && string.IsNullOrEmpty(minPrice) && string.IsNullOrEmpty(maxPrice))
            {
                return View(dao.lstSearchProByProName(keywords, Convert.ToInt32(categoryId), pageNum, pageSize));
            }
            if (string.IsNullOrEmpty(keywords) && !string.IsNullOrEmpty(minPrice) && string.IsNullOrEmpty(maxPrice))
            {
                return View(dao.lstSearchProByPriceMin(Convert.ToInt32(categoryId),Convert.ToDouble(minPrice), pageNum, pageSize));
            }
            if (string.IsNullOrEmpty(keywords) && string.IsNullOrEmpty(minPrice) && !string.IsNullOrEmpty(maxPrice))
            {
                return View(dao.lstSearchProByPriceMax(Convert.ToInt32(categoryId),Convert.ToDouble(maxPrice), pageNum, pageSize));
            }
            if (string.IsNullOrEmpty(keywords) && !string.IsNullOrEmpty(minPrice) && !string.IsNullOrEmpty(maxPrice))
            {
                return View(dao.lstSearchProByMinMax(Convert.ToInt32(categoryId), Convert.ToDouble(minPrice),Convert.ToDouble(maxPrice), pageNum, pageSize));
            }
            if (!string.IsNullOrEmpty(keywords) && !string.IsNullOrEmpty(minPrice) && string.IsNullOrEmpty(maxPrice))
            {
                return View(dao.lstSearchProByNameAndMin(keywords, Convert.ToInt32(categoryId), Convert.ToDouble(minPrice), pageNum, pageSize));
            }
            if (!string.IsNullOrEmpty(keywords) && string.IsNullOrEmpty(minPrice) && !string.IsNullOrEmpty(maxPrice))
            {
                return View(dao.lstSearchProByNameAndMax(keywords, Convert.ToInt32(categoryId), Convert.ToDouble(maxPrice), pageNum, pageSize));
            }
            //if (string.IsNullOrEmpty(keywords) && string.IsNullOrEmpty(minPrice) && string.IsNullOrEmpty(maxPrice))
            //{
            //    return View(dao.lstSearchProByCate( Convert.ToInt32(categoryId),  pageNum, pageSize));
            //}

            return View(dao.lstjoin(pageNum, pageSize));
        }
        public ActionResult Delete(int id)
        {

            ProductDAO dao = new ProductDAO();
            PRODUCT pro = new PRODUCT();
            pro = dao.FindProductByID(id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Delete(PRODUCT pro)
        {

            ProductDAO dao = new ProductDAO();
            dao.DeleteProduct(pro.ProductID);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {

            ProductDAO dao = new ProductDAO();
            PRODUCT pro = dao.FindProductByID(id);

            return View(pro);
        }
        public ActionResult Create (PRODUCT pro)
        {
            CategoryDAO dao = new CategoryDAO();
            ViewBag.cat = dao.ListCate();
            return View();
        }
        [HttpPost]
        public ActionResult Create (PRODUCT pro, int idcategory, HttpPostedFileBase photo)
        {
            var img = Path.GetFileName(photo.FileName);
            PRODUCT product = new PRODUCT();
            product.ProName = pro.ProName;
            product.ProDescription = pro.ProDescription;
            product.Price = pro.Price;
            product.ProStatus = pro.ProStatus;
            product.CategoryID = idcategory;
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/images/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    product.ImageLink = photo.FileName;
                    ProductDAO dao = new ProductDAO();
                    dao.Create(product);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ActionResult Edit(int id)
        {
            List<CATEGORY> ls = new List<CATEGORY>();
            CategoryDAO dao = new CategoryDAO();
            ProductDAO proDao = new ProductDAO();
            ViewBag.cat = dao.ListCate();
            PRODUCT pro = proDao.FindProductByID(id);
            return View(pro);
        }

        [HttpPost]
        public ActionResult Edit(PRODUCT pro, int idcategory, HttpPostedFileBase photo)
        {
            //var img = Path.GetFileName(photo.FileName);
            ProductDAO dao = new ProductDAO();
            PRODUCT product = dao.FindProductByID( pro.ProductID);
            product.ProName = pro.ProName;
            product.ProDescription = pro.ProDescription;
            product.Price= pro.Price;
            product.ProStatus= pro.ProStatus;
            product.CategoryID= idcategory;
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/images/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    product.ImageLink = photo.FileName;
                    
                }
                ProductDAO d = new ProductDAO();
                d.Edit(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
    }
}