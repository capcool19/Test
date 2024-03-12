using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Models;

namespace DataAcessLayer
{
    public class OrderDAL
    {
        ProjectEntities db = new ProjectEntities();
        public List<Order> GetOrderList()
        {
            var Order = db.Orders.ToList();
            return Order;
        }
        public Order GetOrderById(int? id)
        {
            Order Order = db.Orders.Find(id);
            return Order;
        }
        public void UpdateOrder(Order Order)
        {
            db.Entry(Order).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteOrder(int id)
        {
            var orderDetail = db.OrderDetails.Where(x => x.OrderId.Equals(id)).ToList();
            foreach(var item in orderDetail)
            {
                db.OrderDetails.Remove(item);
                db.SaveChanges();
            }
            var Order = db.Orders.Find(id);
            db.Orders.Remove(Order);
            db.SaveChanges();
        }
    }
}
