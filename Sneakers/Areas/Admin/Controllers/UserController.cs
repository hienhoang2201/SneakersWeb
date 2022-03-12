using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sneakers.Areas.Admin.Models.DAO;
using Sneakers.Areas.Admin.Models.DTO;
using Sneakers.Models.Entities;

namespace Sneakers.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        private SneakersModel db = new SneakersModel();
        public ActionResult Index()
        {
            //UserDAO dao = new UserDAO();
            //IQueryable<USER> lst = dao.ListUser();
            return View(db.USERs.ToList());
        }
        public ActionResult Delete(int id)
        {

            UserDAO dao = new UserDAO();
            USER us = new USER();
            us = dao.FindUserByID(id);
            return View(us);
        }
        [HttpPost]
        public ActionResult Delete(USER us)
        {

            UserDAO dao = new UserDAO();
            dao.DeleteUser(us.UserID);
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(USER us)
        {

            USER user = new USER();
            user.Username = us.Username;
            user.Email = us.Email;
            user.Password = us.Password;
            user.Phone = us.Phone;
            user.UserAddress = us.UserAddress;
            UserDAO dao = new UserDAO();
            dao.CreateUser(user);
            return RedirectToAction("Index", "User");

        }
        public ActionResult Details(int id)
        {

            UserDAO dao = new UserDAO();
            USER us = dao.FindUserByID(id);

            return View(us);
        }
        public ActionResult Edit(int id)
        {

            UserDAO dao = new UserDAO();
            USER us = dao.FindUserByID(id);
            return View(us);
        }
        [HttpPost]
        public ActionResult Edit(USER us)
        {

            UserDAO dao = new UserDAO();
            USER user = dao.FindUserByID(us.UserID);
            user.Username = us.Username;
            user.Email = us.Email;
            user.Password = us.Password;
            user.Phone = us.Phone;
            user.UserAddress = us.UserAddress;
            UserDAO d = new UserDAO();
            d.Edit(user);
            return RedirectToAction("Index");
        }
    } 
}