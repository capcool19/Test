using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Models;

namespace DataAcessLayer
{
    public class UserDAL
    {
        ProjectEntities db = new ProjectEntities();
        public List<User> GetUserList()
        {
            var users = db.Users.ToList();
            return users;
        }
        public void CreateNewUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public User GetUserById(int? id)
        {
            User user = db.Users.Find(id);
            return user;
        }
        public void UpdateUser(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

       
    }
}
