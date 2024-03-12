using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataAcessLayer.Models;

namespace BusinessLogic
{
    public class LoginLogic
    {

        LoginDAL dal = new LoginDAL();

        public List<User> GetLoginList()
        {
            var users = dal.GetLoginList();
            return users;
        }
        public void CreateNewLogin(User user)
        {
            dal.CreateNewLogin(user);
        }
        public User GetUserById(int? id)
        {
            User user = dal.GetLoginById(id);
            return user;
        }
        public void UpdateLogin(User user)
        {
            dal.UpdateLogin(user);
        }
        public void DeleteLogin(int id)
        {
            dal.DeleteLogin(id);
        }
    }
}
