using Sneakers.Areas.Admin.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sneakers.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String Username, string Password)
        {
            LoginDAO lo = new LoginDAO();
            if (lo.Login(Username, Password))
            {
                Session["username"] = Username;
                return RedirectToAction("Index", "Admin");
            }
            ModelState.AddModelError("", "Username or Password is incorrect!");
            return View();
        }
    }
}