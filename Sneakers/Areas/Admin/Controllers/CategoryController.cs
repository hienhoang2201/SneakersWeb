using Sneakers.Areas.Admin.Models.DAO;
using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sneakers.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        SneakersModel db = new SneakersModel();
        public ActionResult Index()
        {
            return View(db.CATEGORies.ToList());
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(CATEGORY ca)
        {

            CATEGORY category = new CATEGORY();
            category.CateName = ca.CateName;
            category.CateDescription = ca.CateDescription;
            CategoryDAO dao = new CategoryDAO();
            dao.CreateCate(category);
            return RedirectToAction("Index", "Category");

        }
        public ActionResult Details(int id)
        {

            CategoryDAO dao = new CategoryDAO();
            CATEGORY ca = dao.FindCateByID(id);

            return View(ca);
        }
        public ActionResult Edit(int id)
        {

            CategoryDAO dao = new CategoryDAO();
            CATEGORY ca = dao.FindCateByID(id);
            return View(ca);
        }
        [HttpPost]
        public ActionResult Edit(CATEGORY ca)
        {

            CategoryDAO dao = new CategoryDAO();
            CATEGORY category = dao.FindCateByID(ca.CateID);
            category.CateName = ca.CateName;
            category.CateDescription = ca.CateDescription;          
            CategoryDAO c = new CategoryDAO();
            c.Edit(category);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {

            CategoryDAO dao = new CategoryDAO();
            CATEGORY ca = new CATEGORY();
            ca = dao.FindCateByID(id);
            return View(ca);
        }
        [HttpPost]
        public ActionResult Delete(CATEGORY ca)
        {

            CategoryDAO dao = new CategoryDAO();
            dao.DeleteCate(ca.CateID);
            return RedirectToAction("Index");
        }


    }
}