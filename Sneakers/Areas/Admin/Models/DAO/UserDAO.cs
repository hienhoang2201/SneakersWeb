using Sneakers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneakers.Areas.Admin.Models.DAO
{
    public class UserDAO
    {
        SneakersModel db;
        public UserDAO()
        {
            db = new SneakersModel();
        }
        public IQueryable<USER> USERs
        {
            get { return db.USERs; }
        }
        public IQueryable<USER> ListUser()
        {
            var res = (from s in db.USERs select s);
            return res;
        }
        public USER FindUserByID(int id)
        {
            return db.USERs.Find(id);
        }
        public int CreateUser(USER us)
        {
            db.USERs.Add(us);
            db.SaveChanges();
            return us.UserID;
        }
        public void Edit(USER us)
        {
            USER user = FindUserByID(us.UserID);
            if (user != null)
            {
                user.Username = us.Username;
                user.Email = us.Email;
                user.Password = us.Password;
                user.Phone = us.Phone;
                user.UserAddress = us.UserAddress;
                db.SaveChanges();
            }


        }
        public void DeleteUser(int id)
        {
            USER us = db.USERs.Find(id);
            if (us != null)
            {
                db.USERs.Remove(us);
                db.SaveChanges();
            }
        }
    }
}