using Sneakers.Areas.Admin.Models.DAO;
using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sneakers.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order


        SneakersModel db = new SneakersModel();
        public ActionResult Index()
        {
            return View(db.ORDERs.ToList());
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(ORDER or, int userid)
        {

            ORDER order = new ORDER();
            order.Amount = or.Amount;
            order.Daytime = or.Daytime;
            order.DeliveryAddress = or.DeliveryAddress;
            order.OrderDescription = or.OrderDescription;
            order.OrderStatus = or.OrderStatus;
            order.UserID = userid;
            OrderDAO dao = new OrderDAO();
            dao.Create(order);
            return RedirectToAction("Index", "Order");
        }
        public ActionResult Edit(int id)
        {
            OrderDAO proDao = new OrderDAO();
            //ViewBag.cat = dao.ListCate();
            ORDER pro = proDao.FindOrderByID(id);
            return View(pro);
        }

        [HttpPost]
        public ActionResult Edit(ORDER or)
        {
            //var img = Path.GetFileName(photo.FileName);
            OrderDAO dao = new OrderDAO();
            ORDER order = dao.FindOrderByID(or.OrderID);
            order.Amount = or.Amount;
            order.Daytime = or.Daytime;
            order.DeliveryAddress = or.DeliveryAddress;
            order.OrderDescription = or.OrderDescription;
            order.OrderStatus = or.OrderStatus;
            OrderDAO c = new OrderDAO();
            c.Edit(order);
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {

            OrderDAO dao = new OrderDAO();
        
            ORDER order = dao.FindOrderByID(id);

            return View(order);
        }
        public ActionResult Delete(int id)
        {

            OrderDAO dao = new OrderDAO();
            ORDER pro = new ORDER();
            pro = dao.FindOrderByID(id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Delete(ORDER pro)
        {

            OrderDAO dao = new OrderDAO();
            dao.DeleteOrder(pro.OrderID);
            return RedirectToAction("Index");
        }
    }
}