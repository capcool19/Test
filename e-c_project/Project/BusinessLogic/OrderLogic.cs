using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataAcessLayer.Models;

namespace BusinessLogic
{
    public class OrderLogic
    {
        OrderDAL dal = new OrderDAL();

        public List<Order> GetOrderList()
        {
            return dal.GetOrderList();
        }
        public Order GetOrderById(int? id)
        {
            return dal.GetOrderById(id);
        }
        public void UpdateOrder(Order Order)
        {
            dal.UpdateOrder(Order);
        }
        public void DeleteOrder(int id)
        {
            dal.DeleteOrder(id);
        }
    }
}
