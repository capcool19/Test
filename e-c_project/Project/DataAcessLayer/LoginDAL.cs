using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Models;

namespace DataAcessLayer
{
    public class LoginDAL
    {
        ProjectEntities db = new ProjectEntities();
        public List<User> GetLoginList()
        {
            var users = db.Users.ToList();
            return users;
        }
        public void CreateNewLogin(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public User GetLoginById(int? id)
        {
            User user = db.Users.Find(id);
            return user;
        }
        public void UpdateLogin(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteLogin(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
