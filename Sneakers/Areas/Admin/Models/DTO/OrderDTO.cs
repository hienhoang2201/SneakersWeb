using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneakers.Areas.Admin.Models.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }

        public double? Amount { get; set; }

        public DateTime? Daytime { get; set; }


        public string DeliveryAddress { get; set; }


        public string OrderDescription { get; set; }

        public int? UserID { get; set; }

        public string OrderStatus { get; set; }

        public string OrderUserName { get; set; }
    }
}