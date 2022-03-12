using Sneakers.Areas.Admin.Models.DAO;
using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneakers.Models.DTO
{
    public class ItemDTO
    {
        public int ProductID { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string ImageLink { get; set; }
        public string ProName { get; set; }
        public ItemDTO(int id, int quantity)
        {
            this.ProductID = id;
            this.Quantity = quantity;
            PRODUCT pro = new ProductDAO().FindProductByID(id);
            this.Price = pro.Price;
            this.ImageLink = pro.ImageLink;
            this.ProName = pro.ProName;
            
        }
        
    }
}