using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataAcessLayer.Models;

namespace BusinessLogic
{
    public class ShoppingCartLogic
    {
        ShoppingCartDAL dal = new ShoppingCartDAL();
        public bool CheckOut(Order order, List<Cart> lstCart)
        {
            var check = dal.CheckOut(order, lstCart);
            return check;
        }
    }
}
