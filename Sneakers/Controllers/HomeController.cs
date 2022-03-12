using Sneakers.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sneakers.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CountItem()
        {
            OrderDTO o = (OrderDTO)Session["cartAdmin"];
            if (o == null)
                return PartialView(0);
            return PartialView(o.listItem.Count);
        }
    }
}