using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneakers.Areas.Admin.Models.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }

      
        public string Username { get; set; }

        
        public string Email { get; set; }

        
        public string Password { get; set; }

        
        public string Phone { get; set; }

        public string UserAddress { get; set; }
    }
}