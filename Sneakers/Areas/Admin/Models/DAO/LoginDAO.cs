using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneakers.Areas.Admin.Models.DAO
{
    public class LoginDAO
    {
       SneakersModel db;
        public LoginDAO()
        {
            db = new SneakersModel();
        }
        public bool Login(string username, string password)
        {
            var res = (from s in db.ADMINs where s.Username == username && s.Password == password select s);
            if (res.Count() > 0)
                return true;
            return false;
        }
    }
}