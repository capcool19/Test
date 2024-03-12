using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataAcessLayer.Models;

namespace BusinessLogic
{
    public class UserLogic
    {
        UserDAL dal = new UserDAL();

        public List<User> GetUserList()
        {
            var users = dal.GetUserList();
            return users;
        }
        public void CreateNewUser(User user)
        {
            dal.CreateNewUser(user);
        }
        public User GetUserById(int? id)
        {
            User user = dal.GetUserById(id);
            return user;
        }
        public void UpdateUser(User user)
        {
            dal.UpdateUser(user);
        }
        public void DeleteUser(int id)
        {
            dal.DeleteUser(id);
        }
    }
}
