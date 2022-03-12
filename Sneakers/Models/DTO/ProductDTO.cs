using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneakers.Models.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }


        public string ProName { get; set; }


        public string ImageLink { get; set; }


        public string ProDescription { get; set; }

        public double? Price { get; set; }

        public string ProStatus { get; set; }

        public int? CategoryID { get; set; }

        public string CateName { get; set; }

        internal object ViewDetail(int productID)
        {
            throw new NotImplementedException();
        }
    }
}