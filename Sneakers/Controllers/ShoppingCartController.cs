using Sneakers.Areas.Admin.Models.DAO;
using Sneakers.Models.DTO;
using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sneakers.Controllers
{
    public class ShoppingCartController : Controller
    {
        //private const string cartsession = "cartsession";
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Order()
        {
            OrderDTO o = (OrderDTO)Session["cartAdmin"];
            Session["userID"] = o.UserID;
            return View(o);
        }
        public ActionResult Add(int id)
        {
            OrderDTO order = (OrderDTO)Session["cartAdmin"];
            if (order == null)
                order = new OrderDTO();
            ItemDTO item = new ItemDTO(id, 1);
            order.addItem(item);
            order.Amount = order.getTotalMoney();
            Session["cartAdmin"] = order;
            return RedirectToAction("Order", "ShoppingCart");
        }
        public ActionResult UpdateItem(int id, int quantity)
        {
            OrderDTO order = (OrderDTO)Session["cartAdmin"];
            order.updateItem(id, quantity);
            order.Amount = order.getTotalMoney();
            Session["cartAdmin"] = order;
            return RedirectToAction("Order", "ShoppingCart");
        }
        public ActionResult DeleteItem(int id)
        {
            OrderDTO order = (OrderDTO)Session["cartAdmin"];
            order.deleteItem(id);
            order.Amount = order.getTotalMoney();
            Session["cartAdmin"] = order;
            return RedirectToAction("Order", "ShoppingCart");
        }
        public ActionResult CreateOrder()
        {
            OrderDTO o = (OrderDTO)Session["cartAdmin"];
            Session["userID"] = o.UserID;
            return View(o);
        }
        [HttpPost]
        public ActionResult CreateOrder(string fullname, string phone, string email, string address)
        {
            OrderDTO order = (OrderDTO)Session["cartAdmin"];
            ORDER o = new ORDER();
            o.Daytime = DateTime.Now;
            o.OrderStatus = "Mới";
            o.DeliveryAddress = address;
            //add User
            USER u = new USER();
            u.FullName = fullname;
            u.Phone = phone;
            u.Email = email;
            
            UserDAO dao = new UserDAO();
            o.UserID = dao.CreateUser(u);
            //add Order
            o.Amount = order.getTotalMoney();
            int oId = new OrderDAO().Create(o);
            //add Item
            ItemDAO daoItem = new ItemDAO();
            foreach (ItemDTO item in order.listItem)
            {
                ITEM i = new ITEM();
                i.ProductID = item.ProductID;
                i.OrderID = oId;
                i.Quantity = item.Quantity;
                i.ItemPrice = item.Price;
                daoItem.InsertItem(i);
            }

            Session["cartAdmin"] = null;
            return RedirectToAction("Success", "ShoppingCart");
        }
        public ActionResult Success()
        {
            return View();
        }

    }
}